<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ValidationSandbox._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:CustomValidator ID="CustomValidator1"
        runat="server" ErrorMessage="CustomValidator" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate">
    </asp:CustomValidator>
</asp:Content>
