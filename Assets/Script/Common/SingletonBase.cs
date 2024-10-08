namespace Common
{
    // 实例基类
    public class SingletonBase<T> where T: SingletonBase<T>
    {
        private static T instance;

        // 获取单例实例
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