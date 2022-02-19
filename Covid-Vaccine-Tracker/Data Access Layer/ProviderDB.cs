using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// must include these using statements below to access other namespaces in project 
// and to use dapper and sql 
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;


namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class ProviderDB
    {
        public static string GetConnection()
        {
            string conStr = null;

            try
            {
                conStr = DBConnector.GetConnectionString();
            }
            catch (Exception ex)
            { throw ex; }

            return conStr;
        }
        public static HealthCareProvider GetProvider(string Uname)
        {
            HealthCareProvider provider = new HealthCareProvider();
            string procedure = "[SpFindProvider]";
            var parameter = new { usrname = Uname };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    provider = db.QuerySingle<HealthCareProvider>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return provider;
        }

    }

}
