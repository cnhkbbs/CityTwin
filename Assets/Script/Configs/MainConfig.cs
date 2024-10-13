using UnityEngine;
namespace Config
{
    [CreateAssetMenu(fileName = "SqlSettings", menuName = "ScriptableObjects/数据库配置")]
    public class SqlConfig : ScriptableObject
    {
        [Header("数据库地址")]
        public string server = "localhost";
        [Header("端口")]
        public string port = "3306";
        [Header("数据库名")]
        public string database = "city_twin";
        [Header("用户名")]
        public string user = "client";
        [Header("密码")]
        public string password = "client";
        [Header("数据更新间隔")]
        public float updateInterval = 5f;
    }
}
