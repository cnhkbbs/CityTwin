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
        // 通过数据名获取Data
        public T GetDataByName<T>(string name) where T : BaseData
        {
            if (!dataCacheDic.ContainsKey(name))
                return null;
            return dataCacheDic[name] as T;
        }
        // 将数据加入临时缓存字典
        public T AddData<T>(string name, T data) where T : BaseData
        {
            if (dataCacheDic.ContainsKey(name))
                return null;
            dataCacheDic.Add(name, data);
            return data;
        }
        // 清空缓存字典
        public void RemoveAllData()
        { 
            dataCacheDic.Clear(); 
        }
    }
}

