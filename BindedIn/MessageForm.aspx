<%@ Page Title="Nouveau Message" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MessageForm.aspx.cs" Inherits="BindedIn.MessageForm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="messageForm" runat="server" >
            <div ID="senderMessage" runat="server" style="border-bottom: 1px solid black; margin-top:5px;" > 
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
                                <asp:TextBox ID="objectTextBox" runat="server" />
                            </div>
                        </div>
                        
                    </div>
                </div>       
            </div>
            <div ID="objectMessage" runat="server" style="border-bottom: 1px solid black; margin-top:5px;" >
                
            </div>
            <br />
             <div ID="corpsMessage" style="border-bottom: 1px solid black; margin-top:5px;min-height:200px;" runat="server" >
               <textarea rows="10" cols="120"   ID="message" runat="server"> </textarea>
            </div>

            <asp:Button ID="envoyerButton" Text="Envoyer" runat="server" 
                onclick="envoyerButton_Click" />
        </div> 
</asp:Content>