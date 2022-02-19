using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class VaccineEventDB
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
        public static List<Vaccine_EventId> GetVaxEvents()
        {
            List<Vaccine_EventId> events = new List<Vaccine_EventId>();
            string procedure = "[SpGetVaccineEvents]";

            try
            {
                string conStr = GetConnection();
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    events = db.Query<Vaccine_EventId>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return events;
        }
        public static Vaccine_EventId GetVaxEvent(string PPRL)
        {
            Vaccine_EventId vaxEvent = new Vaccine_EventId();
            string procedure = "[SpGetVaccineEvent]";
            var parameter = new { pprl = PPRL };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    vaxEvent = db.QuerySingle<Vaccine_EventId>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return vaxEvent;
        }
        public static List<string> GetVaxEventIds(string PPRL)
        {
            List<string> eventIds = new List<string>();
            string procedure = "[SpGetEventIds]";
            var parameter = new { pprl = PPRL };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    eventIds = db.Query<string>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return eventIds;
        }

    }

}
