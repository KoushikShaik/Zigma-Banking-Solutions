using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AccountDetailsBAL
    {


        public int CustomerID { get; set; }
        public long AccountNumber { get; set; }
        public string BranchName { get; set; }
        public double CurrentBalance { get; set; }
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Address { get; set; }
        public string Accountstatus { get; set; }
        public long MobileNumber { get; set; }
        public string NetBankingPassword { get; set; }
        public string TransactionPassword { get; set; }
        public string IFSC_Code { get; set; }
        

    }

    public class Beneficiary
    {
        public string BeneficiaryName { get; set; }
        public string BeneficiaryIFSC { get; set; }
        public long AccountNumber { get; set; }
        public string Status { get; set; }

    }
    public class Transcation
    {
        public int CustomerId_Sender { get; set; }
        public int CustomerId_Recipient { get; set; }
        public long AccountNo_Sender { get; set; }
        public long AccountNo_Recipient { get; set; }
        public string RecipientName { get; set; }
        public long Amount { get; set; }
        public string TransactionType { get; set; }
        public string IFSC_code { get; set; }
        public DateTime Date { get; set; }

    }

    }

