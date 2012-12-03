<%@ Page Title="Ma Messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MessageDetail.aspx.cs" Inherits="BindedIn.MessageDetail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="messageD" runat="server" >
            <div ID="lien" runat="server" >
                <asp:Button ID="repondreButton" Text="Repondre" runat="server" 
                    onclick="repondreButton_Click" />
                <asp:Button ID="supprimerButton" Text="Supprimer" runat="server" 
                    onclick="supprimerButton_Click" />
            </div><br />
            <div ID="objectMessage" runat="server" >
                <b>De:</b> <asp:Label ID="destinataireM" runat="server" /><br />
                <b>Object:</b> <asp:Label ID="objectM" runat="server" />
            </div>
            <br />
             <div ID="corpsMessage" runat="server" >
               <asp:Label ID="message" runat="server" />
            </div>
        </div> 
</asp:Content>
