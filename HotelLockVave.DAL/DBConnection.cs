using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.DAL
{
    public class DBConnection

    {      
        
        public static string connectionString = @"Data Source =64.202.191.110;Initial Catalog = HotelLockTestjig; User Id=sa;Password=Alpha%03;Trusted_Connection=False;MultipleActiveResultSets=true;";//Development
        //public static string connectionString = @"Data Source =64.202.191.110;Initial Catalog =   HotelLocksVave_Staging_DB; User Id=sa;Password=Alpha%03;Trusted_Connection=False;MultipleActiveResultSets=true;";//Staging
        //public static string connectionString = @"Data Source =64.202.191.110;Initial Catalog = HotelLocksVave_QA; User Id=sa;Password=Alpha%03;Trusted_Connection=False;MultipleActiveResultSets=true;";//QA

        public IDbConnection connection;
        public DBConnection()
        {
            connection = new SqlConnection(connectionString);
        }
        public void CloseConnection()
        {
            connection.Dispose();
            //
        }       
    }
}
