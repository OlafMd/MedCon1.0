<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="ValidationSandbox.About" %>

<%@ Register Assembly="InputValidationWrapper" Namespace="InputValidationWrapper"
    TagPrefix="val" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Label ID="Label2" runat="server" Text="mjau"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper2" runat="server" ControlToValidateID='TextBox2'
        MessageType='error' Text='error' OnExternalBackendValidation="MySpecialValidation">
        <contenttemplate><asp:TextBox ID="TextBox2" runat="server" TabIndex="0"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label1" runat="server" Text="Mandatory"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper1" runat="server" ControlToValidateID='TextBox1'
        MessageType='error' Text='Mandatory field' BackendValidationRules="Mandatory">
        <contenttemplate><asp:TextBox ID="TextBox1" runat="server" TabIndex="1"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label15" runat="server" Text="TextArea"></asp:Label>
    <br/>
    <asp:TextBox ID="TextArea1" runat="server" TextMode="MultiLine" TabIndex="2"></asp:TextBox>
    <br/>


    <asp:Label ID="Label3" runat="server" Text="Mandatory & integer"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper3" runat="server" ControlToValidateID='TextBox3'
        MessageType='error' Text='Must be integer and must be specified' BackendValidationRules="mandatory;isinteger">
        <contenttemplate><asp:TextBox ID="TextBox3" runat="server" TabIndex="3"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label4" runat="server" Text="3 decimals"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper4" runat="server" ControlToValidateID='TextBox4'
        MessageType='error' Text='must have 3 decimals' BackendValidationRules="decimals|3">
        <contenttemplate><asp:TextBox ID="TextBox4" runat="server" TabIndex="4"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

 <%--   <asp:Label ID="Label5" runat="server" Text="Double"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper5" runat="server" ControlToValidateID='TextBox5'
        MessageType='error' Text='Must be a double' BackendValidationRules="isdouble">
        <contenttemplate><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></contenttemplate>      
    </val:InputValidationWrapper>

    <asp:Label ID="Label6" runat="server" Text="Mandatory & positive"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper6" runat="server" ControlToValidateID='TextBox6'
        MessageType='error' Text='Must be a positive number and must be specified' BackendValidationRules="mandatory;ispositive">
        <contenttemplate><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label7" runat="server" Text="negative"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper7" runat="server" ControlToValidateID='TextBox7'
        MessageType='error' Text='must be negative' BackendValidationRules="isnegative">
        <contenttemplate><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label8" runat="server" Text="Between 3 and 8"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper8" runat="server" ControlToValidateID='TextBox8'
        MessageType='error' Text='must be between 3 and 8' BackendValidationRules="isinrange|3|8">
        <contenttemplate><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label9" runat="server" Text="Not between 3 and 8"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper9" runat="server" ControlToValidateID='TextBox9'
        MessageType='error' Text='must be outside of range 3 - 8' BackendValidationRules="isnotinrange|3|8">
        <contenttemplate><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label10" runat="server" Text="Date"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper10" runat="server" ControlToValidateID='TextBox10'
        MessageType='error' Text='Must be a valid date in format dd.MM.yyyy' BackendValidationRules="isdate|dd.MM.yyyy">
        <contenttemplate><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label11" runat="server" Text="Date in range 01/01/2013 - 01/03/2013"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper11" runat="server" ControlToValidateID='TextBox11'
        MessageType='error' Text='Date must be in range 01/01/2013 - 01/03/2013' BackendValidationRules="isdateinrange|01/01/2013|01/03/2013">
        <contenttemplate><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label12" runat="server" Text="Date not in range 01/01/2013 - 01/03/2013"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper12" runat="server" ControlToValidateID='TextBox12'
        MessageType='error' Text='Date must NOT be in range 01/01/2013 - 01/03/2013' BackendValidationRules="isdatenotinrange|01/01/2013|01/03/2013">
        <contenttemplate><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>

    <asp:Label ID="Label13" runat="server" Text="Email"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper13" runat="server" ControlToValidateID='TextBox13'
        MessageType='error' Text='Must be a valid email address' BackendValidationRules="isvalidemail">
        <contenttemplate><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></contenttemplate>
    </val:InputValidationWrapper>--%>

<%--    <asp:Label ID="Label14" runat="server" Text="Banana"></asp:Label>
    <val:InputValidationWrapper ID="InputValidationWrapper14" runat="server" ControlToValidateID='DropDownList1'
        MessageType='error' Text='Must select banana (index 1)' BackendValidationRules="IsSelectedIndex|1">
        <contenttemplate>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>
                    Apple
                </asp:ListItem>
                <asp:ListItem>
                    Banana
                </asp:ListItem>
                <asp:ListItem>
                    Orange
                </asp:ListItem>
            </asp:DropDownList>
        </contenttemplate>
    </val:InputValidationWrapper>--%>

    <%--if ($('div[class*=&quot;validate&quot;][triggeredstate!=&quot;&quot;]').length > 0 ){ alert('errors/warnings'); return false;}--%>

    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="validateAllWrappers(); return false;" PostBackUrl="~/Default.aspx">LinkButton</asp:LinkButton>
</asp:Content>
