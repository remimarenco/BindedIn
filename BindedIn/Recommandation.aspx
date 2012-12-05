

    <%@ Page Title="Recommandations" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Recommandation.aspx.cs" Inherits="BindedIn.Recommandation" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 ID="title" runat="server" >Recommandations</h2>
    <br />
    <asp:Label ID="not" runat="server"/>
    <div ID="recommandationList" runat="server" >
        <table class="table table-striped" >

            <tbody>
                <asp:Repeater ID="rpt" runat="server"  >
                        <ItemTemplate>
                            <tr>
                                <td><a href="<%# String.Format("RecommandationDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("message") %>
                                    </a>
                                </td>
                                <td>De: <a href="<%# String.Format("Profile.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("senderName") %>
                                    </a>
                                </td>
                                <td>
                                    <a href="<%# String.Format("Recommandation.aspx?del={0}", Eval("id")) %>" >
                                        <i class="icon-remove"></i>
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>  
</asp:Content>

