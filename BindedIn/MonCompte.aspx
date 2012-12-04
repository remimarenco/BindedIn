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

    <h1>Mon Compte</h1>
    <h2>Photo de profil</h2>
    
    <div class="well">
        <h3>Ajouter une photo</h3>

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="lblMessage" runat="server">
        </asp:Label>
        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-large btn-success" 
                OnClick="btnUpload_Click" Text="Envoyer"/>

        <h3>Mes photos</h3>
        <div class="row profile-img">
            <asp:Repeater ID="Repeater1" runat="server" 
                DataSourceID="ObjectDataSourceImage">
                <ItemTemplate>                  
                    <div class="span2">
                        <img src="/ShowImage.ashx?idimg=<%#Eval("id") %>" class="img-polaroid profile-list-img" id="<%#Eval("id") %>" alt="pic" />   
                        <%# DisplaySpanCurrent(Eval("Current")) %>    
                        <span class="label label-info select-info">Select</span> 
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row">
            <input id="idImageSelected" type="hidden" class="idImageSelected" runat="server" value="" />
            <asp:Button ID="btnChangeImg" runat="server" CssClass="btn btn-large btn-success" 
                    OnClick="btnChange_Click" Text="Utiliser"/>
            <asp:Button ID="btnDeleteImg" runat="server" CssClass="btn btn-large btn-danger" 
                OnClick="btnDeleteImg_Click" Text="Supprimer"/>
        </div>
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
    <script type="text/javascript">
        var selected = null;

        $(document).ready(function () {
            $(".select-info").hide();

            $(".profile-list-img").click(function () {
                var visible = $(this).next(".select-info").is(':visible');
                $(".select-info").hide();
                if (!visible) {
                    $(this).next(".select-info").show();
                    $(".idImageSelected").val($(this).attr("id"));
                }
                else $(".idImageSelected").val("");
            });
        });
    </script>
</asp:Content>
