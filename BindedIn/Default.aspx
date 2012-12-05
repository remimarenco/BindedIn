<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BindedIn._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     </div> <%--End container--%>
     <!-- Carousel
    ================================================== -->
    <div id="myCarousel" class="carousel slide">
      <div class="carousel-inner">
        <div class="item active">
          <img src="/Images/buildings-riot-sized-flou.jpg" alt="">
          <div class="container">
            <div class="carousel-caption">
              <h1>Boostez votre carrière.</h1>
              <p class="lead">Rencontrez des entreprises, des recruteurs et saisissez les opportunités qui s'offrent à vous.</p>
              <a class="btn btn-large btn-primary" href="/Account/Register.aspx">Rejoindre BindedIn</a>
            </div>
          </div>
        </div>
        <div class="item">
          <img src="/Images/office-flou.jpg" alt="">
          <div class="container">
            <div class="carousel-caption">
              <h1>Batissez votre réseau professionnel.</h1>
              <p class="lead">Retrouvez tous vos collaborateurs, échangez et constuisez votre image professionnelle.</p>
              <a class="btn btn-large btn-primary" href="/Account/Register.aspx">Rejoindre BindedIn</a>
            </div>
          </div>
        </div>        
      </div>
      <a class="left carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
      <a class="right carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
    </div><!-- /.carousel -->

    <hr class="featurette-divider">

    <!-- Marketing messaging and featurettes
    ================================================== -->
    <!-- Wrap the rest of the page in another container to center all the content. -->

    <div class="container marketing">

      <!-- Three columns of text below the carousel -->
      <div class="row">
        <div class="span4">
          <img src="/Images/resume.png">
          <h2>Curriculum Vitae</h2>
          <p>Gérez votre image en rédigant votre CV public en ligne sur BindedIn.</p>
          <%--<p><a class="btn" href="#">View details &raquo;</a></p>--%>
        </div><!-- /.span4 -->
        <div class="span4">
          <img src="/Images/search.png">
          <h2>Rechercher</h2>
          <p>Retrouvez toutes vo connaissances inscrites sur le réseau professionnel.</p>
          <%--<p><a class="btn" href="#">View details &raquo;</a></p>--%>
        </div><!-- /.span4 -->
        <div class="span4">
          <img src="/Images/network.png">
          <h2>Réseau</h2>
          <p>Ajoutez vos collabateurs, rencontrez en de nouveaux et échangez avec eux.</p>
          <%--<p><a class="btn" href="#">View details &raquo;</a></p>--%>
        </div><!-- /.span4 -->
      </div><!-- /.row -->


    <script>
        !function ($) {
            $(function () {
                // carousel demo
                $('#myCarousel').carousel()
            })
        } (window.jQuery)
    </script>
   
</asp:Content>
