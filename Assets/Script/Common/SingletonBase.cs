using UnityEngine;

namespace Common
{
    // 泛型基类用于实现单例模式
    public abstract class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>, new()
    {
        private static T _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                            _instance.Awake();
                        }
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake() { } // 在子类中覆盖此方法进行必要的初始化
    }
}