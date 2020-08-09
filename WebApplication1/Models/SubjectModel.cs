using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entity;

namespace WebApplication1.Models
{
    public class SubjectModel :BaseModel
    {
        public Subject objsubject { get; set; } 
        public List<Subject> objListSubject { get; set; }
        public void GetData()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "GetAllSubject",
                    CommandType = CommandType.StoredProcedure
                };
                // add parameter
             //   objCmd.Parameters.Add("@ParameterName", SqlDbType.NVarChar, 20).Value = "";
                // end 
                // connect
                try
                {
                    // Open connnection
                    objConnect.Open();
                    //Get data from database
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.objListSubject = BaseModel.ConvertDataTable<Subject>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {


                }
                finally
                {
                    objConnect.Close();
                }
            }

        }
    }
}
