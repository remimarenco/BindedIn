<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Profil.aspx.cs" Inherits="BindedIn.Profil" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
        <asp:Image ID="ImageProfile" style="width:140px; height:140px" Runat="server" CssClass="img-polaroid span3" />
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
            
            <%-- Ajout du toolkitscript manager pour la suggestion--%>
            <asp:ToolkitScriptManager ID="ToolkitScriptManagerFormation" runat="server">
            </asp:ToolkitScriptManager>

            <%--NOM--%>
            <asp:Label ID="Label1" runat="server" Text="Nom : "></asp:Label> 
            
            <asp:TextBox ID="TextBoxFormationName" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtenderFormationName" 
                        TargetControlID="TextBoxFormationName" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestFormationNames"                
                ></asp:AutoCompleteExtender>

                <br />

            <%--Description--%>
            <asp:Label ID="Label2" runat="server" Text="Description : "></asp:Label>             
            <asp:TextBox ID="TextBoxFormationDescription" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtenderFormationDescription" 
                        TargetControlID="TextBoxFormationDescription" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestFormationDescription"                
                ></asp:AutoCompleteExtender>
            <br />
            <%--Date de début de la formation--%>
            <asp:Label ID="Label3" runat="server" Text="Date de début de la formation : "></asp:Label> 
               <asp:TextBox ID="TextBoxDateDebut" runat="server"></asp:TextBox>             
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxDateDebut">
            </asp:CalendarExtender>

             <%--Date de fin de la formation--%>
            <asp:Label ID="Label4" runat="server" Text="Date de fin de la formation : "></asp:Label> 
               <asp:TextBox ID="TextBoxDateFin" runat="server"></asp:TextBox>             
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxDateFin">
            </asp:CalendarExtender>
             <br />

            <%--Ecole--%>
            <asp:Label ID="Label5" runat="server" Text="Etablissement : "></asp:Label>             
            <asp:TextBox ID="TextBoxFormationEtablissement" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" 
                        TargetControlID="TextBoxFormationEtablissement" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestFormationSchool"                
                ></asp:AutoCompleteExtender>

            <asp:Button class="btn span1" ID="ButtonSaveFormation" runat="server" Text="Save" 
                onclick="ButtonSaveFormation_Click" />
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
          <%-- Ajout du toolkitscript manager pour la suggestion--%>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>

            <%--NOM--%>
            <asp:Label ID="Label6" runat="server" Text="Nom : "></asp:Label> 
            
            <asp:TextBox ID="TextBoxNomExpPro" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" 
                        TargetControlID="TextBoxNomExpPro" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProNames"                
                ></asp:AutoCompleteExtender>

                <br />

            <%--Description--%>
            <asp:Label ID="Label7" runat="server" Text="Description : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProDescription" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" 
                        TargetControlID="TextBoxExpProDescription" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProDescription"                
                ></asp:AutoCompleteExtender>
            <br />
            <%--Date de début de la formation--%>
            <asp:Label ID="Label8" runat="server" Text="Date de début de la formation : "></asp:Label> 
               <asp:TextBox ID="TextBoxDateDebutEXpPro" runat="server"></asp:TextBox>             
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxDateDebutEXpPro">
            </asp:CalendarExtender>

             <%--Date de fin de la formation--%>
            <asp:Label ID="Label9" runat="server" Text="Date de fin de la formation : "></asp:Label> 
               <asp:TextBox ID="TextBoxDateFinExpPro" runat="server"></asp:TextBox>             
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxDateFinExpPro">
            </asp:CalendarExtender>
             <br />

            <%--Company name--%>
            <asp:Label ID="Label10" runat="server" Text="Etablissement : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProCompanyName" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender4" 
                        TargetControlID="TextBoxExpProCompanyName" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProCompanyName"                
                ></asp:AutoCompleteExtender>
            <%--Company Address--%>
            <asp:Label ID="Label11" runat="server" Text="Etablissement : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProCompanyAddress" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender5" 
                        TargetControlID="TextBoxExpProCompanyAddress" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProCompanyAddress"                
                ></asp:AutoCompleteExtender>
            <%--Company tel--%>
            <asp:Label ID="Label12" runat="server" Text="Etablissement : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProCompanyTel" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender6" 
                        TargetControlID="TextBoxExpProCompanyTel" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProCompanyTel"                
                ></asp:AutoCompleteExtender>

            <asp:Button class="btn span1" ID="ButtonSaveExpPro" runat="server" Text="Save" />
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
