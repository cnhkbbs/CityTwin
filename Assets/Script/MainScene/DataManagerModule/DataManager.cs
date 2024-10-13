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

        #region ������
        public DataManager() 
        { 
            dataCacheDic = new Dictionary<string, BaseData>();
        }
        // ��ʼ�������ֵ�
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

        #endregion

        #region ���ݿ���ѯ����
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

