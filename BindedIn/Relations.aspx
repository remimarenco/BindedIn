<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relations.aspx.cs" Inherits="BindedIn.Relations" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Relations
    </h2>
    <p>
        Voici vos relations
    </p>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <a href="<%# String.Format("DetailCustomer.aspx?id={0}", Eval("CustomerID")) %>">
                <%#Eval("CustomerID") %><%#Eval("ContactName") %></a>
            <br>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="getCustomers" TypeName="Business.Customer">
    </asp:ObjectDataSource>
</asp:Content>
