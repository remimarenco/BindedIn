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

    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span3">
                <asp:Image ID="ImageProfile" style="width:140px; height:140px" Runat="server" CssClass="img-polaroid" />
            </div>
            <div class="span9">
                <div class="row-fluid">
                    <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSourceUserProfile">  
                        <ItemTemplate>  
                            <h1 class="span9">
                                <%#Eval("FirstName") %> <%#Eval("LastName") %>
                            </h1>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row-fluid">
                    <asp:Button Text="Se connecter" runat="server" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <h2>Formation</h2>
    
    <div class="well">
        <div class="row-fluid">
            <asp:Button class="btn btn-info span2 offset10" ID="ButtonEditFormation" runat="server" Text="Modifier" 
                onclick="ButtonEdit_Click" />
        
            <div id="displayFormation" class="span11">
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
            <div id="editFormation" runat="server" class="span10">        
            
                <%-- Ajout du toolkitscript manager pour la suggestion (1seule instance autorisé par page)--%>
                <asp:ToolkitScriptManager ID="ToolkitScriptManagerFormation" runat="server">
                </asp:ToolkitScriptManager>

                <div class="form-horizontal">

                    <%--Ecole--%>
                    <div class="control-group">
                        <asp:Label ID="Label5" runat="server" Text="Etablissement" CssClass="control-label" />
                        <div class="controls">                    
                            <asp:TextBox ID="TextBoxFormationEtablissement" runat="server" Width="500px"></asp:TextBox>     
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" 
                                        TargetControlID="TextBoxFormationEtablissement" runat="server" 
                                MinimumPrefixLength="2" UseContextKey="True" 
                                EnableCaching="true" ServiceMethod="SuggestFormationSchool" />
                        </div>
                    </div>

                    <%--NOM--%>            
                    <div class="control-group">
                        <asp:Label ID="Label1" runat="server" Text="Nom de la formation" CssClass="control-label" />
                        <div class="controls">
                            <asp:TextBox ID="TextBoxFormationName" runat="server" Width="500px" />    
                            <asp:AutoCompleteExtender ID="AutoCompleteExtenderFormationName" 
                                        TargetControlID="TextBoxFormationName" runat="server" 
                                MinimumPrefixLength="2" UseContextKey="True" 
                                EnableCaching="true" ServiceMethod="SuggestFormationNames" />
                        </div>
                    </div>    

                    <%--Description--%>
                    <div class="control-group">                    
                        <asp:Label ID="Label2" runat="server" Text="Description" CssClass="control-label" />
                        <div class="controls">                 
                            <asp:TextBox ID="TextBoxFormationDescription" runat="server" Width="500px" />
                            <asp:AutoCompleteExtender ID="AutoCompleteExtenderFormationDescription" 
                                        TargetControlID="TextBoxFormationDescription" runat="server" 
                                MinimumPrefixLength="2" UseContextKey="True" 
                                EnableCaching="true" ServiceMethod="SuggestFormationDescription" />
                        </div>
                    </div>

                    <%--Date de début de la formation--%>
                    <div class="control-group">                    
                        <asp:Label ID="Label3" runat="server" Text="Date de début" CssClass="control-label" />
                        <div class="controls">    
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-calendar"></i></span>
                                <asp:TextBox ID="TextBoxDateDebut" runat="server" />
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxDateDebut" />
                            </div>
                        </div>
                    </div>

                    <%--Date de fin de la formation--%>
                    <div class="control-group">                    
                        <asp:Label ID="Label4" runat="server" Text="Date de fin" CssClass="control-label" />
                        <div class="controls"> 
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-calendar"></i></span>
                                <asp:TextBox ID="TextBoxDateFin" runat="server" />     
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxDateFin" />
                            </div>
                        </div>
                    </div>
           
                    <%--Submit--%>
                    <div class="control-group">  
                        <div class="controls"> 
                            <asp:Button class="btn span1" ID="ButtonSaveFormation" runat="server" CssClass="btn btn-large btn-success" Text="Enregistrer" 
                                onclick="ButtonSaveFormation_Click" />
                        </div>
                    </div>
                </div>
            </div> 
        </div>      
    </div>

    <h2>Experience professionelle</h2>
    <div class="row-fluid">
        
    <div class="well">
        <asp:Button class="btn btn-info span2 offset10" ID="ButtonEditExp" runat="server" Text="Modifier" 
            onclick="ButtonEdit_Click" />
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
            <div class="form-horizontal">

                <%--Company name--%>
                <div class="control-group">                    
                    <asp:Label ID="Label10" runat="server" Text="Société" CssClass="control-label" />
                    <div class="controls">  
                        <asp:TextBox ID="TextBoxExpProCompanyName" runat="server" Width="500px" />
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender4" 
                                    TargetControlID="TextBoxExpProCompanyName" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestExpProCompanyName" />
                    </div>
                </div>

                <%--NOM--%>
                <div class="control-group">                    
                    <asp:Label ID="Label6" runat="server" Text="Intitulé du poste" CssClass="control-label" />
                    <div class="controls">            
                        <asp:TextBox ID="TextBoxNomExpPro" runat="server" Width="500px" />
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" 
                                    TargetControlID="TextBoxNomExpPro" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestExpProNames" />
                    </div>
                </div>

                <%--Description--%>
                <div class="control-group">                    
                    <asp:Label ID="Label7" runat="server" Text="Description" CssClass="control-label" />
                    <div class="controls"> 
                        <asp:TextBox ID="TextBoxExpProDescription" runat="server" Width="500px" />   
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender3" 
                                    TargetControlID="TextBoxExpProDescription" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestExpProDescription" />
                    </div>
                </div>

                <%--Date de début de l'exp pro--%>
                <div class="control-group">                    
                    <asp:Label ID="Label8" runat="server" Text="Date de début" CssClass="control-label" />
                    <div class="controls"> 
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-calendar"></i></span>                
                            <asp:TextBox ID="TextBoxDateDebutEXpPro" runat="server" />          
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxDateDebutEXpPro" />
                        </div>
                    </div>
                </div>

                 <%--Date de fin de l'exp pro--%>
                 <div class="control-group">                    
                    <asp:Label ID="Label9" runat="server" Text="Date de fin" CssClass="control-label" />
                    <div class="controls"> 
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-calendar"></i></span>  
                            <asp:TextBox ID="TextBoxDateFinExpPro" runat="server" />  
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxDateFinExpPro" />
                        </div>
                    </div>
                </div>
           
                <%--Company Address--%>
                <div class="control-group">                    
                    <asp:Label ID="Label11" runat="server" Text="Adresse" CssClass="control-label" />
                    <div class="controls"> 
                        <asp:TextBox ID="TextBoxExpProCompanyAddress" runat="server" Width="500px" />         
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender5" 
                            TargetControlID="TextBoxExpProCompanyAddress" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestExpProCompanyAddress" />
                    </div>
                </div>

                <%--Company tel--%>
                <div class="control-group">                    
                    <asp:Label ID="Label12" runat="server" Text="Téléphone" CssClass="control-label" />
                    <div class="controls">                             
                        <asp:TextBox ID="TextBoxExpProCompanyTel" runat="server" Width="500px" />         
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender6" 
                            TargetControlID="TextBoxExpProCompanyTel" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestExpProCompanyTel" />
                    </div>
                </div>

                <div class="control-group">                    
                    <div class="controls">   
                        <asp:Button class="btn span1" ID="ButtonSaveExpPro" runat="server" Text="Enregistrer" CssClass="btn btn-large btn-success" 
                            onclick="ButtonSaveExpPro_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <h2>Compétences</h2>
    <div class="row-fluid">
        
    <div class="well">
        <asp:Button class="btn btn-info span2 offset10" ID="ButtonEditSkills" runat="server" Text="Modifier" 
            onclick="ButtonEdit_Click" />

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
            <div class="form-horizontal">
                <%--NOM--%>
                <div class="control-group">                    
                    <asp:Label ID="Label13" runat="server" Text="Nom" CssClass="control-label" />
                    <div class="controls">
                        <asp:TextBox ID="TextBoxCompeName" runat="server" Width="500px" />             
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender7" 
                            TargetControlID="TextBoxCompeName" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestCompetenceNames" />
                    </div>
                </div>

                <%--Description--%>
                <div class="control-group">                    
                    <asp:Label ID="Label14" runat="server" Text="Description" CssClass="control-label" />
                    <div class="controls">                        
                        <asp:TextBox ID="TextBoxCompeDescription" runat="server" Width="500px" />         
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender8" 
                            TargetControlID="TextBoxCompeDescription" runat="server" 
                            MinimumPrefixLength="2" UseContextKey="True" 
                            EnableCaching="true" ServiceMethod="SuggestCompetenceDescription" />
                    </div>
                </div>                

                <%--Niveau--%>
                <div class="control-group">                    
                    <asp:Label ID="Label15" runat="server" Text="Niveau" CssClass="control-label" />
                    <div class="controls"> 
                        <a href="#" id="rate1_A" style="text-decoration:none">  
                            <span id="rate1_Star_1" class="rating_star">&nbsp;</span>  
                            <span id="rate1_Star_2" class="rating_star">&nbsp;</span>  
                            <span id="rate1_Star_3" class="rating_star">&nbsp;</span>  
                            <span id="rate1_Star_4" class="rating_star">&nbsp;</span>  
                            <span id="rate1_Star_5" class="rating_star">&nbsp;</span>  
                        </a>  
                        <asp:Rating   
                        ID="RatingNiveau"   
                        CurrentRating="2"  
                        MaxRating="5"  
                        StarCssClass="rating_star"  
                        FilledStarCssClass="rating_filled"  
                        EmptyStarCssClass="rating_empty"  
                        WaitingStarCssClass="rating_empty"  
                        runat="server" />  
                    </div>
                </div> 
        
                <div class="control-group">                    
                    <div class="controls">   
                        <asp:Button CssClass="btn btn-large btn-success" ID="ButtonSkills" runat="server" Text="Enregistrer" 
                            onclick="ButtonSkills_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

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
</asp:Content>
