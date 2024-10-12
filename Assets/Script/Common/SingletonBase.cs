using UnityEngine;

namespace Common
{
    // ���ͻ�������ʵ�ֵ���ģʽ
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

        protected virtual void Awake() { } // �������и��Ǵ˷������б�Ҫ�ĳ�ʼ��
    }
}