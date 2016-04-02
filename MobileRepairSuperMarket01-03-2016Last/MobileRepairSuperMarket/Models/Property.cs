using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileRepairSuperMarket.Models
{
    public class Property
    {

        private string con = "Data Source=166.62.42.160,1986;Initial Catalog=MobileRepairSuperMarket;User ID=MobileRepairSuperMarketp5lh;Password=12345";
       // private string con = "data source=NITESH-PC\\MSSQL2012;user id=sa;password=sql@2012;initial catalog=MobileRepairSuperMarket";
       
        //private string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public string Con
        {
            get
            {
                return con;
            }
        }

        public string EmailID { get; set; }
        public string Password { get; set; }
        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string onTable { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias_Name { get; set; }
        public string ContactNo { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public string UserType { get; set; }

        public string MiddleName { get; set; }

        public string CnfPassword { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string AltContactNo { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string UserId { get; set; }

        public string profilepic { get; set; }
    }
}