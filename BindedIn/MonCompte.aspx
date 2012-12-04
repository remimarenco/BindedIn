<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonCompte.aspx.cs" Inherits="BindedIn.MonCompte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSourceImage" runat="server" 
        SelectMethod="GetAllImages" TypeName="Business.ImagesService">
        <SelectParameters>
            <asp:Parameter DbType="Guid" Name="userId" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <h2>Mon Compte</h2>
    <h3>Photo de profil</h3>
    <div class="well">
        <asp:FileUpload ID="FileUpload1" runat="server"/>
        <asp:Label ID="lblMessage" runat="server">
        </asp:Label>
        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-large btn-success" 
                OnClick="btnUpload_Click" Text="Envoyer"/>
        <asp:Repeater ID="Repeater1" runat="server" 
            DataSourceID="ObjectDataSourceImage">
            <ItemTemplate>                  
                <%--<asp:Image ID="ImageProfile" style="width:140px; height:140px" Runat="server" CssClass="img-polaroid span3" ImageUrl="/ShowImage.ashx?idimg=<%#Eval("id") %>" />--%>
                <img src="/ShowImage.ashx?idimg=<%#Eval("id") %>" class="img-polaroid profile-list-img" alt="pic" />           
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <h3>Changer le mot de passe</h3>
    <div class="well">
        <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false" 
             SuccessPageUrl="Account/ChangePasswordSuccess.aspx">
            <ChangePasswordTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                     ValidationGroup="ChangeUserPasswordValidationGroup"/>
                <div class="accountInfo">
                    <fieldset class="changePassword">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <asp:Label ID="CurrentPasswordLabel" CssClass="control-label" runat="server" AssociatedControlID="CurrentPassword">Ancien mot de passe</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                                     CssClass="failureNotification" ErrorMessage="Un mot de passe est requis." ToolTip="L'ancien mot de passe est requis." 
                                     ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="NewPasswordLabel" runat="server" CssClass="control-label" AssociatedControlID="NewPassword">Nouveau mot de passe</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                                     CssClass="failureNotification" ErrorMessage="Un nouveau mot de passe est requis." ToolTip="Un nouveau mot de passe est requis." 
                                     ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" CssClass="control-label" AssociatedControlID="ConfirmNewPassword">Confirmer</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="La confirmation du nouveau mot de passe est requise."
                                     ToolTip="La confirmation du nouveau mot de passe est requise." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="La valeur de Confirmer le nouveau mot de passe doit correspondre à l'entrée Nouveau mot de passe."
                                     ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                            </div>
                        </div

                        <div class="control-group">
                            <div class="controls">
                                <%--<asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler"/>--%>
                                <asp:Button ID="ChangePasswordPushButton" runat="server" CssClass="btn btn-large btn-success" CommandName="ChangePassword" Text="Enregistrer" 
                                     ValidationGroup="ChangeUserPasswordValidationGroup"/>
                            </div>
                        </div
                    </div>
                    </fieldset>
                
                </div>
            </ChangePasswordTemplate>
        </asp:ChangePassword>
    </div>
</asp:Content>
