using UnityEngine;
using DataManagerModule;
using Config;
using System.Data;
public class DataTest : MonoBehaviour
{
    void Start()
    {
        SqlConfig sqlConfig = new SqlConfig();
        SqlAccess sql = new SqlAccess(sqlConfig.server, sqlConfig.port, sqlConfig.user, sqlConfig.password, sqlConfig.database);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DataSet data = SqlAccess.ExecuteQuery("SELECT * FROM energy_info");
            if (data != null && data.Tables.Count > 0)
            {
                DataTable dataTable = data.Tables[0];

                foreach (DataRow row in dataTable.Rows)
                {
                    string columnName = "enterprise";
                    object value = row[columnName];

                    Debug.Log($"Column '{columnName}' has value '{value}'");
                } 
            }
            else
            {
                Debug.LogError("No data or tables found in the dataset.");
            }
        }
    }
}
