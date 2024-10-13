using System.Data;
namespace DataManagerModule
{
    [System.Serializable]
    public class EnergyData:BaseData
    {
        public int enterprise;
        public int resident;
        public int produce;
        public int used;
        public EnergyData()
        {
            name = "EnergyData";
            queryCommand = "SELECT enterprise,resident,produce,used FROM energy_info WHERE id = (SELECT MAX(id) FROM energy_info)";
        }

        public override void ProcessData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    enterprise = ObjectParseInt(row["enterprise"]);
                    resident = ObjectParseInt(row["resident"]);
                    produce = ObjectParseInt(row["produce"]);
                    used = ObjectParseInt(row["used"]);
                }
            }
        }
    }
}