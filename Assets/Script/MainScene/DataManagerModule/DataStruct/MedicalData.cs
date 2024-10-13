using System.Data;

namespace DataManagerModule
{
    [System.Serializable]
    public class MedicalData : BaseData
    {
        public int seeking;
        public int seekMax;
        public int ambulanceTotal;
        public int ambulanceRunning;

        public MedicalData()
        {
            name = "MedicalData";
            queryCommand = "SELECT seeking,seek_max,ambulance_total,ambulance_running FROM medical_info WHERE id = (SELECT MAX(id) FROM medical_info)";
        }

        public override void ProcessData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    seeking = ObjectParseInt(row["seeking"]);
                    seekMax = ObjectParseInt(row["seek_max"]);
                    ambulanceTotal = ObjectParseInt(row["ambulance_total"]);
                    ambulanceRunning = ObjectParseInt(row["ambulance_running"]);
                }
            }
        }
    }
}