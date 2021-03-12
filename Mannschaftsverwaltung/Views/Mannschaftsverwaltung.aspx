<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung.Views.Mannschaftsverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link rel="stylesheet" href="https://bootswatch.com/3/united/bootstrap.min.css"/>

    <title>Mannschaftsverwaltung</title>
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
                  <div id="box1" runat="server" class="col-md-7">
                      <h1>
                          <br id="abstand1" runat="server" />
                          <asp:Label ID="Label1" runat="server" Text="Mannschaftsverwaltung"></asp:Label></h1>

                <asp:Button ID="addbtn" class="btn btn-primary btn-lg btn-block"  runat="server" Text="Mannschaft einfügen" Height="45px" Width="232px" OnClick="addbtn_Click" />

                      


                      <asp:Table ID="tabl" runat="server" CssClass="table">
                          <asp:TableRow>
                              <asp:TableCell runat="server" ID="TableCell1">
                                  <asp:Label ID="Label2" runat="server" Text="Eine Sportart für die Mannschaft auswählen"></asp:Label>
                              </asp:TableCell>

                              <asp:TableCell runat="server" ID="sportartcell">
                                  <asp:DropDownList class = "form-control" ID="DropDownList2" runat="server" ForeColor="Black"  Height="32px" Width="104px">
                                        <asp:ListItem>Fußball</asp:ListItem>
                                        <asp:ListItem>Handball</asp:ListItem>
                                        <asp:ListItem>Tennis</asp:ListItem>

                                 </asp:DropDownList>
                              </asp:TableCell>  
                              
                              <asp:TableCell runat="server" ID="TableCell2">Name:</asp:TableCell>

                              <asp:TableCell runat="server" ID="namecell"><asp:TextBox ID="Nametxt" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                             
                        </asp:TableRow>

                        <asp:TableRow>

                              <asp:TableCell runat="server" ID="Einsatzbereichcell1">    
                                        
                                   
                                    <asp:CheckBoxList ID="DatenladenSQL" runat="server" CssClass=""> </asp:CheckBoxList>
                                     
                              </asp:TableCell>
                                                 </asp:TableRow>
                          <asp:TableRow ID="up1" runat="server">
                                   <asp:TableCell><h4>
                                         <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Mitglieder der Mannschaft:"></asp:Label></h4>
                                   </asp:TableCell>

                          </asp:TableRow>

                           <asp:TableRow ID="up2" runat="server">
                               <asp:TableCell>
                                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Wählen Sie bitte das Mitglied aus welches Sie aus der Mannschaft entfernen möchten!"></asp:Label>
                               </asp:TableCell>

                           </asp:TableRow> 

                          <asp:TableRow ID="up3" runat="server">
                                    <asp:TableCell>
                                            <asp:CheckBoxList ID="aenderung" runat="server"  BackColor="White" ForeColor="black" BorderColor="White"></asp:CheckBoxList>
                                     </asp:TableCell>

                          </asp:TableRow>

                          <asp:TableRow  ID="up4" runat="server">
                            <asp:TableCell>
                                    <br />
                                     <h4>
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="verfügbare Personen:"></asp:Label></h4>

                            </asp:TableCell>

                          </asp:TableRow  >

                        <asp:TableRow ID="up5" runat="server">    
                            <asp:TableCell>
                                    <asp:Label ID="Label6" runat="server" ForeColor="Green" Text="Wählen Sie bitte die Person aus welche Sie einfügen möchten!"></asp:Label>

                            </asp:TableCell>
                         </asp:TableRow>

                          <asp:TableRow  ID="up6" runat="server">
                                  <asp:TableCell>  
                                      <asp:CheckBoxList ID="verfuegbarePersonen" runat="server"  BackColor="White" ForeColor="black" BorderColor="White"></asp:CheckBoxList>
                                    <br />

                                  </asp:TableCell>
                              </asp:TableRow>
                     
                             
                        

                        
                      </asp:Table>

                     <br />
                      <br />
                           <asp:Button class="btn btn-danger" ID="abbtn1" runat="server" Text="Abbrechen" Width="183px"   BorderStyle="Solid" OnClick="abbtn1_Click" />
                           <asp:Button class="btn btn-success" ID="speicherbtn" runat="server" Text="Speichern" Width="183px"   BorderStyle="Solid" OnClick="speicherbtn_Click"  />
                           <asp:Button class="btn btn-success" ID="aenderungspeichernbtn" runat="server" Text="Änderungen speichern" Width="183px"   BorderStyle="Solid" OnClick="aenderungspeichernbtn_Click"/>

                     
                  </div>
                    <div id="startpage" runat="server" class="col-md-4">
                      <lottie-player src="https://assets3.lottiefiles.com/packages/lf20_8ywcoffy.json"  background="transparent"  speed="0.5"  style="width: 600px; height: 300px;"  loop  autoplay></lottie-player>
                    </div>    

                    </div>

                <br />
            </div>
            <asp:Table ID="Table5"  class="table table-bordered table-hover" runat="server" BorderStyle="Inset" BackColor="White" ForeColor="Black">
                <asp:TableRow>
                    <asp:TableCell BorderColor="Black" >ID</asp:TableCell>
                    <asp:TableCell BorderColor="Black" >Mannschaft</asp:TableCell>
                    <asp:TableCell BorderColor="Black" >Sportart</asp:TableCell> 
                    <asp:TableCell BorderColor="Black" >mitglieder</asp:TableCell>
                    <asp:TableCell ID="editcell" runat="server" BorderColor="Black" ></asp:TableCell>
                    <asp:TableCell ID="deletecell" runat="server" BorderColor="Black" ></asp:TableCell>
                </asp:TableRow>
             </asp:Table>


        
    </form>
</body>
</html>
