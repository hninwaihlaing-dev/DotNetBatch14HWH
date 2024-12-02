<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNetBatch14HWH.WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-bottom: 0px">
        <div style="font-size:x-large" align="center">Student Management Info Form</div>
        <br />
        <table class="w-100">
            <tr>
                <td style="height: 30px"></td>
                <td style="width: 173px; height: 30px;">Student ID</td>
                <td style="height: 30px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="217px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" BackColor="#CC66FF" BorderColor="#9933FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="GET" Width="98px" OnClick="GetBtnClick"/>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 173px">Student Name</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="217px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 173px">Address</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>Mandalay</asp:ListItem>
                        <asp:ListItem>KyonPyaw</asp:ListItem>
                        <asp:ListItem>Yangon</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 173px">Age</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="217px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 14px"></td>
                <td style="width: 173px; height: 14px">Contact</td>
                <td style="height: 14px">
                    <asp:TextBox ID="TextBox4" runat="server" Width="217px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 34px"></td>
                <td style="width: 173px; height: 34px"></td>
                <td style="height: 34px">
                    <asp:Button ID="Button1" runat="server" BackColor="#CC66FF" BorderColor="#9933FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="Insert" Width="98px" OnClick="InsertBtn_Click"/>
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" BackColor="#CC66FF" BorderColor="#9933FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="Update" Width="98px" OnClick="UpdateBtnClick"/>
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" BackColor="#CC66FF" BorderColor="#9933FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="Delete" Width="98px" OnClientClick="return confirm('Are you sure to delete');" OnClick="DeleteBtnClick"/>
                &nbsp;
                    <asp:Button ID="Button4" runat="server" BackColor="#CC66FF" BorderColor="#9933FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="Search" Width="98px" OnClick="SearchBtnClick"/>
                </td>
            </tr>
            <tr>
                <td style="height: 34px">&nbsp;</td>
                <td style="width: 173px; height: 34px">&nbsp;</td>
                <td style="height: 34px">
                    <asp:GridView ID="GridView1" runat="server" Height="146px"  Width="700px">
                    </asp:GridView>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" Font-Bold="True" ForeColor="Black" Height="40px" OnClick="LinkButton1_Click">Export to Excel</asp:LinkButton>
&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" BackColor="White" Font-Bold="True" ForeColor="Black" Height="40px" OnClick="PrintPDF_Click">Print to PDF</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
