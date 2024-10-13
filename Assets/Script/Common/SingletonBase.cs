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
                    // �ڳ����в����Ƿ��Ѵ��ڸ����͵�ʵ��
                    instance = FindObjectOfType<T>();
                    // ��������в����ڸ����͵�ʵ�����򴴽�һ���µ�GameObject����Ӹ����
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
            // ����Ƿ�����ظ���ʵ��
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