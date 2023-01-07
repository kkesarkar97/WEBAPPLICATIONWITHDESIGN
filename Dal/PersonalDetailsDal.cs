using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Dal
{
    
    public class PersonalDetailsDal
    {
        PersonalDetails Personal = new PersonalDetails();
        string strCon = ConfigurationManager.ConnectionStrings["DBCS"].ToString();

        public int SaveData(PersonalDetails Personal)
        {
            int NoOfAffectedRows = 0;
            try
            {
                SqlConnection conn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("InsertDataPersonal", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fname", Personal.GetFName);
                cmd.Parameters.AddWithValue("@Mname", Personal.GetMName);
                cmd.Parameters.AddWithValue("@Lname", Personal.GetLName);
                cmd.Parameters.AddWithValue("@EmailId", Personal.GetEmailId);
                cmd.Parameters.AddWithValue("@Phno", Personal.GetPhoneNo);
                cmd.Parameters.AddWithValue("@dob", Personal.GetDOB);
                cmd.Parameters.AddWithValue("@address", Personal.GetAddress);
                cmd.Parameters.AddWithValue("@State", Personal.GetState);
                cmd.Parameters.AddWithValue("@Country", Personal.GetCountry);
                cmd.Parameters.AddWithValue("@gender", Personal.GetGender);

                conn.Open();
                NoOfAffectedRows = cmd.ExecuteNonQuery();
                conn.Close();
                return NoOfAffectedRows;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return NoOfAffectedRows;
            }
            
        }

        public DataTable BindSearchDropdown()
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("BindSearchDropdown", conn);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetInfoByID(int UserId)
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("GetDataByID", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public int UpdateData(PersonalDetails Personal)
        {
            int NoOfAffectedRows = 0;
            try
            {
                SqlConnection conn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("UpdateDataPersonal", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", Personal.IntId);
                cmd.Parameters.AddWithValue("@Fname", Personal.GetFName);
                cmd.Parameters.AddWithValue("@Mname", Personal.GetMName);
                cmd.Parameters.AddWithValue("@Lname", Personal.GetLName);
                cmd.Parameters.AddWithValue("@EmailId", Personal.GetEmailId);
                cmd.Parameters.AddWithValue("@PhoneNo", Personal.GetPhoneNo);
                cmd.Parameters.AddWithValue("@Dob", Personal.GetDOB);
                cmd.Parameters.AddWithValue("@Address", Personal.GetAddress);
                cmd.Parameters.AddWithValue("@State", Personal.GetState);
                cmd.Parameters.AddWithValue("@Country", Personal.GetCountry);
                cmd.Parameters.AddWithValue("@Gender", Personal.GetGender);

                conn.Open();
                NoOfAffectedRows = cmd.ExecuteNonQuery();
                conn.Close();
                return NoOfAffectedRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NoOfAffectedRows;
            }

        }

        public int DeleteData(PersonalDetails Personal)
        {
            int NoOfAffectedRows = 0;
            try
            {
                SqlConnection conn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("DeletePersonalData", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", Personal.IntId);
                
                conn.Open();
                NoOfAffectedRows = cmd.ExecuteNonQuery();
                conn.Close();
                return NoOfAffectedRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NoOfAffectedRows;
            }

        }

        public DataTable GetAllData()
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("GetAllPersonalData", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public int NumberOfRecords()
        {
            int NoOfRecords = 0;
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("Select Count(*) from PersonalDetails", conn);
            conn.Open();
            NoOfRecords = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return NoOfRecords;
        }

        public DataTable BindCountry()
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("BindCountry", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable BindState(int Id)
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("BindStateById", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public int GetStateId(string Country)
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("GetCountryId", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CName", Country);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            int Id = Convert.ToInt32(dt.Rows[0]["CountryId"].ToString());

            return Id;
            //return dt;
        }

        public DataTable ExportData()
        {
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("GetAllPersonalData", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
