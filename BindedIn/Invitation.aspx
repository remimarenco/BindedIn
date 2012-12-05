<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invitation.aspx.cs" Inherits="BindedIn.Invitation" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="hero-unit">
        <h2>
            <i class="icon-envelope"></i>
            Invitez <asp:Label ID="nearRelationFirstName" runat="server">Julien</asp:Label> à se connecter à vous
        </h2>
        <asp:Label Text="Rédigez un message personnel : (facultatif)" runat="server" />
        <div class="row-fluid">
            <asp:TextBox class="span8" Rows="5" TextMode="multiline" ID="message" runat="server" />
        </div>
        <div class="row-fluid">
            <div class="span3 offset2">
                <asp:Button runat="server" class="btn btn-primary" type="button" 
                    Text="Envoyer l'invitation" onclick="envoyerInvitation_Click" />
            </div>
            <div class="span2">
                <!-- Retourne sur le profil que l'on était en train de regarder -->
                <a href="#">Annuler</a>
            </div>
        </div>
    </div>
</asp:Content>
