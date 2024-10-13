using System.Data;

namespace DataManagerModule
{
    [System.Serializable]
    public class PopulationData:BaseData
    {
        public int populationSize;
        public int floatingPopulation;
        public int migrantWorkers;
        public int highlyEduPopulation;
        public int child;

        public PopulationData()
        {
            name = "PopulationData";
            queryCommand = "SELECT population_size,floating_population_size,migrant_workers,highly_educate_population,child_population FROM people_info WHERE id = (SELECT MAX(id) FROM people_info)";
        }

        public override void ProcessData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    populationSize = ObjectParseInt(row["population_size"]);
                    floatingPopulation = ObjectParseInt(row["floating_population_size"]);
                    migrantWorkers = ObjectParseInt(row["migrant_workers"]);
                    highlyEduPopulation = ObjectParseInt(row["highly_educate_population"]);
                    child = ObjectParseInt(row["child_population"]);
                }
            }
        }
    }
}