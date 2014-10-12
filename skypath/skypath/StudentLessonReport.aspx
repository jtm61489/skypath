<%@ Page Title="Student Lesson Report" Language="C#" AutoEventWireup="true" CodeBehind="StudentLessonReport.aspx.cs" 
    Inherits="skypath.StudentLessonReport" MasterPageFile="~/MasterPages/Main.master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyHeadContent" ContentPlaceHolderID="ContentPlaceHolderBodyHeader" runat="server">
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
            font-size: 125%%;
        }
        .label
        {
            float: left;
            clear: left;
        }
        .textBox 
        {
            margin: 10px 0 10px 25%;
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
        .headLabel
        {
            clear: left;
            float: left;
            margin-left: 10%;
            margin-right: 5%;
            margin-top: 20px;
            margin-bottom: 20px;
            font-family:Arial;
            font-size: 150%;            
            color: Red;
        }
        .radioButtonList
        {
            font-family:Arial;
            font-size: 150%;    
            margin: 25px 0 10px  25%;   
            padding: 5px 5px 5px 5px;
            border:1px solid white;              
        }
        .radioButtonList:hover
        {
            border: 1px dotted #00CC00;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <asp:Label ID="Instructions" runat="server" CssClass="headLabel">
        Please rate your student's lesson. Enter any specific details in the message box you feel aid future teachers. </asp:Label>
    <fieldset class="bodyDiv">
       <asp:Label ID="Label1" runat="server" AssociatedControlID="rblGrade" CssClass="label">How well did the student perform (relative to his/her level)?</asp:Label>
        <asp:RadioButtonList ID="rblGrade" runat="server" CssClass="radioButtonList" 
            Font-Size="Larger" RepeatDirection="Horizontal" CellPadding="10" CellSpacing="10">
            <asp:ListItem>Unresponsive</asp:ListItem>
            <asp:ListItem>Not well</asp:ListItem>
            <asp:ListItem>Average</asp:ListItem>
            <asp:ListItem>Above average</asp:ListItem>
            <asp:ListItem>Superb</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtMessage" CssClass="label">Leave some details about the student for future teachers:
        </asp:Label>
        <textarea runat="server" id="txtMessage" rows="6" cols="24" class="textBox"></textarea>

        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="button">
        </asp:Button>
        <asp:Label ID="lblStatus" runat="server"> 
        </asp:Label>
    </fieldset>
</asp:Content>

