using Config;
using Common;
namespace DataManagerModule
{
    public class SqlDataLoader:SingletonBase<SqlDataLoader>
    {
        protected override void Awake()
        {
            SqlConfig sqlConfig = new SqlConfig();
            SqlAccess sql = new SqlAccess(sqlConfig.server, sqlConfig.port, sqlConfig.user, sqlConfig.password, sqlConfig.database);
        }


    }
}