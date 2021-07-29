using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CatagoryExercise
{
    public class Crud
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        Catagory ca = new Catagory();
        

        public string InsertCatagory(Catagory ca)
        {
            String message = "Successfully Inserted";

            SqlCommand cmd = new SqlCommand("insert into NewCatagory (CategName,[Desc]) values ('" + ca.CategName + "', '" + ca.Desc + "')", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                return message;

            }
            catch(Exception ex)
            {
                message = "some Error is ecountered here " + ex.Message;
                return message;
            }

            finally
            {
                con.Close();
            }
        }
        public DataTable GetCatagory()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from NewCatagory", con);

            da.Fill(dt);
            return dt;
        }

        public string DeletePatient(int id)
        {
            string message = "Deletion Successfull";
            SqlCommand cmd = new SqlCommand("Delete from Patients where id = '" + id + "'", con);
            try
            {


                con.Open();
                cmd.ExecuteNonQuery();
                return message;

            }

            catch (Exception ex)
            {
                message = "Server error is  " + ex.Message;
                return message;

            }

            finally
            {
                con.Close();
            }
        }
    }
}