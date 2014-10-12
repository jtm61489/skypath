<%@ Page Title="Teacher Performance Report" Language="C#" AutoEventWireup="true" CodeBehind="TeacherPerformance.aspx.cs" 
    Inherits="skypath.TeacherPerformance" MasterPageFile="~/MasterPages/Main.master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyHeader" ContentPlaceHolderID="ContentPlaceHolderBodyHeader" runat="server">
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
        .detailInstruction
        {
            color: Red;
            font-size:smaller;
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
        Please rate your instructor. Below you will find a series of optional questions. Completing this form will help us to train and
        manage instructors in the future. </asp:Label>
    <fieldset class="bodyDiv">

        <asp:Label ID="Label1" runat="server" AssociatedControlID="rblHelpful" CssClass="label">How helpful was your instructor and the lesson?</asp:Label>
        <asp:RadioButtonList ID="rblHelpful" runat="server" CssClass="radioButtonList" 
            Font-Size="Larger" RepeatDirection="Horizontal" CellPadding="10" CellSpacing="10">
            <asp:ListItem>Not at all!</asp:ListItem>
            <asp:ListItem>So-so</asp:ListItem>
            <asp:ListItem>Average</asp:ListItem>
            <asp:ListItem>Pretty</asp:ListItem>
            <asp:ListItem>Extremely!</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label2" runat="server" AssociatedControlID="rblClarity" CssClass="label">How clear was your instructor's English?</asp:Label>
        <asp:RadioButtonList ID="rblClarity" runat="server" CssClass="radioButtonList" 
            Font-Size="Larger" RepeatDirection="Horizontal" CellPadding="10" CellSpacing="10">
            <asp:ListItem>Not at all!</asp:ListItem>
            <asp:ListItem>So-so</asp:ListItem>
            <asp:ListItem>Average</asp:ListItem>
            <asp:ListItem>Pretty</asp:ListItem>
            <asp:ListItem>Extremely!</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label3" runat="server" AssociatedControlID="rblEnjoyable" CssClass="label">How much did you enjoy the lesson?</asp:Label>
        <asp:RadioButtonList ID="rblEnjoyable" runat="server" CssClass="radioButtonList" 
            Font-Size="Larger" RepeatDirection="Horizontal" CellPadding="10" CellSpacing="10">
            <asp:ListItem>Not at all!</asp:ListItem>
            <asp:ListItem>So-so</asp:ListItem>
            <asp:ListItem>Ok</asp:ListItem>
            <asp:ListItem>Fun</asp:ListItem>
            <asp:ListItem>Awesome!</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label4" runat="server" AssociatedControlID="txtMessage" CssClass="label">Please leave any other information here:
        </asp:Label>
        <textarea runat="server" id="txtMessage" rows="6" cols="24" class="textBox"></textarea>

        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="button">
        </asp:Button>
        <asp:Label ID="lblStatus" runat="server"> 
        </asp:Label>
    </fieldset>
</asp:Content>
