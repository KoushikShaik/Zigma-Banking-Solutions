using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BusinessLogicLayer;

namespace DataAccessLayer
{
    public class Admin
    {
        
        //1.Admin has to provide these fields
        public bool InsertCustomerRecord(AccountDetailsBAL Custdata)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            string str = "Insert into AccountDetails values(@CustID,@Accno,@Branch,@nbpwd)";

            //string str = "Insert into AccountDetails values(@CustID,@Accno,@Branch,@Cbal,@name,@email,@address,@status,@mobno,@nbpwd,@tspwd,@dob,@gender)";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.Parameters.AddWithValue("@CustID", Custdata.CustomerID);
            cmd.Parameters.AddWithValue("@Accno", Custdata.AccountNumber);
            cmd.Parameters.AddWithValue("@Branch", Custdata.BranchName);
            //cmd.Parameters.AddWithValue("@Cbal", Custdata.CurrentBalance);
            //cmd.Parameters.AddWithValue("@name", Custdata.Name);
            //cmd.Parameters.AddWithValue("@email", Custdata.Email);
            //cmd.Parameters.AddWithValue("@mobno", Custdata.MobileNumber);
            //cmd.Parameters.AddWithValue("@address", Custdata.Address);
            //cmd.Parameters.AddWithValue("@status", Custdata.Accountstatus);
            cmd.Parameters.AddWithValue("@nbpwd", Custdata.NetBankingPassword);
            //cmd.Parameters.AddWithValue("@tspwd", Custdata.TransactionPassword);
            //cmd.Parameters.AddWithValue("@dob", Custdata.DOB);
            //cmd.Parameters.AddWithValue("@gender", Custdata.Gender);

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool stats = false;
            if (i >= 0)
            {
                stats = true;
            }
            cn.Close();
            return stats;
        }
        public bool Admin_Login(int id, string pass)
        {
            if(id==2369190 && pass=="2369190" )
            {

                return true;
             
            }
            else
            {
                return false;
            }
            
        }

    }
}
