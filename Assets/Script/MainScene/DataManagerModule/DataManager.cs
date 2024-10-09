using System.Collections.Generic;
using Common;
namespace DataManagerModule
{
    public class DataManager : SingletonBase<DataManager>
    {
        Dictionary<string, BaseData> dataCacheDic;
        public DataManager() 
        { 
            dataCacheDic = new Dictionary<string, BaseData>();
        }
        // ͨ����������ȡData
        public T GetDataByName<T>(string name) where T : BaseData
        {
            if (!dataCacheDic.ContainsKey(name))
                return null;
            return dataCacheDic[name] as T;
        }
        // �����ݼ�����ʱ�����ֵ�
        public T AddData<T>(string name, T data) where T : BaseData
        {
            if (dataCacheDic.ContainsKey(name))
                return null;
            dataCacheDic.Add(name, data);
            return data;
        }
        // ��ջ����ֵ�
        public void RemoveAllData()
        { 
            dataCacheDic.Clear(); 
        }
    }
}

