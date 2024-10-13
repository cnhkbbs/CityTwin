using System.Data;

namespace DataManagerModule
{
    [System.Serializable]
    public class EnviromentData:BaseData
    {
        public int totalScore;
        public int parkScore;
        public int govScore;
        public int hospitalScore;
        public int schoolScore;

        public EnviromentData()
        {
            name = "EnviromentData";
            queryCommand = "SELECT total_score,park_score,gov_score,hospital_score,school_score FROM environment_info WHERE id = (SELECT MAX(id) FROM environment_info)";
        }

        public override void ProcessData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    totalScore = ObjectParseInt(row["total_score"]);
                    parkScore = ObjectParseInt(row["park_score"]);
                    govScore = ObjectParseInt(row["gov_score"]);
                    hospitalScore = ObjectParseInt(row["hospital_score"]);
                    schoolScore = ObjectParseInt(row["school_score"]);
                }
            }
        }
    }
}