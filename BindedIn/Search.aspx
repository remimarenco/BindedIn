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
                              <a class="pull-left" href="#">
                                <img class="media-object" src="http://placehold.it/64x64">
                              </a>  
                              <div class="media-body">
                                    <h4 class="media-heading"><%# Eval("firstname") %> <%# Eval("lastname") %></h4>  
                               </div>
                             </div>       
                        </a>
                        <br />    
                </ItemTemplate>
        </asp:Repeater>
</asp:Content>
