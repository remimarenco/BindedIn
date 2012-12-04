<%@ Page Title="Ma messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="BindedIn.Message" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 ID="modeTitle" runat="server" >Mes messages Reçus</h2>
    <asp:Label ID="not" runat="server" />
    <div ID="messageList" runat="server" >
        <table class="table table-striped" >

            <tbody>
                <asp:Repeater ID="rpt1" runat="server" onitemcommand="rpt1_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("date") %></td> 
                                <td><a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("object") %>
                                    </a>
                                </td>
                                <td>
                                    <i class="icon- icon-share-alt"></i>
                                    <i class="icon-remove"></i>
                                </td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>  
</asp:Content>