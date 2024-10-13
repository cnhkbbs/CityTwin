using System.Data;
using System;
namespace DataManagerModule
{
    [System.Serializable]
    public class BaseData
    {
        public string name;
        public string queryCommand;

        public void LoadData() 
        {
            try
            {
                DataSet data = SqlAccess.ExecuteQuery(queryCommand);
                if (data == null) return;
                ProcessData(data.Tables[0]);
            }
            catch (Exception e)
            {
                throw new Exception("Error in flash" + name + e);
            }
        }

        public virtual void ProcessData(DataTable dt) { }

        protected int ObjectParseInt(object o)
        {
            int i;
            try
            {
                i = int.Parse(o.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error in ObjectParseInt:" + e);
            }
            return i;
        }
    }
}