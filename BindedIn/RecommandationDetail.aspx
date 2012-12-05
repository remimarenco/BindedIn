<%@ Page Title="Recommandation" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="RecommandationDetail.aspx.cs" Inherits="BindedIn.RecommandationDetail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="recommandationD" runat="server" >
            <div ID="lien" runat="server" >
                <asp:Button ID="supprimerButton" class="btn" Text="Supprimer" runat="server" 
                    onclick="supprimerButton_Click" />
            </div><br />
            <div ID="senderMessage" runat="server" style="border-bottom: 1px solid black; margin-top:5px;" >

                    <div class="media">
                        <a class="pull-left" ID="lienProfile" runat="server">
                            <img class="media-object" src="http://placehold.it/64x64">
                        </a>  
                        <div class="media-body">
                            <b>Recommandation de: </b> <br /><asp:Label ID="destinataireM"  runat="server" /><br />
                        </div>
                    </div> 
            </div>
            <br />
             <div ID="corpsMessage" style="border-bottom: 1px solid black; margin-top:5px;min-height:200px;" runat="server" >
               <asp:Label ID="message" runat="server" />
            </div>

            <div ID="lien2" runat="server" >
                <asp:Button ID="Button2" class="btn" Text="Supprimer" runat="server" 
                    onclick="supprimerButton_Click" />
            </div><br />
        </div> 
</asp:Content>
