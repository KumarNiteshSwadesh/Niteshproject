using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileRepairSuperMarket.Helpers;
using System.Globalization;

namespace MobileRepairSuperMarket.Models
{
    public class DataLayer
    {
        public static byte[] pImage;

        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            int a = 0;
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@img")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
            }
            con.Open();

            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }

        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {
                Property p = new Property();
                SqlConnection con = new SqlConnection(p.Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                DataSet ds = null;
                return ds;
            }

        }
        public DataSet MyDs_Process(String Storp)
        {

            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }

        public DataSet FetchQuery(String Qry)
        {
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;
        }
        public int ExecNonQuery(String Qry)
        {
            int a = 0;
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }

        public DataSet getData(string Query)
        {
            Property p = new Property();
            DataSet AdvList = new DataSet();
            SqlConnection cn = new SqlConnection(p.Con);
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(Query, cn);
            sda.Fill(AdvList);
            cn.Dispose();
            cn.Close();
            return AdvList;
        }

        public string runQuery(string cmd)
        {
            Property p = new Property();
            SqlDataAdapter dab = new SqlDataAdapter(cmd, p.Con);
            DataSet dsb = new DataSet();
            dsb.Clear();
            dab.Fill(dsb);
            GC.SuppressFinalize(p);
            GC.SuppressFinalize(dab);
            if (dsb.Tables[0].Rows.Count > 0)
            {
                return dsb.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }
        //public int runQrydt(string cmd)
        //{
        //    Property p = new Property();
        //    int result;
        //    SqlConnection con = new SqlConnection(p.Con);
        //    SqlCommand cmd1 = new SqlCommand(cmd, con);
        //    cmd1.CommandType = CommandType.Text;
        //    if (con.State == ConnectionState.Open)
        //    { con.Close(); }

        //    con.Open();
        //    result = cmd1.ExecuteNonQuery();
        //    con.Dispose();
        //    con.Close();
        //    return result;
        //}

        public void runQry(string cmd)
        {
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd1 = new SqlCommand(cmd, con);
            cmd1.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Open)
            { con.Close(); }

            con.Open();
            cmd1.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public DataSet runQueryDs(string cmd)
        {
            Property p = new Property();
            SqlDataAdapter dab = new SqlDataAdapter(cmd, p.Con);
            DataSet ds = new DataSet();
            ds.Clear();
            dab.Fill(ds);
            GC.SuppressFinalize(p);
            GC.SuppressFinalize(dab);

            return ds;
        }
        //----------------------Data Access Layer Work---------------------------

        EncryptDecrypt enc = new EncryptDecrypt();

        public DataSet FETCH_LOGIN_DETAILS(Property p)
        {
            try
            {
                string[] paname = { "@EmailID", "@Password" };
                string[] pvalue = { p.EmailID, enc.Encrypt(p.Password) };
                return Ds_Process("FETCH_LOGIN_DETAILS", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public DataSet FETCH_CONDITIONAL_QUERY(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@onTable" };
                string[] pvalue = { p.Condition1, p.Condition2, p.Condition3, p.onTable };
                return Ds_Process("FETCH_CONDITIONAL_QUERY", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_USER_REGISTRATION(Property p)
        {
            try
            {
                string[] paname = { "@UserId", "@FirstName", "@MiddleName", "@LastName", "@EmailId", "@Password", "@Gender", "@Zip", "@City", "@State", "@Country", "@ContactNo", "@AlterContactNo", "@Address", "@DOB",  "@ProfilePic", "@Status" };
                string[] pavalue = { p.UserId, p.FirstName, p.MiddleName, p.LastName, p.EmailID, p.Password, p.Gender, p.ZipCode, p.City, p.State, p.Country, p.ContactNo, p.AltContactNo, p.Address,  p.DOB,  p.profilepic, p.Status };
                return Int_Process("INSERT_UPDATE_USER_REGISTRATION", paname, pavalue);
            }
            catch
            {
                throw;
            }
        }
    }
}