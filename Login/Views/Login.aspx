<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
          <meta name="viewport" content="width=device-width, initial-scale=1"/>
   <link rel="stylesheet" href="https://bootswatch.com/3/united/bootstrap.min.css"/>

    <title>Login</title>
</head>
<body>
    <form id="form1"  runat="server">
          <div class="container">
        <div class="row">
            <div class="col-lg-6 offset-lg-4 bg-light text-dark mt-4 p-3 rounded">
             <h1 class="p-2"> Login</h1>
             <hr class="bg-light"/>
                <asp:Label ID="Label3" runat="server" CssClass="alert alert-danger text-center" Text=""></asp:Label>

             <hr runat="server" id="fehlerline" class="bg-light"/>

                <div class="form-group"> 
                <label for="name">Anmeldename/E-Mail</label>
                  <asp:TextBox ID="TxtUser" runat="server" Height="31px" Width="224px"   CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="form-group"> 
                <label for="name">Kennwort</label>
                  <asp:TextBox ID="txtpass" runat="server" Height="31px" Width="224px" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                   <asp:Button CssClass="btn btn-primary col-sm-10" ID="Button1" runat="server" Text="Login" Height="36px" Width="133px" OnClick="Button1_Click" />
                </div>

                </div>
            

         </div>

    </div>
       
  </form>

</body>

</html>
