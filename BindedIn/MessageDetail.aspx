<%@ Page Title="Ma Messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MessageDetail.aspx.cs" Inherits="BindedIn.MessageDetail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Label ID="not" runat="server" />
        <div ID="messageD" runat="server" >
            
            <div ID="senderMessage" runat="server">
                   <div class="media">
                        <a  class="pull-left" id="lienDestinataire1" runat="server" >
                            <asp:Image ID="ImageProfile" class="media-object"  ImageUrl="http://placehold.it/64x64" style="width:100px; height:100px"  CssClass="img-polaroid span3" runat="server" />
                        </a>
                        <div class="media-body" style="margin-bottom:35px;">
                           
                                <div class="row-fluid" style="margin-top:15px;">
                                    <strong class="span1" style="text-align:right;">De</strong> 
                                    <div class="span11">
                                        <a id="lienDestinataire2" runat="server"><asp:Label ID="destinataireM"  runat="server" /></a>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <strong class="span1" style="text-align:right;">Le</strong> 
                                    <div class="span11">
                                        <span id="dateMessage" runat="server"></span>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <strong class="span1" style="text-align:right;">Sujet</strong> 
                                    <div class="span11">
                                        <asp:Label ID="objectM"  runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                   
            </div>
            

            <div class="well">
                <div ID="corpsMessage" runat="server" >
                   <asp:Label ID="message" runat="server" />
                </div>
            </div>

            <div ID="lien2" runat="server" >
                <asp:Button ID="Button1"  class="btn btn-success" Text="Repondre" runat="server" 
                    onclick="repondreButton_Click" />
                <asp:Button ID="Button2" class="btn btn-danger" Text="Supprimer" runat="server" 
                    onclick="supprimerButton_Click" />
            </div><br />
        </div> 
</asp:Content>
