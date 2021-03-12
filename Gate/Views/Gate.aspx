<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gate.aspx.cs" Inherits="Gate.Views.Gate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://bootswatch.com/3/united/bootstrap.min.css"/>

</head>
<body>
    <form id="form1" runat="server">

       <nav id="navbar" runat="server" class="navbar navbar-expand-lg navbar-light bg-light">
          <a class="navbar-brand" href="http://localhost:44380/Views/Gate">Turnierverwaltung</a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarText">
            <ul class="navbar-nav mr-auto">
              <li class="nav-item active">
                <a class="nav-link" href="http://localhost:44380/Views/Gate">Home <span class="sr-only">(current)</span></a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="http://localhost:44330/Views/Personenverwaltung">Personenverwaltung</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="http://localhost:44362/Views/Mannschaftsverwaltung">Mannschaftsverwaltung</a>
              </li>
            </ul>
          </div>
        </nav>






              <div class="jumbotron row">
                  <div class="col-md-6">
                      <h1>
                          <br />
                          <asp:Label ID="Label1" runat="server" Text="Turnierverwaltung"></asp:Label></h1>


                 
                <asp:Button ID="Button1" class="btn btn-primary btn-lg btn-block"  runat="server" Text="Login" Height="45px" Width="170px" OnClick="Button1_Click" />
                 <asp:Button ID="benutzerverwaltung" class="btn btn-primary btn-lg btn-block"  runat="server" Text="Loginverwaltung" Height="45px" Width="170px" OnClick="benutzerverwaltung_Click"/>

                <asp:Button ID="btnabmelden" class="btn btn-danger"  runat="server" Text="Abmelden" Height="45px" Width="170px" OnClick="btnabmelden_Click"/>

                  </div>
                    <div id="loginnbox" runat="server" class="col-md-4">
                        <lottie-player src="https://assets6.lottiefiles.com/packages/lf20_Lcwy20.json"  background="transparent"  speed="1"  style="width: 600px; height: 300px;"  loop autoplay>

                        </lottie-player>
                    </div>    
                  <div id="willkomenbox" runat="server" class="col-md-4">
                       <lottie-player src="https://assets5.lottiefiles.com/packages/lf20_ca8zbrdk.json"  background="transparent"  speed="1"  style="width: 600px; height: 300px;"  loop  autoplay>

                       </lottie-player>
                    </div>

                <br />
            </div>

    </form>
 
</body>
</html>
