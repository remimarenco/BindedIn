<%@ Page Title="Se connecter" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="BindedIn.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="fb-root"></div>
    <script type="text/javascript">
        window.fbAsyncInit = function () {
            FB.init({
                appId: '139094096241286', // App ID
                channelUrl: '//localhost:2588/channel.html',
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });

            // Additional initialization code here
            FB.getLoginStatus(function (response) {
                login();
            });
        };

        // Load the SDK Asynchronously
        (function (d) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = true;
            js.src = "//connect.facebook.net/en_US/all.js";
            ref.parentNode.insertBefore(js, ref);
        } (document));
    </script>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Se connecter</legend>              
                    <div class="form-horizontal">

                        <div class="control-group">
                            <asp:Label ID="UserNameLabel"  CssClass="control-label" runat="server" AssociatedControlID="UserName">Adresse email</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="Un nom d'utilisateur est requis." ToolTip="Un nom d'utilisateur est requis." 
                                     ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
         
                        <div class="control-group">
                            <asp:Label ID="PasswordLabel" runat="server" CssClass="control-label" AssociatedControlID="Password">Mot de passe</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Un mot de passe est requis." ToolTip="Un mot de passe est requis." 
                                     ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
         
                        <div class="control-group">
                            <asp:Label ID="RememberMeLabel" CssClass="control-label"  runat="server" AssociatedControlID="RememberMe">Rester connecté</asp:Label>
                            <div class="controls">
                            
                            <asp:CheckBox ID="RememberMe" runat="server"/>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Se connecter" CssClass="btn btn-large btn-info" ValidationGroup="LoginUserValidationGroup"/>
                            </div>
                        </div>
                    </div>
                </fieldset>
               
            </div>
        </LayoutTemplate>
          </asp:Login>
         <p>
        Pas encore de compte ? 
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Rejoignez BindedIn</asp:HyperLink> !
    </p>
  
    <div> <fieldset class="login">
                    <legend>Avec Facebook</legend>
        <div class="fb-login-button" data-show-faces="true" data-width="400" data-max-rows="1" data-size="xlarge" perms="email"></div>
        </fieldset>
    </div>
    
    <script type="text/javascript">
        function login() 
        {
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    // the user is logged in and has authenticated your
                    // app, and response.authResponse supplies
                    // the user's ID, a valid access token, a signed
                    // request, and the time the access token 
                    // and signed request each expire
                    var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;

                    // TODO: Handle the access token
                    // Do a post to the server to finish the logon
                    // This is a form post since we don't want to use AJAX
                    var form = document.createElement("form");
                    form.setAttribute("method", 'post');
                    form.setAttribute("action", '/FacebookLogin.ashx');

                    var field = document.createElement("input");
                    field.setAttribute("type", "hidden");
                    field.setAttribute("name", 'accessToken');
                    field.setAttribute("value", accessToken);
                    form.appendChild(field);

                    document.body.appendChild(form);
                    form.submit();

                } else if (response.status === 'not_authorized') {
                    // the user is logged in to Facebook, 
                    // but has not authenticated your app
                    
                } else {
                    // the user isn't logged in to Facebook.
                    
                }
                
            });
        }
    </script>
</asp:Content>
