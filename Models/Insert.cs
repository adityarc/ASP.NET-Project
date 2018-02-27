
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication2.Models
{
    class Insert
    {
        
        public static int createorder(string cid,int pid,string add,double bill)
        {
           
            string oid = Constraints.generateOrderID();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("insertintoorders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", oid);
            cmd.Parameters.AddWithValue("@CustomerID", cid);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            cmd.Parameters.AddWithValue("@delivery", add);
            cmd.Parameters.AddWithValue("@billamt", bill);
            int result = cmd.ExecuteNonQuery();
            return result;

            


        }
        //to check if the phone number or email already exists in the data base or not
        public static int exists(string phone,string email)
        {
            int res = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("select * from CustomerDetails where MobileNo = @Phone and EmailID = @email", con);
            
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);

            res = cmd.ExecuteNonQuery();
            return res;
        }
        public static int AddData(DateTime RegDate,string CustomerID,string CustomerName,string City,string MobileNo,string Address,string Email,string Pincode,string username,string password)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("uspinsemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@regdate", RegDate);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@Pcode", Pincode);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            int result = cmd.ExecuteNonQuery();
            return result;
        }
        public static int ProductAddData(string ProductName, byte[] ProductImage, double Price,int Quantity)
        {


            int res = 0;

            //double Price 
            //int Quantity = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("uspinsProduct1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@ProductImage", ProductImage);

            res = cmd.ExecuteNonQuery();
                

            return res;
        }
        public  DataTable DisplayAllProduct()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CGICon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select ProductId,ProductName,ProductImage from Product", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (rdr.HasRows)
            {
                dt.Load(rdr);
            }
            return dt;
        }
    }
}
