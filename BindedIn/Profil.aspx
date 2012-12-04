<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Profil.aspx.cs" Inherits="BindedIn.Profil" %>

<%@ Register Assembly="Vortex.Web.UI.WebControls" Namespace="Vortex.Web.UI.WebControls"
    TagPrefix="vortex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSourceUserProfile" runat="server" 
        SelectMethod="GetUtilisateurById" TypeName="Business.UserProfileService">
        <SelectParameters>
            <asp:Parameter DbType="Guid" Name="id" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <div class="row">
        <asp:Image ID="ImageProfile" style="width:200px; height:200px" Runat="server" CssClass="img-polaroid span3" />
        <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSourceUserProfile">  
            <ItemTemplate>  
                <h1 class="span9">
                    <%#Eval("FirstName") %> <%#Eval("LastName") %>
                </h1>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <h2>Formation</h2>
    <div class="row-fluid">
        <asp:Button class="btn span1 offset11" ID="ButtonEditFormation" runat="server" Text="Edit" 
            onclick="ButtonEdit_Click" /></div>
    <div class="well">
        <div id="displayFormation">
            <asp:ObjectDataSource ID="ObjectDataSourceFormationForUser" runat="server" SelectMethod="GetFormations"
                    TypeName="Business.FormationService">
                    <SelectParameters>
                        <asp:Parameter Name="userId" DbType="Guid" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Repeater ID="RepeaterFormation" runat="server" DataSourceID="ObjectDataSourceFormationForUser">
                    <ItemTemplate>
                        <%#Eval("name") %>,
                        <%#Eval("description") %>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        <div id="editFormation" runat="server">

            <asp:ObjectDataSource ID="ObjectDataSourceFormations" runat="server" 
                SelectMethod="GetFormations" TypeName="Business.FormationService"></asp:ObjectDataSource>
            <asp:Label ID="Label1" runat="server" Text="Nom"></asp:Label>            
           
        </div>
            
       
    </div>
    <h2>Experience professionelle</h2>
    <div class="row-fluid">
        <asp:Button class="btn span1 offset11" ID="ButtonEditExp" runat="server" Text="Edit" 
            onclick="ButtonEdit_Click" /></div>
    <div class="well">
        <div id="showExp">
            <asp:ObjectDataSource ID="ObjectDataSourceEXp" runat="server" SelectMethod="GetProferssionalExp"
                    TypeName="Business.ProfessionalExpService">
                    <SelectParameters>
                        <asp:Parameter Name="userId" DbType="Guid" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSourceEXp">
                    <ItemTemplate>
                        <%#Eval("name") %>,
                        <%#Eval("description") %>
                    </ItemTemplate>
                </asp:Repeater>
        </div>            
        <div id="editExp" runat="server">
        LOL
        </div>
            
  
    </div>
    <h2>Compétences</h2>
    <div class="row-fluid">
        <asp:Button class="btn span1 offset11" ID="ButtonEditSkills" runat="server" Text="Edit" 
            onclick="ButtonEdit_Click" /></div>
    <div class="well">
        <div id="displaySkills">
            <asp:ObjectDataSource ID="ObjectDataSourceSkillsForUser" runat="server" SelectMethod="GetSkills"
                TypeName="Business.SkillService">
                <SelectParameters>
                    <asp:Parameter Name="userId" DbType="Guid" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSourceSkillsForUser">
                <ItemTemplate>
                    <%#Eval("name") %>,
                    <%#Eval("description") %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="editSkills" runat="server">
            <asp:ObjectDataSource ID="ObjectDataSourceSkills" runat="server" SelectMethod="GetSkills"
                TypeName="Business.SkillService"></asp:ObjectDataSource>
            <asp:DropDownList ID="DropDownListSkills" runat="server" DataSourceID="ObjectDataSourceSkills"
                DataTextField="name" DataValueField="id">
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
