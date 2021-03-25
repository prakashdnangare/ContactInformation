using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformationCore.Data
{
    public class Common
    {
        public static string GetConnetionString()
        {
            // Initialize the connection string builder for the underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = "";//serverName;
            sqlBuilder.InitialCatalog = "ContactInfoDB";//dbName;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.UserID = "";//userName;
            sqlBuilder.Password = "";//password;
            sqlBuilder.MultipleActiveResultSets = true;

            return sqlBuilder.ConnectionString;
        }
    }
}

