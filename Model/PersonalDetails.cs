using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class PersonalDetails
    {
        private int UserId;
        private string FirstName;
        private string MiddleName;
        private string LastName;
        private string EmailId;
        private DateTime DOB;
        private string PhoneNo;
        private string Address;
        private string State;
        private string Country;
        private string Gender;

        //UserId
        public int IntId
        {
            get
            {
                return UserId;
            }
            set
            {
                UserId = value;
            }
        }

        //CountryId
        public string GetCountry
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value;
            }
        }
        //StateId
        public string GetState
        {
            get
            {
                return State;
            }
            set
            {
                State = value;
            }
        }
        //PhoneNo
        public string GetPhoneNo
        {
            get
            {
                return PhoneNo;
            }
            set
            {
                PhoneNo = value;
            }
        }
        //Gender
        public string GetGender
        {
            get 
            {
                return Gender;
            }
            set
            {
                Gender = value;
            }
        }
        //FirstName
        public string GetFName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }
        //MName
        public string GetMName
        {
            get
            {
                return MiddleName;
            }
            set
            {
                MiddleName = value;
            }
        }
        //LName
        public string GetLName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }
        //EmailId
        public string GetEmailId
        {
            get
            {
                return EmailId;
            }
            set
            {
                EmailId = value;
            }
        }
        //Address
        public string GetAddress
        {
            set
            {
                Address = value;
            }
            get
            {

                return Address;
            }
        }
        //DOB
        public DateTime GetDOB
        {
            set
            {
                DOB = value;
            }
            get
            {
                return DOB;
            }
        }
    }
}