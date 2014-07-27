<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="skypath.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBodyHeader" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFrom">From:   
    </asp:Label>
    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
    <br />
    <%--<asp:RequiredFieldValidator ID="FromValidator1" runat="server" ErrorMessage="Please Enter the Email From."
        ControlToValidate="txtFrom"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="FromValidator2" runat="server" ErrorMessage="Please Enter a Valid From Email address"
        ControlToValidate="txtFrom" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
    <asp:Label runat="server" ID="Label2" AssociatedControlID="txtTo">To: 
    </asp:Label>
    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
    <br />
    <%--<asp:RequiredFieldValidator ID="ToValidator1" runat="server" ErrorMessage="Please Enter the Email To."
        ControlToValidate="txtTo"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="ToValidator2" runat="server" ErrorMessage="Please Enter a Valid To Email address"
        ControlToValidate="txtTo" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtSubject">Subject:</asp:Label>
    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtContent">Mail:
    </asp:Label>
    <textarea runat="server" id="txtContent" rows="7" cols="24"></textarea>
    <br />
    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click"></asp:Button>
    <br />
    <asp:Label ID="lblStatus" runat="server"> 
    </asp:Label>
</asp:Content>
