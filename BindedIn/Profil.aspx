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
                    TypeName="Business.FormationService" >
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
            
            <%-- Ajout du toolkitscript manager pour la suggestion (1seule instance autorisé par page)--%>
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
            <asp:ObjectDataSource ID="ObjectDataSourceEXpForUser" runat="server" SelectMethod="GetProferssionalExp"
                    TypeName="Business.ProfessionalExpService">
                    <SelectParameters>
                        <asp:Parameter Name="userId" DbType="Guid" DefaultValue="" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSourceEXpForUser">
                    <ItemTemplate>
                        <%#Eval("name") %>,
                        <%#Eval("description") %>
                    </ItemTemplate>
                </asp:Repeater>
        </div>            
        <div id="editExp" runat="server">      

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
            <%--Date de début de l'exp pro--%>
            <asp:Label ID="Label8" runat="server" Text="Date de début de la formation : "></asp:Label> 
               <asp:TextBox ID="TextBoxDateDebutEXpPro" runat="server"></asp:TextBox>             
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxDateDebutEXpPro">
            </asp:CalendarExtender>

             <%--Date de fin de l'exp pro--%>
            <asp:Label ID="Label9" runat="server" Text="Date de fin de la formation : "></asp:Label> 
               <asp:TextBox ID="TextBoxDateFinExpPro" runat="server"></asp:TextBox>             
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxDateFinExpPro">
            </asp:CalendarExtender>
             <br />

            <%--Company name--%>
            <asp:Label ID="Label10" runat="server" Text="Société : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProCompanyName" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender4" 
                        TargetControlID="TextBoxExpProCompanyName" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProCompanyName"                
                ></asp:AutoCompleteExtender>
            <%--Company Address--%>
            <asp:Label ID="Label11" runat="server" Text="Adresse : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProCompanyAddress" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender5" 
                        TargetControlID="TextBoxExpProCompanyAddress" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProCompanyAddress"                
                ></asp:AutoCompleteExtender>
            <%--Company tel--%>
            <asp:Label ID="Label12" runat="server" Text="Téléphone : "></asp:Label>             
            <asp:TextBox ID="TextBoxExpProCompanyTel" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender6" 
                        TargetControlID="TextBoxExpProCompanyTel" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestExpProCompanyTel"                
                ></asp:AutoCompleteExtender>

            <asp:Button class="btn span1" ID="ButtonSaveExpPro" runat="server" Text="Save" 
                onclick="ButtonSaveExpPro_Click" />
        </div>
            
  
    </div>
    <h2>Compétences</h2>
    <div class="row-fluid">
        <asp:Button class="btn span1 offset11" ID="ButtonEditSkills" runat="server" Text="Edit" 
            onclick="ButtonEdit_Click" /></div>
    <div class="well">

        <%--Affichage--%>
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

        <%--Edition--%>
        <div id="editSkills" runat="server">
             <%--NOM--%>
            <asp:Label ID="Label13" runat="server" Text="Nom : "></asp:Label> 
            
            <asp:TextBox ID="TextBoxCompeName" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender7" 
                        TargetControlID="TextBoxCompeName" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestCompetenceNames"                
                ></asp:AutoCompleteExtender>

                <br />

            <%--Description--%>
            <asp:Label ID="Label14" runat="server" Text="Description : "></asp:Label>             
            <asp:TextBox ID="TextBoxCompeDescription" runat="server"></asp:TextBox>           
            <asp:AutoCompleteExtender ID="AutoCompleteExtender8" 
                        TargetControlID="TextBoxCompeDescription" runat="server" 
                MinimumPrefixLength="2" UseContextKey="True" 
                EnableCaching="true" ServiceMethod="SuggestCompetenceDescription"                
                ></asp:AutoCompleteExtender>

                
                <br />

            <%--Niveau--%>

              <script type="text/javascript">
                          function onRated(sender, args) {
                              $get('log').innerHTML += "Rated: " + sender.get_Rating() + "<br/>";
                          }

                          Sys.require(Sys.components.rating, function () {
                              $("#rate1").rating({
                                  ClientStateFieldID: "state",
                                  Rating: 2,
                                  id: "rate1",
                                  Rated: onRated
                              });
                          });  
             </script>  
  

            <asp:Label ID="Label15" runat="server" Text="Niveau : "></asp:Label>   
             
                <a href="#" id="rate1_A" style="text-decoration:none">  
                    <span id="rate1_Star_1" class="rating_star" style="float:left;">&nbsp;</span>  
                    <span id="rate1_Star_2" class="rating_star" style="float:left;">&nbsp;</span>  
                    <span id="rate1_Star_3" class="rating_star" style="float:left;">&nbsp;</span>  
                    <span id="rate1_Star_4" class="rating_star" style="float:left;">&nbsp;</span>  
                    <span id="rate1_Star_5" class="rating_star" style="float:left;">&nbsp;</span>  
                </a>  
                  
             <asp:Rating   
                ID="RatingNiveau"   
                CurrentRating="2"  
                MaxRating="5"  
                StarCssClass="rating_star"  
                FilledStarCssClass="rating_filled"  
                EmptyStarCssClass="rating_empty"  
                WaitingStarCssClass="rating_empty"  
                runat="server" >  
        </asp:Rating>
        
            <asp:Button class="btn span1" ID="ButtonSkills" runat="server" Text="Save" 
                onclick="ButtonSkills_Click" />
        </div>
    </div>
                  <style type="text/css">  
                        .rating_star  
                        {  
                            font-size: 0pt;  
                            width:20px;  
                            height: 20px;  
                            margin: 5px;  
                            padding: 0px;  
                            cursor: pointer;  
                            display: block;  
                            background-repeat: no-repeat;  
                        }  
                        .rating_filled   
                        {  
                            background-color: Yellow;  
                        }  
                        .rating_empty   
                        {  
                            background-color: Gray;  
                        }  
                    </style>  
</asp:Content>
