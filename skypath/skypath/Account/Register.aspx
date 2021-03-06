﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPages/Main.master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="skypath.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyHeaderContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderBodyHeader">
    <style type="text/css">
        .bodyDiv
        {
            clear: left;
            width: 100;
            margin: 0 0 1.5em 0;
            padding: 0;
        }
        .bodyDiv .textEntry, .textBox, .button, .label, .headerInfo, .normButton
        {
            clear: left;
            float: left;
            margin-left: 35%;
            font-family: Arial;
        }
        .normButton
        {
            margin: 10px 0 20px 38%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderBody">
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <fieldset class="bodyDiv">
                        <div class="headerInfo">
                            <h2 class="titleHeader">
                                Create a New Account
                            </h2>
                            <p>
                                Use the form below to create a new account.
                            </p>
                            <p>
                                Passwords are required to be a minimum of
                                <%= Membership.MinRequiredPasswordLength %>
                                characters in length.
                            </p>
                        </div>
                        <span class="failureNotification">
                            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                        </span>
                        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                            ValidationGroup="RegisterUserValidationGroup" />
                    </fieldset>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="label">User Name:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" CssClass="label">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="label">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword"
                                    CssClass="label">Confirm Password:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                    Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                                    runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                                    ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                            <asp:DropDownList ID="DropDownListTeacherStudent" runat="server">
                                <asp:ListItem Text="Teacher" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Student" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="DropDownListTeacherStudent" CssClass="failureNotification"
                                Display="Dynamic" ErrorMessage="Are you a teacher or a student?" ID="TeacherStudentRequired"
                                runat="server" ToolTip="Are you a teacher or a student?" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            <p>
                                <asp:Label ID="LabelFirstName" runat="server" AssociatedControlID="TextBoxFirstName">First Name:</asp:Label>
                                <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                    Display="Dynamic" ErrorMessage="First Name is required." ID="RequiredFieldValidatorFirstName"
                                    runat="server" ToolTip="First Name is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="LabelLastName" runat="server" AssociatedControlID="TextBoxLastName">Last Name:</asp:Label>
                                <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                    Display="Dynamic" ErrorMessage="Last Name is required." ID="RequiredFieldValidatorLastName"
                                    runat="server" ToolTip="Last Name is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p class="submitButton">
                                <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User"
                                    ValidationGroup="RegisterUserValidationGroup" CssClass="normButton" />
                            </p>
                    </div>
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
