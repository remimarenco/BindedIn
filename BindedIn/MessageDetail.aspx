<%@ Page Title="Ma Messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MessageDetail.aspx.cs" Inherits="BindedIn.MessageDetail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="messageD" runat="server" >
            <div ID="lien" runat="server" >
                <asp:Button ID="repondreButton"  class="btn" Text="Repondre" runat="server" 
                    onclick="repondreButton_Click" />
                <asp:Button ID="supprimerButton" class="btn" Text="Supprimer" runat="server" 
                    onclick="supprimerButton_Click" />
            </div><br />
            <div ID="senderMessage" runat="server" >
                <b>De: </b> <asp:Label ID="destinataireM" runat="server" /><br />
            </div>
            <div ID="objectMessage" runat="server" >
                <b>Object: </b> <asp:Label ID="objectM" runat="server" />
            </div>

            <br />
             <div ID="corpsMessage" runat="server" >
               <asp:Label ID="message" runat="server" />
            </div>

            <div ID="Div1" runat="server" >
                <asp:Button ID="Button1"  class="btn" Text="Repondre" runat="server" 
                    onclick="repondreButton_Click" />
                <asp:Button ID="Button2" class="btn" Text="Supprimer" runat="server" 
                    onclick="supprimerButton_Click" />
            </div><br />
        </div> 
</asp:Content>
