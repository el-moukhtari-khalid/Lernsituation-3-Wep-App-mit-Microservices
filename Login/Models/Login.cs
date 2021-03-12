using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Login
{
    public class Login
    {
        #region Eigenschaften
        private int _id;
        private string _Username;
        private string _passwort;
        private string _rolle;

        #endregion

        #region Accessoren/Modifier
        public int Id { get => _id; set => _id = value; }
        public string Username { get => _Username; set => _Username = value; }

        

        public string Passwort { get => _passwort; set => _passwort = value; }
        public string Rolle { get => _rolle; set => _rolle = value; }

        #endregion

        #region Konstruktoren
        public Login()
        {
            Id = 0;
            Username = "";
            Passwort = "";
            Rolle = "";
        }
        public Login(int id, string user, string passw, string Rolle1)
        {
            Id = id;
            Username = user;
            Passwort = passw;
            Rolle = Rolle1;
        }
        #endregion

        #region Worker
        public string ueberpruefenInAPI()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44354/api/Message?name="+Username+"&passwort="+Passwort;
            Task<HttpResponseMessage> response = client.GetAsync(url);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return "";
            }

            HttpResponseMessage result = response.Result;
            Task<string> content = result.Content.ReadAsStringAsync();
            content.Wait();

            string empfang = content.Result;

            string index = "";
            index = JsonConvert.DeserializeObject(empfang).ToString();
            return index;
        }

        public void ADDUSER()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44354/api/Message";

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

            string url = "http://localhost:44354/api/Message";

            //senden
            Task<HttpResponseMessage> response = client.DeleteAsync(url + "/" + id);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
            }
        }

        public void bearbeitenToApi(int editID)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44354/api/Message";
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
        #endregion
    }
}