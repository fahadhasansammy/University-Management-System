using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS
{
    public class Result
    {
        public DataTable Data { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
    internal class DbHelper
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=KING\SQLEXPRESS;Initial Catalog=UMS;Integrated Security=True;TrustServerCertificate=True");
        public static Result GetQueryData(String query)
        {
            var result = new Result();
            try
            {

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataSet ds = new DataSet(); //dynamic  datatype 

                sda.Fill(ds);
                DataTable dt = ds.Tables[0]; //0th index table

                con.Close();
                result.Data = dt;

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public static Result ExecuteNonResultQuery(String query)
        {
            var result = new Result();
            try
            {

                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
                

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
