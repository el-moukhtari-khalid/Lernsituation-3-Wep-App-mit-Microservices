<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginverwaltung.aspx.cs" Inherits="Login.Views.Loginverwaltung" %>

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
                          <br id="abstand" runat="server"/>
                          <asp:Label ID="Label1" runat="server" Text="Loginverwaltung"></asp:Label></h1>
                     <asp:Button ID="Button1" class="btn btn-primary btn-lg btn-block"  runat="server" Text="User einfügen" Height="45px" Width="170px" OnClick="Button1_Click" />


                      <asp:Table ID="tabl" runat="server" CssClass="table">
                          <asp:TableRow>
                              <asp:TableCell>
                                  <asp:Label ID="Label2" runat="server" Text="User"></asp:Label>
                                  <asp:TextBox CssClass="form-control" ID="Usertxt" runat="server"></asp:TextBox>
                              </asp:TableCell>
                              <asp:TableCell>
                                    <asp:Label ID="Label3" runat="server" Text="Kennwort"></asp:Label>
                                  <asp:TextBox CssClass="form-control" ID="Passtxt" runat="server" TextMode="Password"></asp:TextBox>
                              </asp:TableCell>
                              <asp:TableCell>
                                  <asp:Label ID="Label4" runat="server" Text="Rolle"></asp:Label>

                                  <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                      <asp:ListItem>Admin</asp:ListItem>
                                      <asp:ListItem>Benutzer</asp:ListItem>
                                  </asp:DropDownList>
                              </asp:TableCell>
                          </asp:TableRow>
                          <asp:TableRow>

                              <asp:TableCell>
                                        <asp:Button class="btn btn-danger" ID="abbtn1" runat="server" Text="Abbrechen" Width="150px"   BorderStyle="Solid" OnClick="abbtn1_Click"/>
                                       <asp:Button class="btn btn-success" ID="speicherbtn" runat="server" Text="Speichern" Width="150px"   BorderStyle="Solid" OnClick="speicherbtn_Click"  />
                                       <asp:Button class="btn btn-success" ID="aenderungsbtn" runat="server" Text="Änderung Speichern" Width="183px"   BorderStyle="Solid" OnClick="aenderungsbtn_Click"  />
                              </asp:TableCell>
                          </asp:TableRow>

                      </asp:Table>
           

                 

                  </div>
                        
                  <div id="willkomenbox" runat="server" class="col-md-4">
                       <lottie-player src="https://assets4.lottiefiles.com/packages/lf20_q5pk6p1k.json"  background="transparent"  speed="0.5"  style="width: 600px; height: 300px;"  loop  autoplay>

                       </lottie-player>
                    </div>

                <br />
            </div>
               <div  id="fehlerloeschen" runat="server" class="alert alert-dismissible alert-danger">
              <button type="button" class="close" data-dismiss="alert">&times;</button>
              <strong>FEHLER!</strong> <a href="#" class="alert-link">Der Benutzer Name ist bereits vergeben.</a>
            </div>
            <asp:Table ID="Table1" ForeColor="Black" BackColor="White" runat="server" class="table table-bordered table-hover" BorderColor="Black" BorderStyle="Solid">
                <asp:TableHeaderRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">ID</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">User</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2">Rolle</asp:TableCell>


                    <asp:TableCell runat="server" ID="editcell" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2"></asp:TableCell>
                    <asp:TableCell runat="server" ID="deletecell" BorderColor="Black" BorderStyle="Solid"  BorderWidth="2"></asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
