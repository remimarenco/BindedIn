<%@ Page Title="Ma messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="BindedIn.Message" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 ID="modeTitle" runat="server" >Mes messages Reçus</h2>
    <a  ID="autreMode" href="Message.aspx?mode=env" runat="server"">Mes messages Envoyés </a>
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
                                    <a href="<%# String.Format("MessageForm.aspx?response={0}", Eval("id")) %>" >
                                        <i class="icon-share-alt"></i>
                                    </a>
                                    <i class="icon-remove"></i>
                                    <asp:Button Text="text" runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>  
</asp:Content>