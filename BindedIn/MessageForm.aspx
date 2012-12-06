<%@ Page Title="Nouveau Message" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MessageForm.aspx.cs" Inherits="BindedIn.MessageForm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="messageForm" runat="server" >
            <div ID="senderMessage" runat="server" > 
                <div class="media" runat="server">
                    <a class="pull-left" ID="lienProfile" runat="server">
                        <asp:Image ID="ImageProfile" class="media-object"  ImageUrl="http://placehold.it/64x64" style="width:64px; height:64px"  CssClass="img-polaroid span3" runat="server" />
                    </a>  
                    <div class="media-body">
                        <div class="row-fluid" style="margin-top:15px;">
                            <strong class="span1" style="text-align:right;">A</strong> 
                            <div class="span11">
                                <a id="lienDestinataire2" runat="server"><asp:Label ID="recipientLabel"  runat="server" /></a>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <strong class="span1" style="text-align:right;">Sujet</strong> 
                            <div class="span11">
                                <asp:TextBox ID="objectTextBox" runat="server" Width="600px" />
                            </div>
                        </div>
                        
                    </div>
                </div>       
            </div>
            
            <textarea class="field span12" rows="10"  ID="message" runat="server" placeholder="Ecrivez votre message..."></textarea>
          

            <asp:Button ID="envoyerButton" Text="Envoyer" runat="server" CssClass="btn btn-large btn-success pull-right"
                onclick="envoyerButton_Click" />
        </div> 
</asp:Content>