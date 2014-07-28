<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="skypath.Teacher"
    MasterPageFile="~/MasterPages/Main.master" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

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
                    <asp:BoundField DataField="appointmentStart" HeaderText="appointmentStart" SortExpression="appointmentStart" />
                    <asp:BoundField DataField="appointmentEnd" HeaderText="appointmentEnd" SortExpression="appointmentEnd" />
                    <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" 
        BorderColor="Gray" CssOnly="False" Width="500px" 
        style="top: 0px; left: 0px; height: 279px;" TimeFormat="Clock24Hours" 
        EventClickHandling="PostBack" BusinessEndsHour="19" CellHeight="15" 
        HeaderHeight="23" HourFontSize="16pt" />
    <br />
    <asp:Button ID="ButtonDelete" runat="server" Text="Delete Appointment" />
    <h4>
        &nbsp;Add New Appointment Opening
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
    <asp:FileUpload ID="FileUpload" runat="server" />
    <asp:Button ID="ButtonUpload" runat="server" Text="Upload" />

    <asp:PlaceHolder ID="PlaceHolderTeachers" runat="server"></asp:PlaceHolder>
    </asp:Content>
