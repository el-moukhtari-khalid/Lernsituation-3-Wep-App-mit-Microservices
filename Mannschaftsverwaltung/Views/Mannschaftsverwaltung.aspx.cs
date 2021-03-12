using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung.Views
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        #region Eigenschaften
        private Controller _verwalter;

        #endregion

        #region Accessoren/Modifier
        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        #endregion

        #region Konstruktoren
        public Mannschaftsverwaltung()
        {
            Verwalter = Global.Verwalter;
        }
        #endregion

        #region Worker
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
            Verwalter.LoadMannschaft();
            Verwalter.LoadDateFromPerson();
            tabl.Visible = false;
            abbtn1.Visible = false;
            speicherbtn.Visible = false;
            aenderungspeichernbtn.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            up1.Visible = false;
            up2.Visible = false;
            up3.Visible = false;
            up4.Visible = false;
            up5.Visible = false;
            up6.Visible = false;

            Label3.Visible = false;
           
            tblladen();
            
            if (!IsPostBack)
            {
                LoadPerson();

            }
            else
            {

            }
        }
        public void tblladen()
        {
            TableRow row = new TableRow();
            TableCell c1 = new TableCell();
            for (int spaltenindex = 0; spaltenindex < Verwalter.Liste.Count; spaltenindex++)
            {
                row = new TableRow();

                c1 = new TableCell();
                c1.Text = Verwalter.Liste[spaltenindex].ID.ToString();
                row.Cells.Add(c1);

                c1 = new TableCell();

                c1.Text = Verwalter.Liste[spaltenindex].Mannschaftsname;
                row.Cells.Add(c1);

                c1 = new TableCell();

                c1.Text = Verwalter.Liste[spaltenindex].Sportart;
                row.Cells.Add(c1);
                this.Table5.Rows.Add(row);

            }
            DropDownList Mitglieder = new DropDownList();

            for (int index = 0; index < Verwalter.Liste.Count; index++)
            {
               

               

                Mitglieder = new DropDownList();
                Mitglieder.ForeColor = Color.Black;
                Mitglieder.CssClass = "form-control";

                TableCell newCell = new TableCell();
                //Abfrage ausführen

                newCell.Controls.Add(Mitglieder);
                Table5.Rows[index + 1].Cells.Add(newCell);

                Mitglieder.Items.Clear();

                for(int index1=0;index1<Verwalter.Liste[index].ListePerson.Count;index1++)
                {


                  Mitglieder.Items.Add(Verwalter.Liste[index].ListePerson[index1].Id + ", " + Verwalter.Liste[index].ListePerson[index1].Name+ ", " + Verwalter.Liste[index].ListePerson[index1].Einsatzbereich);




                }

                if (Mitglieder.Items.Count == 0)
                {
                    Mitglieder.Items.Add("bisher keine Mitglieder");
                }
                else
                {

                }

            }
            Button bt = new Button();
            if (Verwalter.User == "Admin" || Verwalter.User == "admin")
            {
                for (int i = 0; i < Table5.Rows.Count - 1; i++)
                {
                    c1 = new TableCell();

                    bt = new Button();
                    int zahl = i + 1;

                    bt.ID = zahl.ToString();
                    bt.Click += bearbeitenDB;

                    c1.Controls.Add(bt);
                    row.Cells.Add(c1);
                    bt.Text = "bearbeiten";
                    bt.CssClass = "btn btn-success";
                    this.Table5.Rows[i + 1].Controls.Add(c1);
                }

                for (int i = 0; i < Table5.Rows.Count - 1; i++)
                {
                    c1 = new TableCell();
                    bt = new Button();
                    c1.Controls.Add(bt);
                    bt.Text = "Löschen";
                    bt.Click += loeschenDb;
                    bt.CssClass = "btn btn-danger";

                    int zahl = 0;
                    zahl = Table5.Rows.Count + i + 1;
                    bt.ID = zahl.ToString();



                    this.Table5.Rows[i + 1].Controls.Add(c1);
                }
            }
            else
            {

            }
        }
        protected void loeschenDb(object sender, EventArgs e)
        {

            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            indexbe = indexbe - Table5.Rows.Count;

            int id = Convert.ToInt32(Table5.Rows[indexbe].Cells[0].Text);
            Verwalter.LoeschenM(id);
            Response.Redirect("Mannschaftsverwaltung.aspx");


        }

        

        public void LoadPerson()
        {

            for (int index = 0; index < Verwalter.Person.Count; index++)
            {
                DatenladenSQL.Items.Add(" " + Verwalter.Person[index].Id + ", " + Verwalter.Person[index].Name + ", " + Verwalter.Person[index].Geburtsdatum + ", " + Verwalter.Person[index].Einsatzbereich);
            }
        }
        #endregion

        protected void speicherbtn_Click(object sender, EventArgs e)
        {
            for(int index=0;index<DropDownList2.Items.Count;index++)
            {
                if(DropDownList2.Items[index].Selected)
                {
                    List<Person> person = new List<Person>();
                    for (int index1 = 0; index1 < DatenladenSQL.Items.Count; index1++)
                    {
                        if (DatenladenSQL.Items[index1].Selected)
                        {
                            Person p1 = new Person();
                            p1.Id = Verwalter.Person[index1].Id;
                            p1.Name = Verwalter.Person[index1].Name;
                            p1.Einsatzbereich = Verwalter.Person[index1].Einsatzbereich;
                            person.Add(p1);
                        }
                        else
                        {

                        }
                    }
                    Verwalter.NewMannschaft(Nametxt.Text,DropDownList2.Items[index].Text,person);
                }
            }
            Response.Redirect("Mannschaftsverwaltung.aspx");
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            tabl.Visible = true;
            addbtn.Visible = false;
            abstand1.Visible = false;
            abbtn1.Visible = true;
            speicherbtn.Visible = true;
            startpage.Visible = false;

            
        }

        protected void abbtn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:44362/Views/Mannschaftsverwaltung");
        }
        protected void bearbeitenDB(object sender, EventArgs e)
        {
            tabl.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            speicherbtn.Visible = false;
            aenderungspeichernbtn.Visible = true;
            DatenladenSQL.Visible = false;
            Label2.Visible = true;
            Label3.Visible = true;
            startpage.Visible = false;

            up1.Visible = true;
            up2.Visible = true;
            up3.Visible = true;
            up4.Visible = true;
            up5.Visible = true;
            up6.Visible = true;
            abstand1.Visible = false;
            addbtn.Visible = false;
            abbtn1.Visible = true;
            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            Verwalter.NewTeam.Clear();

            int id = Convert.ToInt32(Table5.Rows[indexbe].Cells[0].Text);
            aenderung.Items.Clear();
            Verwalter.EditID = id.ToString();
            for (int index = 0; index < Verwalter.Liste.Count; index++)
            {

                if (Verwalter.Liste[index].ID == id)
                {
                    Nametxt.Text = Verwalter.Liste[index].Mannschaftsname;
                    for (int index1 = 0; index1 < Verwalter.Liste[index].ListePerson.Count; index1++)
                    {
                        aenderung.Items.Add("  " + Verwalter.Liste[index].ListePerson[index1].Id + ", " + Verwalter.Liste[index].ListePerson[index1].Name + ", " + Verwalter.Liste[index].ListePerson[index1].Einsatzbereich);

                    }
                }
            }

            verfuegbarePersonen.Items.Clear();
            for (int index2 = 0; index2 < Verwalter.Liste.Count; index2++)
            {
                if (Verwalter.Liste[index2].ID == id)
                {
                    for (int index = 0; index < Verwalter.Person.Count; index++)
                    {
                        bool ergebnis = false;
                        for (int index1 = 0; index1 < Verwalter.Liste[index2].ListePerson.Count; index1++)
                        {
                            if (Verwalter.Person[index].Id == Verwalter.Liste[index2].ListePerson[index1].Id)
                            {
                                ergebnis = true;
                            }
                        }
                        if (ergebnis != true)
                        {
                            Verwalter.NewTeamPerson(Verwalter.Person[index].Id, Verwalter.Person[index].Name, Verwalter.Person[index].Einsatzbereich, Verwalter.Person[index].Sportart);
                            verfuegbarePersonen.Items.Add("  " + Verwalter.Person[index].Id + ", " + Verwalter.Person[index].Name + ", " + Verwalter.Person[index].Einsatzbereich);

                        }
                    }
                }


            }

        }

        protected void aenderungspeichernbtn_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < DropDownList2.Items.Count; index++)
            {
                if (DropDownList2.Items[index].Selected)
                {

                    Verwalter.update(Nametxt.Text, DropDownList2.Items[index].Text);
                }
            }
            int PersonID = 0;
            for (int index = 0; index < aenderung.Items.Count; index++)
            {
                if (aenderung.Items[index].Selected)
                {
                    for (int index2 = 0; index2 < Verwalter.Liste.Count; index2++)
                    {
                        if (Verwalter.Liste[index2].ID.ToString() == Verwalter.EditID)
                        {
                          PersonID=  Verwalter.Liste[index2].ListePerson[index].Id; 
                           Verwalter.PersonEntfernen(PersonID);

                        }
                    }
                }
            }


            for(int index=0;index<verfuegbarePersonen.Items.Count;index++)
            {
                List<Person> person = new List<Person>();

                if (verfuegbarePersonen.Items[index].Selected)
                {
                    Person p1 = new Person();
                    p1.Id = Verwalter.NewTeam[index].Id;
                    p1.Name = Verwalter.NewTeam[index].Name;
                    p1.Einsatzbereich = Verwalter.NewTeam[index].Einsatzbereich;
                    person.Add(p1);
                }
                Verwalter.NeueMannschaft(person);

            }


            Response.Redirect("Mannschaftsverwaltung.aspx");

        }
    }
}