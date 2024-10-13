using System.Collections;
using System.Collections.Generic;
using Common;
using Config;
using UnityEngine;
namespace DataManagerModule
{
    public class DataManager : SingletonBase<DataManager>
    {
        Dictionary<string, BaseData> dataCacheDic;

        private float updateInterval;
        SqlConfig sqlConfig;
        protected override void Awake()
        {
            sqlConfig = ScriptableObject.CreateInstance<SqlConfig>();
            SqlAccess sql = new SqlAccess(sqlConfig.server, sqlConfig.port, sqlConfig.user, sqlConfig.password, sqlConfig.database);
            updateInterval = sqlConfig.updateInterval;
        }

        private void Start()
        {
            InitDataDic();
            StartCoroutine(DataUpdater());
        }

        #region 缓冲区
        public DataManager() 
        { 
            dataCacheDic = new Dictionary<string, BaseData>();
        }
        // 初始化缓存字典
        private void InitDataDic()
        {
            EnergyData energyData = new EnergyData();
            AddData<EnergyData>(energyData.name, energyData);
            EnviromentData enviromentData = new EnviromentData();
            AddData<EnviromentData>(enviromentData.name, enviromentData);
            FinancialData financialData = new FinancialData();
            AddData<FinancialData>(financialData.name, financialData);
            MedicalData mediicalData = new MedicalData();
            AddData<MedicalData>(mediicalData.name, mediicalData);
            PopulationData populationData = new PopulationData();
            AddData<PopulationData>(populationData.name, populationData);
            TrafficData trafficData = new TrafficData();
            AddData<TrafficData>(trafficData.name, trafficData);
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

        #endregion

        #region 数据库轮询操作
        IEnumerator DataUpdater()
        {
            while (true)
            {
                foreach (KeyValuePair<string, BaseData> kvp in dataCacheDic)
                {
                    DataHelper<BaseData>(kvp.Value);
                    yield return new WaitForSeconds(updateInterval);
                }
            }

        }


        private void DataHelper<T>(T data) where T : BaseData
        {
            data.LoadData();
        }
        #endregion
    }
}

