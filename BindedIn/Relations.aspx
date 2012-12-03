<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relations.aspx.cs" Inherits="BindedIn.Relations" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<asp:ObjectDataSource ID="ObjectDataSourceRelation" runat="server" 
                            SelectMethod="GetRelations" TypeName="Business.RelationService" >
    <SelectParameters>
        <asp:Parameter DbType="Guid" Name="userId" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSourceFarFromOneRelation" runat="server" 
                            SelectMethod="GetFarFromOneRelations" TypeName="Business.RelationService">
    <SelectParameters>
        <asp:Parameter DbType="Guid" Name="userId" />
    </SelectParameters>
</asp:ObjectDataSource>

    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span9">
                <div class="hero-unit">
                    <h1>Relations</h1>
                    <p>
                        Voici vos relations :
                    </p>
                    <p>
                        <asp:Repeater ID="Repeater3" runat="server" 
                        DataSourceID="ObjectDataSourceRelation">
                            <ItemTemplate>
                                <p><%#Eval("Lastname") %>, <%#Eval("Firstname") %></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </p>
                </div>
            </div>
            <div class="span3">
                <div class="well sidebar-nav">
                    <ul class="nav nav-list">
                        <li class="nav-header">Vous connaissez peut-être :</li>
                        <asp:Repeater ID="Repeater2" runat="server" 
                        DataSourceID="ObjectDataSourceFarFromOneRelation">
                            <ItemTemplate>
                                <li><%#Eval("Lastname") %>, <%#Eval("Firstname") %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div> 
        </div>  
    </div>
                  
</asp:Content>
