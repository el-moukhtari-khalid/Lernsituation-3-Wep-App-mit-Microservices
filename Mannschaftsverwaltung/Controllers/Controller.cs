using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class Controller
    {
        #region Eigenschaften
        private List<Mannschaft> _Liste;
        private List<Person> _NewTeam;
        private List<Person> _Person;
        private string _EditID;
        private string _user;


        #endregion

        #region Accessoren/Modifier
        public List<Mannschaft> Liste { get => _Liste; set => _Liste = value; }
        public List<Person> Person { get => _Person; set => _Person = value; }
        public string EditID { get => _EditID; set => _EditID = value; }
        public List<Person> NewTeam { get => _NewTeam; set => _NewTeam = value; }
        public string User { get => _user; set => _user = value; }

        #endregion

        #region Konstruktoren
        public Controller()
        {
            Liste = new List<Mannschaft>();
            Person = new List<Person>();
            NewTeam = new List<Person>();
            EditID = "";
            User = "";
        }


        #endregion

        #region Worker
        public void LoadMannschaft()
        {
            Liste.Clear();
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message";


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

            Liste = (List<Mannschaft>)JsonConvert.DeserializeObject<List<Mannschaft>>(empfang).ToList();
        }
        public void LoadDateFromPerson()
        {

            Person.Clear();
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

            Person = (List<Person>)JsonConvert.DeserializeObject<List<Person>>(empfang).ToList();
        }

        public void NewMannschaft(string text1, string text2, List<Person> person)
        {
            Mannschaft Value = new Mannschaft();
            Value.Mannschaftsname = text1;
            Value.Sportart = text2;

            for (int index = 0; index < person.Count; index++)
            {
                Person p = new Person();
                p.Id = person[index].Id;
                p.Name = person[index].Name;
                p.Einsatzbereich = person[index].Einsatzbereich;
                Value.ListePerson.Add(p);
            }
            Value.AddMannschaft();
        }

        public void LoeschenM(int id)
        {
            Mannschaft Value = new Mannschaft();

            Value.DeleteToAPI(id);
        }

        public void update(string text1, string text2)
        {
            Mannschaft Value = new Mannschaft();
            Value.Mannschaftsname = text1;
            Value.Sportart = text2;

            Value.UpdateToAPI(EditID);
        }

        public void PersonEntfernen(int personID)
        {
            Person P = new Person();
            P.DeltePersonFromAPI(personID, EditID);
        }

        public void NewTeamPerson(int id, string name, string einsatzbereich, string sportart)
        {
            Person p = new Person();
            p.Id = id;
            p.Name = name;
            p.Einsatzbereich = einsatzbereich;
            p.Sportart = sportart;
            NewTeam.Add(p);
        }

        public void NeueMannschaft(List<Person> person)
        {
            Mannschaft Value = new Mannschaft();

            for (int index = 0; index < person.Count; index++)
            {
                Person p = new Person();
                p.Id = person[index].Id;
                p.Name = person[index].Name;
                p.Einsatzbereich = person[index].Einsatzbereich;
                Value.ListePerson.Add(p);
            }
            Value.Listueberarbeiten(EditID);
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
    

        #endregion

    }
}