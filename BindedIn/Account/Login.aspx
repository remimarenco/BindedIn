<%@ Page Title="Se connecter" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="BindedIn.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Se connecter</legend>              
                    <div class="form-horizontal">

                        <div class="control-group">
                            <asp:Label ID="UserNameLabel"  CssClass="control-label" runat="server" AssociatedControlID="UserName">Adresse email</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="Un nom d'utilisateur est requis." ToolTip="Un nom d'utilisateur est requis." 
                                     ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
         
                        <div class="control-group">
                            <asp:Label ID="PasswordLabel" runat="server" CssClass="control-label" AssociatedControlID="Password">Mot de passe</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Un mot de passe est requis." ToolTip="Un mot de passe est requis." 
                                     ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
         
                        <div class="control-group">
                            <asp:Label ID="RememberMeLabel" CssClass="control-label"  runat="server" AssociatedControlID="RememberMe">Rester connecté</asp:Label>
                            <div class="controls">
                            
                            <asp:CheckBox ID="RememberMe" runat="server"/>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Se connecter" CssClass="btn btn-large btn-info" ValidationGroup="LoginUserValidationGroup"/>
                            </div>
                        </div>
                    </div>
                </fieldset>
                
            </div>
        </LayoutTemplate>
    </asp:Login>
    <p>
        Pas encore de compte ? 
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Rejoignez BindedIn</asp:HyperLink> !
    </p>
</asp:Content>
