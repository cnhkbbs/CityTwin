using UnityEngine;
namespace Config
{
    [CreateAssetMenu(fileName = "SqlSettings", menuName = "ScriptableObjects/���ݿ�����")]
    public class SqlConfig : ScriptableObject
    {
        [Header("���ݿ��ַ")]
        public string server = "localhost";
        [Header("�˿�")]
        public string port = "3306";
        [Header("���ݿ���")]
        public string database = "city_twin";
        [Header("�û���")]
        public string user = "client";
        [Header("����")]
        public string password = "client";
        [Header("���ݸ��¼��")]
        public float updateInterval = 5f;
    }
}
