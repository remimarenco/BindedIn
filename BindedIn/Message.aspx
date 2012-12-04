<%@ Page Title="Ma messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="BindedIn.Message" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 ID="modeTitle" runat="server" >Mes messages Reçus</h2>
    <a  href="Message.aspx?mode=env" ID="autreMode"  runat="server">Mes messages Envoyés </a>
    <br />
    <asp:Label ID="not" runat="server" />
    <div ID="messageList" runat="server" >
        <table class="table table-striped" >

            <tbody>
                <asp:Repeater ID="rpt1" runat="server" onitemcommand="rpt1_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td><%# String.Format("{0:dd/MM/yyyy}", Eval("date"))%></td> 
                                <td><a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("object") %>
                                    </a>
                                </td>
                                <td>
                                    <a href="<%# String.Format("MessageForm.aspx?response={0}", Eval("id")) %>" >
                                        <i class="icon-share-alt"></i>
                                    </a>
                                    <i class="icon-remove"></i>
                                </td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>  
</asp:Content>