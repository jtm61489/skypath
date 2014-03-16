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
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridViewStudentAppointments" runat="server"
                AutoGenerateSelectButton="true" AutoGenerateColumns="false" DataKeyNames="id">
                <SelectedRowStyle BackColor="Red" />
                <Columns>
                    <asp:BoundField DataField="appointment" HeaderText="appointment" SortExpression="appointment" />
                    <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel Appointment" />
    <br />
    <h4>
        All Appointments
    </h4>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridViewAllAppointments" runat="server" 
                AutoGenerateSelectButton="true" AutoGenerateColumns="false" DataKeyNames="id">
                <SelectedRowStyle BackColor="Red" />
                <Columns>
                    <asp:BoundField DataField="appointment" HeaderText="appointment" SortExpression="appointment" />
                    <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="ButtonBookAppointment" runat="server" Text="Book Appointment" />
    <br />
    <br />
</asp:Content>
