<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonCompte.aspx.cs" Inherits="BindedIn.MonCompte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mon Compte</h2>
    <h3>Photo de profil</h3>
    <asp:FileUpload ID="FileUpload1" runat="server"/>
    <asp:Label ID="lblMessage" runat="server">
    </asp:Label>
    <asp:Button ID="btnUpload" runat="server" 
            OnClick="btnUpload_Click" Text="Upload"/>
</asp:Content>
