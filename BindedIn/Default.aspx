<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BindedIn._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <section>

        <br />
    <br />
    <br />

       <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetUtilisateurs" TypeName="Business.UtilisateurService">
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
        <%#Eval("Nom") %> , <%#Eval("Prenom") %><br />
        </ItemTemplate>
        </asp:Repeater>   --%>
        <asp:Label ID="Label1" runat="server" Text="Favorite Movie :"></asp:Label>
    &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="ButUpdate" runat="server" onclick="ButUpdate_Click" 
            Text="Update" />
    </section>
    <section>
        <h2>Formation</h2>
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
    </section>
    <section>
        <h2>Experience professionelle</h2>
    </section>
    <section>
        <h2>Compétences</h2>
    </section>
    <section>
        <h2>Relations</h2>
    </section>
</asp:Content>
