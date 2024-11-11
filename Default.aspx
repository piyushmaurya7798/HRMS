<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HRMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <p>
        Id :
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="Fetch" OnClick="Button2_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server">
        <p>
               Id :
 <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</p>

    <p>
        Present :
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>

    <p>
        Absent :
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        Total days in month :
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </p>

    <p>
        InHand Salary :
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </p>


    </asp:Panel>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" />
    </p>

    <asp:Panel ID="Panel2" runat="server">
        Hello
    </asp:Panel>


</asp:Content>
