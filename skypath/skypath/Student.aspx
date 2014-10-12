<%@ Page Title="Student Home" Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="skypath.Student"
    MasterPageFile="~/MasterPages/Main.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">

    </script>
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
                    <asp:BoundField DataField="appointmentStart" HeaderText="appointment" SortExpression="appointment" />
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
                    <asp:BoundField DataField="appointmentStart" HeaderText="appointment" SortExpression="appointment" />
                    <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="ButtonBookAppointment" runat="server" Text="Book Appointment" Enabled="True" />
    <br />
    <br />
</asp:Content>
