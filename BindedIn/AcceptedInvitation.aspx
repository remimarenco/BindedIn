<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcceptedInvitation.aspx.cs" Inherits="BindedIn.AcceptedInvitation" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h1>Bravo !</h1>
        <p>Vous êtes maintenant en relation avec 
            <asp:LinkButton ID="linkUserAsking" Text="" runat="server" /> !</p>
    </div>
</asp:Content>
