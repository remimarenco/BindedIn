<%@ Page Title="Recherche" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="BindedIn.Search" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="searchResult"> 
        <asp:Repeater ID="rpt1" runat="server" >
                <ItemTemplate>
                    <div class="searchItem"> 
                        <br />
                        <asp:Label ID="Label1" Text='<%# Eval("firstname") %>' runat="server" />
                        <asp:Label ID="Label2" Text='<%# Eval("lastname") %>' runat="server" />
                    </div>
                </ItemTemplate>
        </asp:Repeater>
    </div>   
</asp:Content>
