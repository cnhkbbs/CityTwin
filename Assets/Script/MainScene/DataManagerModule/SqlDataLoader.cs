using Config;

namespace DataManagerModule
{
    public class SqlDataLoader
    {
        public SqlDataLoader()
        {
            SqlConfig sqlConfig = new SqlConfig();
            SqlAccess sql = new SqlAccess(sqlConfig.server, sqlConfig.port, sqlConfig.user, sqlConfig.password, sqlConfig.database);
        }


    }
}