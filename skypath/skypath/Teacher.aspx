<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="skypath.Teacher"
    MasterPageFile="~/MasterPages/Main.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderBodyHeader">
    <h3>
        Teacher
    </h3>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderBody">
    <h4>
        Appointments
    </h4>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridViewAppointments" runat="server" OnSelectedIndexChanged="GridViewAppointments_SelectedIndexChanged"
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
    <asp:Button ID="ButtonDelete" runat="server" Text="Delete Appointment" />
    <h4>
        Add New Appointment Opening
    </h4>
    <br />
    <asp:Label ID="LabelDate" runat="server" Text="Date:" AssociatedControlID="TextBoxDate"></asp:Label>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxDate">
    </ajaxToolkit:CalendarExtender>
    <asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelTime" runat="server" Text="Time:" AssociatedControlID="DropDownListTime"></asp:Label>
    <asp:DropDownList ID="DropDownListTime" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="ButtonAddNewAppointment" runat="server" Text="Add New" />
    <br />
    <br />
</asp:Content>
