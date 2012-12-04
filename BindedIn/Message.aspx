<%@ Page Title="Ma messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="BindedIn.Message" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 ID="modeTitle" runat="server" >Mes messages Reçus</h2>
    <a  href="Message.aspx?mode=env" ID="autreMode"  runat="server">Mes messages Envoyés </a>
    <br />
    <asp:Label ID="not" runat="server"/>
    <div ID="messageList" runat="server" >
        <table class="table table-striped" >

            <tbody>
                <asp:Repeater ID="rptRece" runat="server" onitemcommand="rpt1_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("date") %></td>
                                <td><a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("object") %>
                                    </a>
                                </td>
                                <td>De: <a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("senderName") %>
                                    </a>
                                </td>
                                <td>
                                    <a href="<%# String.Format("MessageForm.aspx?response={0}", Eval("id")) %>" >
                                        <i class="icon-share-alt"></i>
                                    </a>
                                    <a href="<%# String.Format("Message.aspx?del={0}", Eval("id")) %>" >
                                        <i class="icon-remove"></i>
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptEnv" runat="server" onitemcommand="rpt1_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("date") %></td>
                                <td><a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("object") %>
                                    </a>
                                </td>
                                <td>A: <a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>" >
                                        <%#Eval("recipientName") %>
                                    </a>
                                </td>
                                <td>
                                    <a href="<%# String.Format("MessageForm.aspx?response={0}", Eval("id")) %>" >
                                        <i class="icon-share-alt"></i>
                                    </a>
                                    <a href="<%# String.Format("Message.aspx?del={0}", Eval("id")) %>" >
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