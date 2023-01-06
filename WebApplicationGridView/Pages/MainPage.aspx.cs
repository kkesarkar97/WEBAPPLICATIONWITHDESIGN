using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bal;
using System.Data;

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
    }
}