using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;

namespace DataAccessLayer
{
    public class AccountDetailsDAL
    {
        // CustomerEdits his profile

        public bool UpdateCustomerRecord(AccountDetailsBAL Custdata)
        {
            bool stats = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", cn);
            cmd.Parameters.AddWithValue("@Name", Custdata.Name);
            cmd.Parameters.AddWithValue("@MobileNumber", Custdata.MobileNumber);
            cmd.Parameters.AddWithValue("@Address", Custdata.Address);
            cmd.Parameters.AddWithValue("@NetBankingPassword", Custdata.NetBankingPassword);



            cmd.Parameters.AddWithValue("@CustomerID", Custdata.CustomerID);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                stats = true;
            }
            cn.Close();
            return stats;
        }

        //2.Customer will register using admin provided custid 
        public bool RegisterCustomer(AccountDetailsBAL Custdata)
        {
            bool stats = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_RegisterDetails", cn);
            cmd.Parameters.AddWithValue("@Name", Custdata.Name);
            cmd.Parameters.AddWithValue("@Email", Custdata.Email);
            cmd.Parameters.AddWithValue("@MobileNumber", Custdata.MobileNumber);
            cmd.Parameters.AddWithValue("@Address", Custdata.Address);
            cmd.Parameters.AddWithValue("@NetBankingPassword", Custdata.NetBankingPassword);
            cmd.Parameters.AddWithValue("@tspwd", Custdata.TransactionPassword);
            cmd.Parameters.AddWithValue("@dob", Custdata.DOB);
            cmd.Parameters.AddWithValue("@gender", Custdata.Gender);


            cmd.Parameters.AddWithValue("@CustomerID", Custdata.CustomerID);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                stats = true;
            }
            cn.Close();
            return stats;
        }

        // Show details to customer
        public List<AccountDetailsBAL> ShowCustList()
        {
            List<AccountDetailsBAL> CustList = new List<AccountDetailsBAL>();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from AccountDetails", cn);

            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                AccountDetailsBAL customer = new AccountDetailsBAL();
                customer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                customer.AccountNumber = Convert.ToInt32(rdr["AccountNumber"]);
                customer.BranchName = rdr["BranchName"].ToString();

                customer.CurrentBalance = Convert.ToDouble(rdr["CurrentBalance"]);

                customer.Name = rdr["Name"].ToString();
                customer.Email = rdr["Email"].ToString();
                customer.Address = rdr["Address"].ToString();
                customer.Accountstatus = rdr["Accountstatus"].ToString();
                customer.MobileNumber = rdr["MobileNumber"].ToString();
                customer.DOB = Convert.ToDateTime(rdr["DOB"].ToString());
                customer.Gender = rdr["Gender"].ToString();


                CustList.Add(customer);
            }
            cn.Close();

            return CustList;

        }

        //public bool deleteCustomerRecord(int CustomerID)
        //{
        //    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
        //    string str = "Delete from AccountDetails where CustomerID=@CustomerID";
        //    SqlCommand cmd = new SqlCommand(str, cn);
        //    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
        //    cn.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    bool stats = false;
        //    if (i >= 1)
        //    {
        //        stats = true;
        //    }
        //    cn.Close();
        //    return stats;
        //}


        // Customer WIll add the beneficiary
        public bool AddBeneficiary(BeneficiaryDetailsBAL Benedata)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            string str = "Insert into Beneficiary values(@bname,@bifsc,@baccno,@bstatus)";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.Parameters.AddWithValue("@bname", Benedata.BeneficiaryName);
            cmd.Parameters.AddWithValue("@bifsc", Benedata.BeneficiaryIFSC);
            cmd.Parameters.AddWithValue("@baccno", Benedata.BeneficiaryAccountNo);
            cmd.Parameters.AddWithValue("@bstatus", Benedata.Status);

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


        // Customer Will get the beneficiary List
        public List<BeneficiaryDetailsBAL> ShowBeneficiaryList()
        {
            List<BeneficiaryDetailsBAL> Benelist = new List<BeneficiaryDetailsBAL>();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Beneficiary", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BeneficiaryDetailsBAL beneficiary = new BeneficiaryDetailsBAL();
                beneficiary.BeneficiaryAccountNo = Convert.ToInt32(dr["BeneficiaryAccountNo"]);
                beneficiary.BeneficiaryName = dr["BeneficiaryName"].ToString();
                beneficiary.BeneficiaryIFSC = dr["BeneficiaryIFSC"].ToString();
                beneficiary.Status = dr["Status"].ToString();


                Benelist.Add(beneficiary);


            }
            cn.Close();
            return Benelist;
        }


        // Customer will know the transaction
        public List<TransactionBAL> ShowTransactionList(int custid)
        {
            List<TransactionBAL> Translist = new List<TransactionBAL>();

            SqlConnection cn = new SqlConnection("Data Source=WKSPUN05GTR0826;Initial Catalog=Banking;Integrated Security=True");
            //ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Transactions where CustomerId_Sender=@custid", cn);
            cmd.Parameters.AddWithValue("@custid", custid);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TransactionBAL trans = new TransactionBAL();
                trans.CustomerId_Sender = Convert.ToInt32(dr[0]);
                trans.CustomerId_Recipient = Convert.ToInt32(dr[1]);
                trans.AccountNo_Sender = Convert.ToInt32(dr[2]);
                trans.AccountNo_Recipient = Convert.ToInt32(dr[3]);
                trans.RecipientName = dr[4].ToString();
                trans.Amount = Convert.ToInt32(dr[5]);
                trans.TransactionType = dr[6].ToString();
                trans.IFSC_code = dr[7].ToString();
                trans.Date = Convert.ToDateTime(dr[8]);

                Translist.Add(trans);


            }
            cn.Close();
            return Translist;
        }

        // Customer does the transaction
        public bool AddTransaction(TransactionBAL transdata)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            string str = "Insert into Transaction values(@scid,@rcid,@saccno,@raccno,@rname,@amount,@ttype,@ifsc,@date)";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.Parameters.AddWithValue("@scid", transdata.CustomerId_Sender);
            cmd.Parameters.AddWithValue("@rcid", transdata.CustomerId_Recipient);
            cmd.Parameters.AddWithValue("@saccno", transdata.AccountNo_Sender);
            cmd.Parameters.AddWithValue("@raccno", transdata.AccountNo_Recipient);
            cmd.Parameters.AddWithValue("@rname", transdata.RecipientName);
            cmd.Parameters.AddWithValue("@amount", transdata.Amount);
            cmd.Parameters.AddWithValue("@ttype", transdata.TransactionType);
            cmd.Parameters.AddWithValue("@ifsc", transdata.IFSC_code);
            cmd.Parameters.AddWithValue("@date", transdata.Date);



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


        // Customer will get this method in homepage
        public double ShowCurrentBalance(int id)
        {
            //List<AccountDetailsBAL> CustList = new List<AccountDetailsBAL>();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select CurrentBalance from AccountDetails where CustomerID=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            AccountDetailsBAL customer = new AccountDetailsBAL();
            //customer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);


            customer.CurrentBalance = Convert.ToDouble(rdr["CurrentBalance"]);
            //customer.Accountstatus = rdr["Accountstatus"].ToString();

            cn.Close();
            return Convert.ToDouble(customer.CurrentBalance);

        }

        // Customer will get the email validation
        public void SendEmail(string emailbody)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select Email from AccountDetails where CustomerID = @id", cn);
           
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            MailMessage mailmessage = new MailMessage("zigmabankingsolutions@gmail.com", dr.ToString());
            mailmessage.Subject = "OTP Validation";
            mailmessage.Body = emailbody;
            SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587);
            smtpclient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "zigmabankingsolutions@gmail.com",
                Password = "zigmanir123"
            };
            smtpclient.EnableSsl = true;
            smtpclient.Send(mailmessage);
        }


        // This method will access this method for email verification
        public void mail_verify()
        {
            SendEmail("Dear Customer , OTP to register your Email to your bank account is  ");
        }

        public void Customer_Login()
        {

        }
    }
}




