using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   public class AccountDetails
    {
        private int CustID;
        public int CustomerID
        {
            get { return CustID; }
            set
            {
                CustID = value;
                if(string.IsNullOrEmpty(CustID.ToString()))
                {
                    throw new Exception("please enter valid customer ID");
                }
            }
        }





        private long AccNo;
        public long AccountNumber
        {
            get { return AccNo; }
            set
            {
                AccNo = value;
                if (string.IsNullOrEmpty(AccNo.ToString()))
                {
                    throw new Exception("not a valid account number ");
                }
            }
        }


        private string Branch;
        public string BranchName
        {
            get { return Branch; }
            set
            {
                Branch = value;
                if (string.IsNullOrEmpty(Branch))
                {
                    throw new Exception("not a valid Branch ");

                }
            }
        }
        private double Cbal;
        public double CurrentBalance
        {
            get { return Cbal; }
            set
            {
                Cbal = value;
                if (string.IsNullOrEmpty(Cbal.ToString()))
                {
                    throw new Exception("not a valid account balance ");
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("not a valid name ");
                }
            }

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("not a valid email ");
                }
            }

        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
               address = value;
                if (string.IsNullOrEmpty(address))
                {
                    throw new Exception("not a valid address ");
                }
            }

        }
        private string status;
        public string Accountstatus
        {
            get { return status; }
            set
            {
                status = value;
                if (string.IsNullOrEmpty(status))
                {
                    throw new Exception("not a valid status ");
                }
            }

        }
        private long mobno;
        public long MobileNumber
        {
            get { return mobno; }
            set
            {
                mobno = value;
                if (string.IsNullOrEmpty(mobno.ToString())
                {
                    throw new Exception("not a valid mobileno ");
                }
            }

        }
        private string nbpwd;
        public string NetBankingPassword
        {
            get { return nbpwd; }
            set
            {
                nbpwd = value;
                if (string.IsNullOrEmpty(nbpwd))
                {
                    throw new Exception("not a valid NetBankingPassword ");
                }
            }

        }
        private string tspwd;
        public string TransactionPassword
        {
            get { return tspwd; }
            set
            {
                tspwd = value;
                if (string.IsNullOrEmpty(tspwd))
                {
                    throw new Exception("not a valid TransactionPassword ");
                }
            }

        }
        private string ifsc;
        public string IFSC_Code
        {
            get { return ifsc; }
            set
            {
                ifsc = value;
                if (string.IsNullOrEmpty(ifsc))
                {
                    throw new Exception("not a valid IFSC code ");
                }
            }

        }

       


    }
  public class BeneficiaryDetails
    {


        private string bname;
        public string BeneficiaryName
        {
            get { return bname; }
            set
            {
                bname = value;
                if (string.IsNullOrEmpty(bname))
                {
                    throw new Exception("not a valid BeneficiaryName ");
                }
            }

        }

        private string  bifsc;
        public string BeneficiaryIFSC
        {
            get { return bifsc; }
            set
            {
                bifsc = value;
                if (string.IsNullOrEmpty(bifsc))
                {
                    throw new Exception("not a valid Beneficiaryifsc ");
                }
            }

        }


        private long accno;
        public long AccountNumber
        {
            get { return accno; }
            set
            {
                accno = value;
                if (string.IsNullOrEmpty(accno.ToString()))
                {
                    throw new Exception("not a valid BeneficiaryName ");
                }
            }

        }


        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                bifsc = value;
                if (string.IsNullOrEmpty(status))
                {
                    throw new Exception("not a valid status ");
                }
            }

        }


    }

    public class Transaction
    {

        private int scid;
        public int CustomerId_Sender
        {
            get { return scid; }
            set
            {
                scid = value;
                if (string.IsNullOrEmpty(scid.ToString()))
                {
                    throw new Exception("not a valid scid ");
                }
            }

        }

        private int rcid;
        public int CustomerId_Recipient
        {
            get { return rcid; }
            set
            {
                rcid = value;
                if (string.IsNullOrEmpty(rcid.ToString()))
                {
                    throw new Exception("not a valid rcid ");
                }
            }

        }
        private long saccno;
        public long AccountNo_Sender
        {
            get { return saccno; }
            set
            {
                saccno = value;
                if (string.IsNullOrEmpty(saccno.ToString()))
                {
                    throw new Exception("not a valid saccno ");
                }
            }

        }
        private long raccno;
        public long AccountNo_Recipient
        {
            get { return raccno; }
            set
            {
                raccno = value;
                if (string.IsNullOrEmpty(raccno.ToString()))
                {
                    throw new Exception("not a valid AccountNo_Recipient ");
                }
            }

        }
        private string rname;
        public string RecipientName
        {
            get { return rname; }
            set
            {
                rname = value;
                if (string.IsNullOrEmpty(rname))
                {
                    throw new Exception("not a valid RecipientName ");
                }
            }

        }
        private long amount;
        public long Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                if (string.IsNullOrEmpty(amount.ToString()))
                {
                    throw new Exception("not a valid status ");
                }
            }

        }
        private string ttype;
        public string TransactionType
        {
            get { return ttype; }
            set
            {
                ttype = value;
                if (string.IsNullOrEmpty(ttype))
                {
                    throw new Exception("not a valid TransactionType ");
                }
            }

        }
        private string ifsc;
        public string IFSC_code
        {
            get { return ifsc; }
            set
            {
                ifsc = value;
                if (string.IsNullOrEmpty(ifsc))
                {
                    throw new Exception("not a valid ifsc ");
                }
            }

        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                if (string.IsNullOrEmpty(date.ToString()))
                {
                    throw new Exception("not a valid ifsc ");
                }
            }

        }




    }


}

























