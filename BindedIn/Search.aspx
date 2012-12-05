<%@ Page Title="Recherche" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="BindedIn.Search" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div ID="searchHeader" runat="server">
           <h2><asp:Label ID="sTitle" Text='' runat="server" /></h2>
           <asp:Label ID="sMessage" Text='' runat="server" />
    </div>
        <asp:Repeater ID="rpt1" runat="server" >
                <ItemTemplate>
                        <a href="#" runat="server"> 
                            <div class="media">
                              <a class="pull-left" href="<%# String.Format("Profile.aspx?id={0}", Eval("UserName")) %>">
                                <img class="media-object" src="http://placehold.it/64x64">
                              </a>  
                              <div class="media-body">
                                   
                                        <h4 class="media-heading">
                                            <a class="pull-left" href="<%# String.Format("Profil.aspx?id={0}", Eval("UserName")) %>">
                                                <%# Eval("firstname") %> <%# Eval("lastname") %>
                                            </a>
                                        </h4>
                                   
                                    <br /><a href="<%# String.Format("MessageForm.aspx?id={0}", Eval("UserName")) %>" > <i class=" icon-envelope"></i>Envoyer un message</a>
                                    <br /><a href="<%# String.Format("RecommandationForm.aspx?id={0}", Eval("UserName")) %>" > <i class="icon-thumbs-up"></i>Recommander cette personne</a>
                               </div>
                             </div>       
                        </a>
                        <br />    
                </ItemTemplate>
        </asp:Repeater>
</asp:Content>
