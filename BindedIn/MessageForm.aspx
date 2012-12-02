<%@ Page Title="Nouveau Message" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MessageForm.aspx.cs" Inherits="BindedIn.MessageForm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="messageForm" runat="server" >
            <div ID="infoMessage" runat="server" >
                <b>A:</b> <asp:Label ID="recipientLabel" runat="server" /> <br />
                <b>Object:</b> <asp:TextBox ID="objectTextBox" runat="server" />
            </div>
            <br />
             <div ID="corpsMessage" runat="server" >
               <asp:TextBox mode="multiline"  ID="message" runat="server" />
            </div>

            <asp:Button ID="envoyerButton" Text="Envoyer" runat="server" 
                onclick="envoyerButton_Click" />
        </div> 
</asp:Content>