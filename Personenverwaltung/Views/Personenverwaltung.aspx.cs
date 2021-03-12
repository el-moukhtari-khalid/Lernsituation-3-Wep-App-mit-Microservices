using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personenverwaltung.Views
{
    public partial class Personenverwaltung : System.Web.UI.Page
    {
        private Controller _verwalter;
        private static int _editID;

        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }
        public static int EditID { get => _editID; set => _editID = value; }

        public Personenverwaltung()
        {
            Verwalter = Global.Verwalter;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter.Userabrufen();

            if (Verwalter.User != "")
            {
                if (Verwalter.User == "Admin" || Verwalter.User == "admin")
                {

                }

                else
                {
                    addbtn.Visible = false;
                    editcell.Visible = false;
                    deletecell.Visible = false;

                }
            }
            else
            {
                Response.Redirect("http://localhost:44380/Views/Gate");

            }
            Verwalter.LoadAllDateFromAPI();

            AuswahlRad.Visible = false;
            AuswahlBtn.Visible = false;
            tabl.Visible = false;
            abbtn.Visible = false;
            abbtn1.Visible = false;
            speicherbtn.Visible = false;
            aenderungspeichernbtn.Visible = false;
            fehlerloeschen.Visible = false;
            tbl();


        }

        private void tbl()
        {
            Button bt = new Button();

            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            int wert = 1;

            for (int index=0;index<Verwalter.Liste.Count;index++)
            {
                row = new TableRow();
                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].Id.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].Name;
                row.Cells.Add(cell);


                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].Geburtsdatum;
                row.Cells.Add(cell);


                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].Einsatzbereich;
                row.Cells.Add(cell);


                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].Position;
                row.Cells.Add(cell);


                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].Sportart;
                row.Cells.Add(cell);


                cell = new TableCell();
                cell.Text = Verwalter.Liste[index].AnzahlSpiele.ToString();
                row.Cells.Add(cell);

                if (Verwalter.User == "Admin" || Verwalter.User == "admin")
                {
                    bt = new Button();
                    bt.ID = (wert).ToString();
                    bt.Click += BarbeitenBtn;
                    cell = new TableCell();

                    cell.Controls.Add(bt);
                    row.Cells.Add(cell);
                    bt.Text = "bearbeiten";
                    bt.CssClass = "btn btn-success";
                    wert++;
                }

                else
                {

                }  
                Table1.Rows.Add(row);

                //Bearbeiten Button
                

            }
            if (Verwalter.User == "Admin" || Verwalter.User == "admin")
            {
                for (int i = 0; i < Table1.Rows.Count - 1; i++)
                {
                    cell = new TableCell();
                    bt = new Button();
                    cell.Controls.Add(bt);
                    bt.Text = "Löschen";
                    bt.Click += loeschenbtn;
                    bt.BackColor = Color.Red;
                    bt.CssClass = "btn btn-danger";

                    int zahl = 0;
                    zahl = Table1.Rows.Count + i + 1;
                    bt.ID = zahl.ToString();



                    this.Table1.Rows[i + 1].Controls.Add(cell);
                }
            }

            else
            {
                

            }
            
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            addbtn.Visible = false;
            abstand1.Visible = false;
            startpage.Visible = false;

            abbtn.Visible = true;
            AuswahlRad.Visible = true;
            AuswahlBtn.Visible = true;
        }

        protected void AuswahlBtn_Click(object sender, EventArgs e)
        {
            tabl.Visible = true;
            abbtn1.Visible = true;
            speicherbtn.Visible = true;
            einsatztxt.ReadOnly = true;
            for(int index=0;index<AuswahlRad.Items.Count;index++)
            {
                
                if (AuswahlRad.Items[index].Selected)
                {
                    tabl.Visible = true;
                    abbtn1.Visible = true;
                    speicherbtn.Visible = true;
                    einsatztxt.ReadOnly = true;
                    sporttxt.ReadOnly = true;

                    if (AuswahlRad.Items[index].Text == "Physiotherapeut")
                    {
                        einsatztxt.Text = "Physiotherapeut";
                        Label1.Text = "Physiotherapeut einfügen";
                        Positioncell.Visible = false;
                        Positioncell1.Visible = false;
                        AnzahlSpielecell.Visible = false;
                        AnzahlSpielecell1.Visible = false;
                        SportartCell.Visible = false;
                        SportartCell1.Visible = false;
                       

                    }
                    else if (AuswahlRad.Items[index].Text == "Trainer")
                    {
                        sporttxt.ReadOnly = false;

                        einsatztxt.Text = "Trainer";
                        Label1.Text = "Trainer einfügen";
                        Positioncell.Visible = false;
                        Positioncell1.Visible = false;
                        AnzahlSpielecell.Visible = false;
                        AnzahlSpielecell1.Visible = false;

                    }
                    else if (AuswahlRad.Items[index].Text == "TennisSpieler")
                    {
                        einsatztxt.Text = "Tennisspieler";
                        sporttxt.Text = "Tennis";
                        Label1.Text = "Tennisspieler einfügen";
                        Positioncell.Visible = false;
                        Positioncell1.Visible = false;

                    }
                    else if (AuswahlRad.Items[index].Text == "HandballSpieler")
                    {
                        einsatztxt.Text = "Handballspieler";
                        Label1.Text = "Handballspieler einfügen";
                        sporttxt.Text = "Handball";


                    }
                    else if (AuswahlRad.Items[index].Text == "Fussballspieler")
                    {
                        einsatztxt.Text = "Fussballspieler";
                        Label1.Text = "Fussballspieler einfügen";
                        sporttxt.Text = "Fußball";


                    }
                    else
                    {

                    }
                }

                else
                {

                }
               
            }
        }

        protected void abbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personenverwaltung.aspx");
        }

        protected void speicherbtn_Click(object sender, EventArgs e)
        {
            Verwalter.AddPerson(Nametxt.Text,gebtxt.Text,einsatztxt.Text,sporttxt.Text,Anzahltxt.Text,TextBox2.Text);
            Response.Redirect("Personenverwaltung.aspx");
        }

        protected void loeschenbtn(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            indexbe = indexbe - Table1.Rows.Count;
            int id = Convert.ToInt32(Table1.Rows[indexbe].Cells[0].Text);
            bool wert = Verwalter.Istvorhanden(id);
            if (wert == true)
            {
                Verwalter.DeletePerson(id.ToString());
                Response.Redirect("Personenverwaltung.aspx");
            }
            else
            {
                fehlerloeschen.Visible = true;
            }
            
            

        }

        protected void BarbeitenBtn(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);

            addbtn.Visible = false;
            abstand1.Visible = false;
            startpage.Visible = false;


            tabl.Visible = true;
            abbtn1.Visible = true;
            speicherbtn.Visible = true;

            speicherbtn.Visible = false;
            aenderungspeichernbtn.Visible = true;
            einsatztxt.ReadOnly = true;
            int id = Convert.ToInt32(Table1.Rows[indexbe].Cells[0].Text);
            EditID = id;
            for(int index=0; index<Verwalter.Liste.Count;index++)
            {
                if(Verwalter.Liste[index].Id==id)
                {
                    if(Verwalter.Liste[index].Einsatzbereich== "Physiotherapeut")
                    {
                        Label1.Text = "Physiotherapeut bearbeiten";
                        Positioncell.Visible = false;
                        Positioncell1.Visible = false;
                        AnzahlSpielecell.Visible = false;
                        AnzahlSpielecell1.Visible = false;
                        SportartCell.Visible = false;
                        SportartCell1.Visible = false;

                        einsatztxt.Text = Verwalter.Liste[index].Einsatzbereich;
                        Nametxt.Text = Verwalter.Liste[index].Name;
                        gebtxt.Text = Verwalter.Liste[index].Geburtsdatum;

                    }
                    else if(Verwalter.Liste[index].Einsatzbereich == "Trainer")
                    {
                        einsatztxt.Text = "Trainer";
                        Label1.Text = "Trainer bearbeiten";
                        Positioncell.Visible = false;
                        Positioncell1.Visible = false;
                        AnzahlSpielecell.Visible = false;
                        AnzahlSpielecell1.Visible = false;

                        einsatztxt.Text = Verwalter.Liste[index].Einsatzbereich;
                        Nametxt.Text = Verwalter.Liste[index].Name;
                        gebtxt.Text = Verwalter.Liste[index].Geburtsdatum;
                        sporttxt.Text=Verwalter.Liste[index].Sportart;
                    }  
                    else if(Verwalter.Liste[index].Einsatzbereich == "Tennisspieler")
                    {
         
                        Label1.Text = "Tennisspieler bearbeiten";
                        Positioncell.Visible = false;
                        Positioncell1.Visible = false;

                        einsatztxt.Text = Verwalter.Liste[index].Einsatzbereich;
                        Nametxt.Text = Verwalter.Liste[index].Name;
                        gebtxt.Text = Verwalter.Liste[index].Geburtsdatum;
                        sporttxt.Text = Verwalter.Liste[index].Sportart;
                        Anzahltxt.Text = Verwalter.Liste[index].AnzahlSpiele;
                    }   
                    else if(Verwalter.Liste[index].Einsatzbereich == "Handballspieler")
                    {
                        Label1.Text = "HandballSpieler bearbeiten";
                       

                        einsatztxt.Text = Verwalter.Liste[index].Einsatzbereich;
                        TextBox2.Text = Verwalter.Liste[index].Position;
                        Nametxt.Text = Verwalter.Liste[index].Name;
                        gebtxt.Text = Verwalter.Liste[index].Geburtsdatum;
                        sporttxt.Text = Verwalter.Liste[index].Sportart;
                        Anzahltxt.Text = Verwalter.Liste[index].AnzahlSpiele;
                    }   
                    else if(Verwalter.Liste[index].Einsatzbereich == "Fussballspieler")
                    {
                        Label1.Text = "Fussballspieler bearbeiten";
                       

                        einsatztxt.Text = Verwalter.Liste[index].Einsatzbereich;
                        TextBox2.Text = Verwalter.Liste[index].Position;
                        Nametxt.Text = Verwalter.Liste[index].Name;
                        gebtxt.Text = Verwalter.Liste[index].Geburtsdatum;
                        sporttxt.Text = Verwalter.Liste[index].Sportart;
                        Anzahltxt.Text = Verwalter.Liste[index].AnzahlSpiele;
                    }
                    else
                    {

                    }
                }
            }
        }

        protected void aenderungspeichernbtn_Click(object sender, EventArgs e)
        {
            Verwalter.UpdatePerson(EditID,Nametxt.Text, gebtxt.Text, einsatztxt.Text, sporttxt.Text, Anzahltxt.Text, TextBox2.Text);
            Response.Redirect("Personenverwaltung.aspx");
        }
    }
}