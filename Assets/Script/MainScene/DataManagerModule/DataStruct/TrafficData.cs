using System.Data;

namespace DataManagerModule
{
    [System.Serializable]
    public class TrafficData:BaseData
    {
        public int busTotal;
        public int busRunning;
        public int metroTotal;
        public int metroRunning;

        public TrafficData() 
        {
            name = "TrafficData";
            queryCommand = "SELECT bus_total,bus_running,metro_total,metro_running FROM traffic_info WHERE id = (SELECT MAX(id) FROM traffic_info)";
        }

        public override void ProcessData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    busTotal = ObjectParseInt(row["bus_total"]);
                    busRunning = ObjectParseInt(row["bus_running"]);
                    metroRunning= ObjectParseInt(row["metro_running"]);
                    metroTotal = ObjectParseInt(row["metro_total"]);
                }
            }
        }
    }
}