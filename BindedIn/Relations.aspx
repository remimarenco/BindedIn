<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relations.aspx.cs" Inherits="BindedIn.Relations" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Relations
    </h2>
    <p>
        Voici vos relations :
    </p>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getRelationsOfId" TypeName="Business.Relations">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="userID" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <p><a href="Profil.aspx?userID=<%#Eval("id") %>"><%#Eval("lastname") %>, <%#Eval("firstname") %></a></p>
        </ItemTemplate>
    </asp:Repeater> 
       
</asp:Content>
