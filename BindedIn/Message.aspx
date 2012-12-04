<%@ Page Title="Ma messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="BindedIn.Message" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Mes messages</h2>
    <asp:Label ID="not" runat="server" />
    <div class="messageList" ID="messageList" runat="server" > 
        <asp:Repeater ID="rpt1" runat="server" onitemcommand="rpt1_ItemCommand" >
                <ItemTemplate>
                    <div class="messageItem" ID="messageItem" runat="server" > 
                        <br />
                        <asp:Label ID="date" Text='<%# Eval("date") %>' runat="server" />
                           <a href="<%# String.Format("MessageDetail.aspx?id={0}", Eval("id")) %>">
                                <%#Eval("object") %>
                            </a>

                            <asp:Image  ImageUrl="supprimer.png"  runat="server" />
                            <asp:Image  ImageUrl="repondreIcone.png" runat="server" />

                    </div>
                </ItemTemplate>
        </asp:Repeater>
    </div>   
</asp:Content>