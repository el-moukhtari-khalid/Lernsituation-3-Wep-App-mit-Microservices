using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Personenverwaltung
{
    public class Controller
    {
        #region Eigenschaften
        private List<Person> _liste;
        private  string _user;

        #endregion

        #region Accessoren/Modifier
        public List<Person> Liste { get => _liste; set => _liste = value; }
        public  string User { get => _user; set => _user = value; }

        #endregion

        #region Konstruktoren
        public Controller()
        {
            Liste = new List<Person>();
            User = "";
        }
        #endregion

        #region Worker
        public void LoadAllDateFromAPI()
        {
            Liste.Clear();
            HttpClient client = new HttpClient();

            string url = "http://localhost:44330/api/Message";


            Task<HttpResponseMessage> response = client.GetAsync(url);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return;
            }

            HttpResponseMessage result = response.Result;

            Task<string> content = result.Content.ReadAsStringAsync();

            try
            {
                content.Wait();
            }
            catch (Exception)
            {

            }

            string empfang = content.Result;

            Liste = (List<Person>)JsonConvert.DeserializeObject<List<Person>>(empfang).ToList();
        }

        public void AddPerson(string name, string geb, string einsatzt, string sport, string anzahl, string position)
        {
           
            Person pers = new Person(0,name,geb,einsatzt,position,sport,anzahl);
            pers.PostToAPI();
        }
        //(EditID,Nametxt.Text, gebtxt.Text, einsatztxt.Text, sporttxt.Text, Anzahltxt.Text, TextBox2.Text
        public void UpdatePerson(int eDITID, string Nametxt, string gebtxt, string einsatztxt, string sporttxt, string Anzahltxt, string positxt)
        {
            //int id,string name,string geburtsdatum,string einstaz,string posi,string art,string anzahl
            Person pers = new Person(eDITID, Nametxt, gebtxt, einsatztxt, positxt, sporttxt, Anzahltxt);
           
            pers.EditToAPI(eDITID);

        }

        public void DeletePerson(string text)
        {
            Person per = new Person();
            per.DeleteToAPI(text);
        }


        public void Userabrufen()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44380/api/Message";


            Task<HttpResponseMessage> response = client.GetAsync(url);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return;
            }

            HttpResponseMessage result = response.Result;

            Task<string> content = result.Content.ReadAsStringAsync();

            try
            {
                content.Wait();
            }
            catch (Exception)
            {

            }

            string empfang = content.Result;

            empfang = JsonConvert.DeserializeObject(empfang).ToString();

            User = empfang;
        }

        public bool Istvorhanden(int id)
        {
            bool ergebnis = false;
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message/" + id;


            Task<HttpResponseMessage> response = client.GetAsync(url);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return false;
            }

            HttpResponseMessage result = response.Result;

            Task<string> content = result.Content.ReadAsStringAsync();

            try
            {
                content.Wait();
            }
            catch (Exception)
            {

            }

            string Person = content.Result;

            Person = JsonConvert.DeserializeObject(Person).ToString();
            if (Person != "")
            {
                ergebnis = false;
            }
            else
            {
                ergebnis = true;
            }

            return ergebnis;
        }

       
        #endregion

    }
}