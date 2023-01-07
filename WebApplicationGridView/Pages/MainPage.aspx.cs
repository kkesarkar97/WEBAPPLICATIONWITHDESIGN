using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bal;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace WebApplicationGridView.Pages
{
    public partial class MainPage : System.Web.UI.Page
    {
        PersonalDetails Personal = new PersonalDetails();
        PersonalDetailsBal bal = new PersonalDetailsBal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindSearchDropdown();
                BindCountry();
                //BindState();
                //BindGridviewData();
            }
        }

        public void SetValues()
        {
            if (Page.IsValid)
            {
                Personal.GetFName = TxtFName.Text;
                Personal.GetMName = TxtMName.Text;
                Personal.GetLName = TxtLName.Text;
                Personal.GetEmailId = TxtEmailid.Text;
                Personal.GetPhoneNo = TxtPhoneNo.Text;
                Personal.GetDOB = Convert.ToDateTime(TxtDOB.Text);
                Personal.GetAddress = TxtAddress.Text;
                Personal.GetState = ddlState.SelectedItem.Text;
                Personal.GetCountry = ddlCountry.SelectedItem.Text;
                Personal.GetGender = Radiogender.SelectedItem.Text;
                Label6.Text = TxtFName.Text + " " + TxtLName.Text;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            SetValues();
            int i = bal.SaveData(Personal);
            BindGridviewData();
            if (i>0)
            {
                Label1.Text = "Data Inserted Successfully !!!";
            }
            else
            {
                Label1.Text = "Data Not Inserted Successfully !!!";
            }
         }

        public void BindSearchDropdown()
        {
            DataTable dt = new DataTable();
            dt = bal.BindSearchDropdown();
            ddlSearch.Items.Clear();
            ddlSearch.DataSource = dt;
            ddlSearch.DataTextField = "FName";
            ddlSearch.DataValueField = "UserId";
            ddlSearch.DataBind();
            ddlSearch.Items.Insert(0, "Please Select");
            ddlSearch.SelectedIndex = 0;
        }
        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if(string.Equals(ddlSearch.SelectedItem.Text,"Please Select"))
            {
                Label2.Text = "Please Select the List";
            }
            else
            {
                dt = bal.GetInfoByID(Convert.ToInt32(ddlSearch.SelectedValue));

                if(dt.Rows.Count>0)
                {
                    TxtFName.Text = dt.Rows[0]["FName"].ToString();
                    TxtMName.Text = dt.Rows[0]["MName"].ToString();
                    TxtLName.Text = dt.Rows[0]["LName"].ToString();
                    TxtEmailid.Text = dt.Rows[0]["EmailId"].ToString();
                    TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    TxtDOB.Text = dt.Rows[0]["Dob"].ToString();
                    TxtAddress.Text = dt.Rows[0]["Address"].ToString();
                    ddlCountry.SelectedItem.Text = dt.Rows[0]["Country"].ToString();
                    string Country= dt.Rows[0]["Country"].ToString();
                    int Id=bal.GetStateId(Country);
                    BindState(Id);
                    

                    string gender = dt.Rows[0]["Gender"].ToString();
                    if(string.Equals(gender,"Male"))
                    {
                        Radiogender.SelectedIndex=0;
                    }
                    if (string.Equals(gender, "Female"))
                    {
                        Radiogender.SelectedIndex = 1;
                    }
                    if (string.Equals(gender, "Other"))
                    {
                        Radiogender.SelectedIndex = 2;
                    }

                    int i = Convert.ToInt32(ddlSearch.SelectedValue);
                    Label2.Text = "Searching done successfully for Id :" + i + " !!!";
                    Label6.Text = TxtFName.Text + " " + TxtLName.Text;

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Personal.IntId = Convert.ToInt32(ddlSearch.SelectedValue);
            SetValues();
            int i = bal.UpdateData(Personal);
            BindGridviewData();
            if (i > 0)
            {
                Label3.Text = "Data Updated Successfully having Id " + Personal.IntId + " !!!";
            }
            else
            {
                Label3.Text = "Data Not Updated Successfully having Id " + Personal.IntId + " !!!";
            }
        }

        public void BindGridviewData()
        {
            DataTable dt = new DataTable();
            dt = bal.GetAllData();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            NumberOfRecords();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Personal.IntId = Convert.ToInt32(ddlSearch.SelectedValue);
            int i = bal.DeleteData(Personal);
            BindGridviewData();
            
            if (i > 0)
            {
                Label4.Text = "Data Deleted Successfully having Id " +Personal.IntId+" !!!" ;
            }
            else
            {
                Label4.Text = "Data Not Deleted Successfully having Id " + Personal.IntId + " !!!";
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        public void NumberOfRecords()
        {
            int i = bal.NumberOfRecords();
            Label5.Text = "Number of Records : " + i;
        }

        public void BindCountry()
        {
            DataTable dt = bal.BindCountry();
            ddlCountry.Items.Clear();
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryId";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, "Please Select");
            ddlCountry.SelectedIndex = 0;
        }

        public void BindState(int Id)
        {
            DataTable dt = bal.BindState(Id);
            ddlState.Items.Clear();
            ddlState.DataSource = dt;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Please Select");
            ddlState.SelectedIndex = 0;
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(ddlCountry.SelectedValue);
            BindState(Id);
        }

        protected void BtnTextFile_Click(object sender, EventArgs e)
        {
            DataTable dt = bal.ExportData();
            
            int i;
            StreamWriter swExtLogFile = new StreamWriter(@"D:\Asp.Net\WebApplicationGridView\Reports\ExportDetailsFile.txt", true);
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write("**************************************************************************** Personal Details ****************************************************************************" );
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write(Environment.NewLine);


            foreach (DataColumn column in dt.Columns)
            {

                swExtLogFile.Write(column.ColumnName.ToString() + " | ");
                
            }
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write(Environment.NewLine);

            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    swExtLogFile.Write(array[i].ToString() + " | ");
                }
                swExtLogFile.Write(Environment.NewLine);
                swExtLogFile.WriteLine(array[i].ToString());
            }


            swExtLogFile.Write(Environment.NewLine);

            swExtLogFile.Write("Created On this Date : " + DateTime.Now.ToString());
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Flush();
            swExtLogFile.Close();

        }

        protected void BtnCsv_Click(object sender, EventArgs e)
        {
            DataTable dt = bal.ExportData();

            int i;
            StreamWriter swExtLogFile = new StreamWriter(@"D:\Asp.Net\WebApplicationGridView\Reports\ExportDetailsFile.csv", true);
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write("**************************************************************************** Personal Details ****************************************************************************");
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write(Environment.NewLine);


            foreach (DataColumn column in dt.Columns)
            {

                swExtLogFile.Write(column.ColumnName.ToString() + " , ");

            }
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write(Environment.NewLine);

            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    swExtLogFile.Write(array[i].ToString() + " , ");
                }
                swExtLogFile.Write(Environment.NewLine);
                swExtLogFile.WriteLine(array[i].ToString());
            }


            swExtLogFile.Write(Environment.NewLine);

            swExtLogFile.Write("Created On this Date : " + DateTime.Now.ToString());
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Flush();
            swExtLogFile.Close();

        }

        protected void BtnXml_Click(object sender, EventArgs e)
        {
            DataTable dt = bal.ExportData();
            //dt.WriteXml(Server.MapPath(@"D:\Asp.Net\WebApplicationGridView\Reports\ExportDetailsFile.xml"));
            dt.WriteXml(@"D:\Asp.Net\WebApplicationGridView\Reports\ExportDetailsFile.xml");
            string msg = "Successfully XML Downloaded !!!";
            Label7.Text = "<a href=ExportDetailsFile.xml> XML file</a>" + msg;
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = bal.ExportData();
            try
            {
                var excelApplication = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApplication.Application.Workbooks.Add(Type.Missing);
                DataColumnCollection dataColumnCollection = dt.Columns;


                for (int i = 1; i <= dt.Rows.Count + 1; i++)
                {
                    for (int j = 1; j <= dt.Columns.Count; j++)
                    {
                        if (i == 1)
                        {
                            excelApplication.Cells[i, j] = dataColumnCollection[j - i].ToString();
                        }
                        else
                        {
                            excelApplication.Cells[i, j] = dt.Rows[i - 2][j - 1].ToString();
                        }
                    }
                }
                //Save the excel 
                excelApplication.ActiveWorkbook.SaveCopyAs(@"D:\Asp.Net\WebApplicationGridView\Reports\ExportDetailsFile..xlsx");
                excelApplication.ActiveWorkbook.Saved = true; 
                excelApplication.Quit();

                releaseObject(workbook);
                releaseObject(excelApplication);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}