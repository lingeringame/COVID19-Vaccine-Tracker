// Covid Vaccine Tracker - VaccineRecordDB class
// By Zachary Palmer 2/16/2022
///<summary>
/// This class is part of the Data Access Layer it connects with a Database
/// It only accesses the Vaccine Records table. Since there are two types of users with different privlages
/// There querys that return joins result rows so this class uses VaccineRecord and Identifying_VaccineRecord classes
/// to display the correct data to the correct data
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Need using statements for project namespaces and other libraries
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class VaccineRecordDB
    {
        public static string GetConnection()
        {
            // GetConnection retrieves the connection string from the app.config file
            string conStr = null;

            try
            {
                conStr = DBConnector.GetConnectionString();
            }
            catch (Exception ex)
            { throw ex; }

            return conStr;
        }
        // The next 3 methods use the Identifying_VaccineRecord class for the Provider views
        // They do not perform any CRUD. Only methods that use VaccineRecord performs crud or CDC views
        public static List<Identifying_VaccineRecord> GetVaccineRecords_Identifying()
        {
            // Create a list to hold the rows from the database
            // using dapper each object will map to a row from the query
            List<Identifying_VaccineRecord> vaxRecords = new List<Identifying_VaccineRecord>();
            // Specify stored procedure to use
            string procedure = "[SpGetAllVaccines_ProviderView]";

            // Use a try catch block to catch any errors
            try
            {
                // Get the connection string to the database
                string conStr = GetConnection();

                // Using statement connect to the database when the using statement ends database connection will close
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    // assign the rows returned from query to the list of objects
                    // include the procedure and commandType
                    vaxRecords = db.Query<Identifying_VaccineRecord>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            // catch errors and throw back to calling code
            catch(Exception ex)
            { throw ex; }

            // Return the list of objects 
            return vaxRecords;
        }
        public static List<Identifying_VaccineRecord> GetVaccineRecord_Identifying(string patientId)
        {
            // Create a IdentifyingVaxRecord object list to hold the row(s) returned
            // since a patient can have multiple vaccines need a list incase nultiple rows returned
            List<Identifying_VaccineRecord> vaxRecord = new List<Identifying_VaccineRecord>();
            
            // Specify the stored procedure to use
            string procedure = "[SpGetPatientVaccines_ProviderView]";
            // Specify the parameter **Note parameter name must match the name  in procedure
            // ie pId is the name of the parameter in the stored procedure 
            var parameter = new { pId = patientId };

            // Handle any errors
            try
            {
                // Get connection string to database
                string conStr = GetConnection();

                // Using statement will open and close connection to database
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    // Assign vaxRecord object to the row returned from database
                    vaxRecord = db.Query<Identifying_VaccineRecord>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            // Thorw any errors back to calling code
            catch(Exception ex)
            { throw ex; }

            // Return list of objects
            return vaxRecord;
        }
        public static List<Identifying_VaccineRecord> GetVaxSeries_Identifying(string seriesStatus)
        {
            // Yes, No, or Unknown will be passed in and then rows with VaxSereis complete equal to that value
            // will be returned 
            List<Identifying_VaccineRecord> vaxRecord = new List<Identifying_VaccineRecord>();

            // Procedure to use
            string procedure = "[SpGetSeries_ProviderView]";
            // Parameters of procedure **Note the parameter name must match name in database
            // ie seriesValue is the name of the parameter in the stored procedure
            var parameter = new { seriesValue = seriesStatus };

            // Handler errors
            try
            {
                // Get database connection string
                string conStr = GetConnection();

                // connect and disconect from database
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    // Assign list to rows returned 
                    // pass in the procedure, parameter and procedure
                    vaxRecord = db.Query<Identifying_VaccineRecord>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            // Return list
            return vaxRecord;
        }
        // The methods below are used for CRUD and the Cdc vaccine records and use the Vaccine Record class
        private static bool AddVaccine(VaccineRecord vaxEvent)
        {
            bool isSuccess = default;
            int rowsAffected;
            string procedure = "[SpAddVaccineRecord]";

            return isSuccess;

        }
        private static List<VaccineRecord> GetVaccineRecords_DeIdentified()
        {
            List<VaccineRecord> vaxRecords = new List<VaccineRecord>();
            string procedure = "[SpGetVaccineRecords]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    vaxRecords = db.Query<VaccineRecord>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return vaxRecords;
        }

    }
}
