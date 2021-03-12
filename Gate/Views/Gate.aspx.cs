using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gate.Views
{
    public partial class Gate : System.Web.UI.Page
    {
        private controller _verwalter;
        private static string _name;

        public controller Verwalter { get => _verwalter; set => _verwalter = value; }
        public static string Name { get => _name; set => _name = value; }

        public Gate()
        {
            Verwalter = Global.Verwalter;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Sessionerstellen();
        }

        public void Sessionerstellen()
        {
            if (Verwalter.Liste.Count != 0)
            {
                Session["user"] = Verwalter.Liste[0].Name;
                if ((string)Session["user"] != "")
                {
                    Label1.Text = "Hallo, " + (string)Session["user"];
                    Button1.Visible = false;
                    btnabmelden.Visible = true;
                    loginnbox.Visible = false;

                }
                else
                {
                    
                }

            }
            else
            {
                btnabmelden.Visible = false;
                willkomenbox.Visible = false;
                navbar.Visible = false;
                benutzerverwaltung.Visible = false;
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:44354/Views/Login");
        }

        public void btnabmelden_Click(object sender, EventArgs e)
        {
            Verwalter.Liste.RemoveAt(0);
            Response.Redirect("Gate.aspx");
        }

        protected void benutzerverwaltung_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:44354/Views/Loginverwaltung");

        }
    }
}