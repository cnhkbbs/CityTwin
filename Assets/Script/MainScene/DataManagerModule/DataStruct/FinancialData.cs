using System.Data;

namespace DataManagerModule
{
    [System.Serializable]
    public class FinancialData:BaseData
    {
        public int incomeTotal;
        public int expenditureTotal;
        public int education;
        public int medical;
        public int society;
        public int other;

        public FinancialData()
        {
            name = "FinancialData";
            queryCommand = "SELECT income_total,expenditure_total,education,medical,society,other FROM financial_info WHERE id = (SELECT MAX(id) FROM financial_info)";
        }

        public override void ProcessData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    incomeTotal = ObjectParseInt(row["income_total"]);
                    expenditureTotal = ObjectParseInt(row["expenditure_total"]);
                    education = ObjectParseInt(row["education"]);
                    medical = ObjectParseInt(row["medical"]);
                    society = ObjectParseInt(row["society"]);
                    other = ObjectParseInt(row["other"]);
                }
            }
        }
    }
}