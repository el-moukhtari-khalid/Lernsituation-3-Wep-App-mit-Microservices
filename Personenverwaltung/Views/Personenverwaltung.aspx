<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Personenverwaltung.Views.Personenverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link rel="stylesheet" href="https://bootswatch.com/3/united/bootstrap.min.css"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

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
                          <br id="abstand1" runat="server" />
                          <asp:Label ID="Label1" runat="server" Text="Personenverwaltung"></asp:Label></h1>

                <asp:Button ID="addbtn" class="btn btn-primary btn-lg btn-block"  runat="server" Text="Person einfügen" Height="45px" Width="170px" OnClick="addbtn_Click" />

                        <asp:RadioButtonList ForeColor="Black"  CssClass="btn-block" ID="AuswahlRad" runat="server"  Width="184px" >
                            <asp:ListItem>Physiotherapeut</asp:ListItem>
                            <asp:ListItem>Trainer</asp:ListItem>
                            <asp:ListItem>TennisSpieler</asp:ListItem>
                            <asp:ListItem>HandballSpieler</asp:ListItem>
                            <asp:ListItem>Fussballspieler</asp:ListItem>
                        </asp:RadioButtonList>

                       <asp:Button class="btn btn-danger" ID="abbtn" runat="server" Text="Abbrechen" Width="183px"   BorderStyle="Solid" OnClick="abbtn_Click" />

                       <asp:Button class="btn btn-primary" ID="AuswahlBtn" runat="server" Text="Auswälen" Width="183px"   BorderStyle="Solid" OnClick="AuswahlBtn_Click"/>


                      <asp:Table ID="tabl" runat="server" CssClass="table">
                          <asp:TableRow>
                              <asp:TableCell runat="server" ID="TableCell1">Name:</asp:TableCell>

                              <asp:TableCell runat="server" ID="namecell"><asp:TextBox ID="Nametxt" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                              <asp:TableCell runat="server" ID="Geburtsdatumcell1">Geburtsdatum:</asp:TableCell>
                              <asp:TableCell runat="server" ID="Geburtsdatumcell"><asp:TextBox ID="gebtxt" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>

                              <asp:TableCell runat="server" ID="Einsatzbereichcell1">Einsatzbereich:</asp:TableCell>
                              <asp:TableCell runat="server" ID="Einsatzbereichcell"><asp:TextBox ID="einsatztxt" BackColor="white" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                            <asp:TableCell runat="server" ID="SportartCell1">Sportart: </asp:TableCell>
                              <asp:TableCell runat="server" ID="SportartCell"><asp:TextBox ID="sporttxt"  BackColor="white" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                             
                        </asp:TableRow>

                          <asp:TableRow> 
                              <asp:TableCell runat="server" ID="AnzahlSpielecell1">Anzahl Spiele:</asp:TableCell>
                              <asp:TableCell runat="server" ID="AnzahlSpielecell"><asp:TextBox ID="Anzahltxt" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox></asp:TableCell>

                              <asp:TableCell runat="server" ID="Positioncell1">Position:</asp:TableCell>
                              <asp:TableCell runat="server" ID="Positioncell"> <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                       
                             
                          </asp:TableRow>
                      </asp:Table>

                           <asp:Button class="btn btn-danger" ID="abbtn1" runat="server" Text="Abbrechen" Width="183px"   BorderStyle="Solid" OnClick="abbtn_Click" />
                           <asp:Button class="btn btn-success" ID="speicherbtn" runat="server" Text="Speichern" Width="183px"   BorderStyle="Solid" OnClick="speicherbtn_Click"  />
                           <asp:Button class="btn btn-success" ID="aenderungspeichernbtn" runat="server" Text="Änderungen speichern" Width="183px"   BorderStyle="Solid" OnClick="aenderungspeichernbtn_Click" />

                     
                  </div>
                    <div id="startpage" runat="server" class="col-md-4">
                      <lottie-player src="https://assets3.lottiefiles.com/packages/lf20_dv3etasb.json"  background="transparent"  speed="0.5"  style="width: 600px; height: 300px;"  loop  autoplay>

                      </lottie-player>
                    </div>    

                    </div>

                <br />
            </div>

               

              <div  id="fehlerloeschen" runat="server" class="alert alert-dismissible alert-danger">
              <button type="button" class="close" data-dismiss="alert">&times;</button>
              <strong>FEHLER!</strong> <a href="#" class="alert-link">Bitte entfernen Sie diese Person aus der Mannschaft.</a>
            </div>

             <asp:Table ID="Table1" ForeColor="Black" BackColor="White" runat="server" class="table table-bordered table-hover" BorderColor="Black" BorderStyle="Solid">
                <asp:TableHeaderRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">ID</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Geburtsdatum</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Einsatzbereich</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Position</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Sportart</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Anzahl Spiele</asp:TableCell>

                    <asp:TableCell runat="server" ID="editcell" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2"></asp:TableCell>
                    <asp:TableCell runat="server" ID="deletecell" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2"></asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

    </form>
</body>
</html>
