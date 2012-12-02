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
        <p>
        <asp:ObjectDataSource ID="ObjectDataSourceEXp" runat="server" 
            SelectMethod="GetProferssionalExp" TypeName="Business.ProfessionalExpService">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="userId" Type="Int32" />
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
                <asp:Parameter DefaultValue="2" Name="userId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater2" runat="server" 
        DataSourceID="ObjectDataSourceSkills">
            <ItemTemplate>
                <%#Eval("name") %>,  <%#Eval("description") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>
    <h1>Relations</h1>
      <p>
        <asp:ObjectDataSource ID="ObjectDataSourceRelation" runat="server" 
            SelectMethod="GetRelations" TypeName="Business.RelationService">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="userId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater3" runat="server" 
        DataSourceID="ObjectDataSourceRelation">
            <ItemTemplate>
                Nom : <%#Eval("lastname") %>, prenom :  <%#Eval("firstname") %>
            </ItemTemplate>
        </asp:Repeater>
    </p>
</asp:Content>
