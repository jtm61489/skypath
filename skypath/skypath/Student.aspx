<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="skypath.Student"
    MasterPageFile="~/MasterPages/Main.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderBodyHeader">
    <h3>
        Student
    </h3>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderBody">
    <h4>
        Appointments
    </h4>
    <asp:GridView ID="GridViewAppointments" runat="server" OnSelectedIndexChanged="GridViewAppointments_SelectedIndexChanged" AutoGenerateSelectButton="true">
        <SelectedRowStyle BackColor="Red" />
    </asp:GridView>
    <br />
</asp:Content>
