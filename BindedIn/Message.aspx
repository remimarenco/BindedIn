<%@ Page Title="Ma messagerie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="BindedIn.Message" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Mes messages</h2>
    <div class="messageList"> 
        <asp:Repeater ID="rpt1" runat="server" onitemcommand="rpt1_ItemCommand" >
                <ItemTemplate>
                    <div class="messageItem"> 
                        <br />
                        <asp:Label ID="Label1" Text='<%# Eval("date") %>' runat="server" />
                        <asp:Label ID="Label2" Text='<%# Eval("object") %>' runat="server" />
                        <asp:Image ID="supprimer" ImageUrl="supprimer.png" runat="server" />
                    </div>
                </ItemTemplate>
        </asp:Repeater>
    </div>   
</asp:Content>