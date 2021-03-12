using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class Mannschaft
    {
        #region Eigenschaften
        private int _ID;
        private string __Mannschaftsname;
        private string _Sportart;
        private List<Person> _ListePerson;
        
        #endregion

        #region Accessoren/Modifier
        public int ID { get => _ID; set => _ID = value; }
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        public string Mannschaftsname { get => __Mannschaftsname; set => __Mannschaftsname = value; }
        public List<Person> ListePerson { get => _ListePerson; set => _ListePerson = value; }
        #endregion

        #region Konstruktoren
        public Mannschaft()
        {
            this.Mannschaftsname = "FC Bonn";
            ID = 0;
            Sportart = "";
            ListePerson = new List<Person>();
            
           


        }

        public Mannschaft(int id, string name, string sportart,List<Person> per)
        {
            this.ID = id;
            this.Sportart = sportart;
            this.Mannschaftsname = name;
            ListePerson = per;
        }


        #endregion

        #region Worker
        public void AddMannschaft()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message";

            string json = JsonConvert.SerializeObject(this);

            Task<HttpResponseMessage> response = client.PostAsJsonAsync(url, json);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteToAPI(int id)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message";

            //senden
            Task<HttpResponseMessage> response = client.DeleteAsync(url + "/" +id );
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
            }
        }

        public void UpdateToAPI(string editID)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message";
            string json = JsonConvert.SerializeObject(this);

            //senden
            Task<HttpResponseMessage> response = client.PutAsJsonAsync(url + "/" + editID, json);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {

            }
        }

        public void Listueberarbeiten(string editID)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44362/api/Message?befehl=Ueberarbeiten&MID="+editID;

            string json = JsonConvert.SerializeObject(this);

            Task<HttpResponseMessage> response = client.PostAsJsonAsync(url, json);

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