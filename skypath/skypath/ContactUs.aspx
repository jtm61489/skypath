<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="skypath.ContactUs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contact Us</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBodyHeader" runat="server">
    <style type="text/css">
        .bodyDiv
        {
            clear: left;
            width: 100;
            margin: 0 0 1.5em 0;
            padding: 0;
        }
        .bodyDiv .label, .textBox, .button
        {
            clear: left;
            float: left;
            margin-left: 25%;
            font-family:Arial;
            font-size: 150%;
        }
        .label
        {
            float: left;
            clear: left;
        }
        .textBox 
        {
            margin: 5px 0 10px 25%;
            width: 400px;
        }
        .textBox:hover
        {
            border-color: #888888;
        }
        /*button so big please stop: consider change in /styles/styles.css*/
        .button
        {
            height: 40px;
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <fieldset class="bodyDiv">
        <br />
        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFrom" CssClass="label">From:   
        </asp:Label>
        <asp:TextBox ID="txtFrom" runat="server" CssClass="textBox"></asp:TextBox>
        <asp:Label runat="server" ID="Label2" AssociatedControlID="txtTo" CssClass="label">To: 
        </asp:Label>
        <asp:TextBox ID="txtTo" runat="server" CssClass="textBox"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="ToValidator1" runat="server" ErrorMessage="Please Enter the Email To."
        ControlToValidate="txtTo"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="ToValidator2" runat="server" ErrorMessage="Please Enter a Valid To Email address"
        ControlToValidate="txtTo" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtSubject" CssClass="label">Subject:</asp:Label>
        <asp:TextBox ID="txtSubject" runat="server" CssClass="textBox"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" AssociatedControlID="txtContent" CssClass="label">Message:
        </asp:Label>
        <textarea runat="server" id="txtContent" rows="7" cols="24" class="textBox"></textarea>
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="button">
        </asp:Button>
        <asp:Label ID="lblStatus" runat="server"> 
        </asp:Label>
    </fieldset>
</asp:Content>
