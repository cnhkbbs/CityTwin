using UnityEngine;

namespace Common
{
    public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // 在场景中查找是否已存在该类型的实例
                    instance = FindObjectOfType<T>();
                    // 如果场景中不存在该类型的实例，则创建一个新的GameObject并添加该组件
                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name + "_Singleton");
                        instance = singletonObject.AddComponent<T>();
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
            // 检查是否存在重复的实例
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}