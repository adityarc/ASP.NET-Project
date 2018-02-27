using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication2.Models
{
    class Constraints
    {
        //function to generate order ID
        public static string generateOrderID()
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("select OrderID from Orders order by OrderID desc", con);
            string yyyy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            string dd = DateTime.Now.Date.ToString();
            if (con.State == ConnectionState.Closed)
                con.Open();
            string fullid = "";
            SqlDataReader dr = cmd.ExecuteReader(); 
            if (dr.HasRows)
            {
                dr.Read();
                string id = dr["OrderID"].ToString();
                string oid = id.Substring(0, 2);
                string date = id.Substring(2, 8);
                int orderno = int.Parse(id.Substring(10,3));
                orderno++;
                if (orderno < 10)
                    fullid ="OD" + yyyy + mm + dd + "00" + orderno;
                else if (orderno >= 10 && orderno < 100)
                    fullid = "OD" + yyyy + mm + dd + "0" + orderno;
                else
                    fullid = "OD" + yyyy + mm + dd + "" + orderno;

            }
            else
            {

                fullid = "OD" + yyyy + mm + dd + "001";
            }
            return fullid;
            
        }
        //FUNCTION TO CHECK AVAILABILITY OF PRODUCT
        public static int availability(int pid,int qty)
        {
            int res = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select Quantity from Product where ProductID = @ProductID", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.Parameters.AddWithValue("@ProductID",pid);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.HasRows)
            {
                dt.Read();

                int q = int.Parse(dt[0].ToString());
                if (q >= qty && qty > 0)
                    res = 1;
            }
            return res;
        }
        //FUNCTION TO VALIDATE SIGN IN
        public static int validate(string username,string password)
        {
            int flag = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from CustomerDetails where UserName = @username and [Password] = @password", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = cmd.ExecuteReader(); //You can use ExecuteScalar() to read the first column of first row.
            if (dr.HasRows)
                flag = 1;
            
            return flag;
        }
        //Function to generate patient ID. It gets the last existing record of patient from the database,
        //and increments that value to generate the new patient id.
        public static string GeneratePatientID()
        {
            //Connection created
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            //Define a sql command to find out the maximum value of Customer ID from CustomerDetails table in the database.
            //We will increment the value and then append the appropriate prefix to generate the new ID.
            SqlCommand cmd = new SqlCommand("select CustomerID from CustomerDetails order by CustomerID desc", con);
            //check if the connection is already open or closed. If it is closed, then open it.
            if (con.State == ConnectionState.Closed)
                con.Open();
            string fullid = "";
            SqlDataReader dr = cmd.ExecuteReader(); //You can use ExecuteScalar() to read the first column of first row.
            if (dr.HasRows)
            {
                dr.Read();
                string id = dr["CustomerID"].ToString();
                int newid = int.Parse(id.Substring(1, id.Length - 1));
                newid++;
                if (newid < 10)
                    fullid = "C00" + newid;
                else if (newid >= 10 && newid < 100)
                    fullid = "C0" + newid;
                else 
                    fullid = "C" + newid;
                
            }
            else
            {
                fullid = "C001";
            }
            return fullid;
        }
        //phone number validation
        public static bool IsValidPhone(string Phone)
        {
            var r = new Regex(@"^([0]|\+91)?[789]\d{9}$");
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                return r.IsMatch(Phone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //email validation
        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
