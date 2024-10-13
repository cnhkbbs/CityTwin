using UnityEngine;
using DataManagerModule;
public class DataTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnergyData data = DataManager.Instance.GetDataByName<EnergyData>("EnergyData");
            print(data.enterprise);
        }
    }
}
