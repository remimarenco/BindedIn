<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BindedIn._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Formation</h1>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSourceFormation" runat="server" 
            SelectMethod="GetFormations" TypeName="Business.FormationService">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="userId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="RepeaterFormation" runat="server" 
        DataSourceID="ObjectDataSourceFormation">
            <ItemTemplate>
                <%#Eval("name") %>,  <%#Eval("description") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>
    <h1>Experience professionelle</h1>
    <h1>Compétences</h1>
    <h1>Relations</h1>
</asp:Content>
