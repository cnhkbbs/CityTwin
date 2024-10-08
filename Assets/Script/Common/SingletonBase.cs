namespace Common
{
    // ʵ������
    public class SingletonBase<T> where T: SingletonBase<T>
    {
        private static T instance;

        // ��ȡ����ʵ��
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = System.Activator.CreateInstance(typeof(T), true) as T;
                }
                return instance;
            }
        }
    }
}