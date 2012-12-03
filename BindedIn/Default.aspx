<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BindedIn._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="well">
    <h1>Formation</h1>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSourceFormation" runat="server" 
            SelectMethod="GetFormations" TypeName="Business.FormationService">
            <SelectParameters>
                <asp:Parameter Name="userId" DbType="Guid" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="RepeaterFormation" runat="server" 
        DataSourceID="ObjectDataSourceFormation">
            <ItemTemplate>
                <%#Eval("name") %>,  <%#Eval("description") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>
    </div>
    <h1>Experience professionelle</h1>
        <p>
        <asp:ObjectDataSource ID="ObjectDataSourceEXp" runat="server" 
            SelectMethod="GetProferssionalExp" TypeName="Business.ProfessionalExpService">
            <SelectParameters>
                <asp:Parameter Name="userId" DbType="Guid" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater1" runat="server" 
        DataSourceID="ObjectDataSourceEXp">
            <ItemTemplate>
                <%#Eval("name") %>,  <%#Eval("description") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>
    <h1>Compétences</h1>
      <p>
        <asp:ObjectDataSource ID="ObjectDataSourceSkills" runat="server" 
            SelectMethod="GetSkills" TypeName="Business.SkillService">
            <SelectParameters>
                <asp:Parameter Name="userId" DbType="Guid" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater2" runat="server" 
        DataSourceID="ObjectDataSourceSkills">
            <ItemTemplate>
                <%#Eval("name") %>,  <%#Eval("description") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>
</asp:Content>
