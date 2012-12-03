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

    <p>
        <asp:ObjectDataSource ID="ObjectDataSourceRelation" runat="server" 
            SelectMethod="GetRelations" TypeName="Business.RelationService" 
            onselecting="ObjectDataSourceRelation_Selecting">
            <SelectParameters>
                <asp:Parameter DbType="Guid" Name="userId" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater3" runat="server" 
        DataSourceID="ObjectDataSourceRelation">
            <ItemTemplate>
                <%#Eval("Lastname") %>, <%#Eval("Firstname") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>   
</asp:Content>
