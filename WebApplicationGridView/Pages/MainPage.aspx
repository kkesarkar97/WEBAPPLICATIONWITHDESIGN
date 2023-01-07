<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplicationGridView.Pages.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <script src="../Content/js/bootstrap.min.js" ></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
        <div class="container" style="background-color:blue">
            <div class="row">
                <center><h1>Details Form</h1></center>
            </div>
        </div>
        <div class="container" style="background-color:lightskyblue">
            <br />
            <br />
            <div class="row">
                <div class="col">
                    <asp:Label ID="Label5" runat="server" Text="" CssClass="form-control" BackColor="YellowGreen" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <asp:Image ID="ImgCompany" runat="server" CssClass="mw-100" ImageUrl="~/Images/Person_Icon.png" Height="100px" Width="100px"/>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label6" runat="server" CssClass="form-control" BackColor="#99ff33" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LSearch" runat="server" CssClass="form-label">Search :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlSearch" runat="server" CssClass="form-select" ToolTip="Please Select the First Name" AutoPostBack="True" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="LFName" runat="server">Enter First Name :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtFName" runat="server" CssClass="form-control" ToolTip="Enter Your First Name"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtFName" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="MName" runat="server">Enter Middle Name :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtMName" runat="server" CssClass="form-control" ToolTip="Enter Your Middle Name"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtMName" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="LName" runat="server">Enter Last Name :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtLName" runat="server" CssClass="form-control" ToolTip="Enter Your Last Name"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtLName" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LEmail" runat="server">Enter Email Id :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtEmailid" runat="server" CssClass="form-control" TextMode="Email" ToolTip="Enter Your Email Id"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtEmailid" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Format" ControlToValidate="TxtEmailid" CssClass="form-check" ForeColor="#ff0000" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" Display="Dynamic" ></asp:RegularExpressionValidator>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="LPhone" runat="server">Enter Phone Number :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtPhoneNo" runat="server" CssClass="form-control"  ToolTip="Enter Your Phone Number"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtPhoneNo" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LDOB" runat="server">Enter Date Of Birth :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtDOB" runat="server" CssClass="form-control"  ToolTip="Enter Your Birth Date"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtDOB" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Format" CssClass="form-check" ControlToValidate="TxtDOB" ForeColor="#ff0000" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"></asp:RegularExpressionValidator>
                </div><!--(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$--><!--^(?:0[1-9]|[12]\d|3[01])([\/.-])(?:0[1-9]|1[012])\1(?:19|20)\d\d$-->
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="LAddress" runat="server">Enter the Address :</asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" ToolTip="Enter Your Address"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Mandatory Field" ControlToValidate="TxtAddress" ValidationGroup="G1" Display="Dynamic" CssClass="form-check" ForeColor="#ff3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LState" runat="server">Select Country :</asp:Label>
                </div>
                <div class="col-sm-3">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-select" ToolTip="Select Your Country" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                </asp:DropDownList>        
                </div>
            </div>
            <br />
            <br />
        <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="LCountry" runat="server">Select State  :</asp:Label>
                </div>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" ToolTip="Select Your State" AutoPostBack="True" >
                </asp:DropDownList>
            </div>
            <div class="col-sm-3">
                    <asp:Label ID="LGender" runat="server">Select Gender  :</asp:Label>
                </div>
            <div class="col-sm-3">
                <asp:RadioButtonList ID="Radiogender" runat="server" CssClass="form-check" RepeatDirection="Horizontal" BackColor="LightSkyBlue" CellPadding="10" ToolTip="Select Your Gender">
                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Others"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            </div>
            <br />
            <br />

            </div>
                      
        <div class="container" style="background-color:blue">
            <br />
            <br />
            <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="BtnSubmit" runat="server" Text="Save" CssClass="form-control" OnClick="BtnSubmit_Click"  ValidationGroup="G1"/>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="form-control" OnClick="BtnUpdate_Click"/>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="form-control" OnClick="BtnDelete_Click"/>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="form-control" OnClick="BtnCancel_Click"/>
                </div>
            </div>
            <br />
            <br />
            </div>
            
        <div class="container" style="background-color:darkblue">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="col-form-label-lg" ForeColor="#ff0000"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="col-form-label-lg" ForeColor="#ff0000"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label3" runat="server" Text="" CssClass="col-form-label-lg" ForeColor="#ff0000"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label4" runat="server" Text="" CssClass="col-form-label-lg" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>
            </div>
        <div class="container" style="background-color:cadetblue">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView1" runat="server"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="8" GridLines="Vertical" Caption="Personal Details Table" CaptionAlign="Top" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />

                    </asp:GridView>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
            <div class="col-md-3">
                <asp:Button ID="BtnTextFile" runat="server" Text="Text File Report" CssClass="form-control" OnClick="BtnTextFile_Click" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="BtnExcel" runat="server" Text="Excel Sheet Report" CssClass="form-control" OnClick="BtnExcel_Click" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="BtnXml" runat="server" Text="XML File Report" CssClass="form-control" OnClick="BtnXml_Click" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="BtnCsv" runat="server" Text="Csv File Report" CssClass="form-control" OnClick="BtnCsv_Click" />
            </div>
                </div>
            <br />
            <br />
            <div class="row">
                <div class="col">
                    <asp:Label ID="Label7" runat="server" Text="" BackColor="#009933" CssClass="col-form-label" ForeColor="White"></asp:Label>
                </div>
            </div>
            <br />
            <br />
        </div>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnUpdate" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnCancel" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
    </form>
</body>
</html>
