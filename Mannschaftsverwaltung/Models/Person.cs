using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class Person
    {
        #region Eigenschaften
        private int _id;
        private string _name;
        private string _geburtsdatum;
        private string _einsatzbereich;
        private string _anzahlSpiele;
        private string _Position;
        private string _Sportart;


        #endregion

        #region Accessoren/Modifier

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Geburtsdatum { get => _geburtsdatum; set => _geburtsdatum = value; }
        public string Einsatzbereich { get => _einsatzbereich; set => _einsatzbereich = value; }
        public string Position { get => _Position; set => _Position = value; }
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        public string AnzahlSpiele { get => _anzahlSpiele; set => _anzahlSpiele = value; }

        #endregion

        #region Konstruktoren
        public Person()
        {
            Id = 0;
            Name = "";
            Geburtsdatum = "";
            Einsatzbereich = "";
            AnzahlSpiele = "";
            Position = "";
            Sportart = "";

        }
        public Person(int id, string name, string geburtsdatum, string einstaz, string posi, string art, string anzahl)
        {
            Id = id;
            Name = name;
            Geburtsdatum = geburtsdatum;
            Einsatzbereich = einstaz;
            AnzahlSpiele = anzahl;
            Position = posi;
            Sportart = art;

        }


        #endregion

        #region Worker
        public void DeltePersonFromAPI(int personID, string editID)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message";

            //senden
           Task<HttpResponseMessage> response = client.DeleteAsync(url + "?id=" +editID+"&PersonID="+personID+ "&befehl=Person");
            try
            {
               response.Wait();
            }
            catch (Exception)
            {
            }
        }
        #endregion

    }
}