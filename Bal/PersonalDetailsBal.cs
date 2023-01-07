using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bal
{
   public class PersonalDetailsBal
    {
        PersonalDetailsDal dal = new PersonalDetailsDal();

        public DataTable BindSearchDropdown()
        {
            return dal.BindSearchDropdown();
        }

        public DataTable GetInfoByID(int UserId)
        {
            return dal.GetInfoByID(UserId);
        }

        public int SaveData(PersonalDetails personal)
        {
            return dal.SaveData(personal);
        }

        public int UpdateData(PersonalDetails personal)
        {
            return dal.UpdateData(personal);
        }

        public DataTable GetAllData()
        {
            return dal.GetAllData();
        }

        public int DeleteData(PersonalDetails personal)
        {
            return dal.DeleteData(personal);
        }

        public int NumberOfRecords()
        {
            return dal.NumberOfRecords();
        }

        public DataTable BindCountry()
        {
            return dal.BindCountry();
        }

        public DataTable BindState(int Id)
        {
            return dal.BindState(Id);
        }

        public int GetStateId(string country)
        {
            return dal.GetStateId(country);
        }

        public DataTable ExportData()
        {
            return dal.ExportData();
        }
    }
}
