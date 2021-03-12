using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Login
{
    public class controller
    {

        #region Eigenschaften
        private Login _login;
        private List<Login> _Liste;

        #endregion

        #region Accessoren/Modifier
        public Login Login { get => _login; set => _login = value; }
        public List<Login> Liste { get => _Liste; set => _Liste = value; }

        #endregion

        #region Konstruktoren
        public controller()
        {
            Login = new Login();
            Liste = new List<Login>();
        }
        #endregion

        #region Worker
        public string ueberpruefen(string text1, string text2)
        {
            Login user = new Login(-1,text1,text2,"");
            user.ueberpruefenInAPI();
            string index = user.ueberpruefenInAPI();
            
            return index;
        }

        public void LoadfromAPi()
        {
            Liste.Clear();
            HttpClient client = new HttpClient();

            string url = "http://localhost:44354/api/Message/1";


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

            Liste = (List<Login>)JsonConvert.DeserializeObject<List<Login>>(empfang).ToList();
        }

        public void Newsession(string text)
        {
            string Name = "";
            
            HttpClient client = new HttpClient();

            string url = "http://localhost:44380/api/Message?user=" + text;
            Task<HttpResponseMessage> response = client.GetAsync(url);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void adduser(string usertxt, string passtxt, string text)
        {
            Login L = new Login(0,usertxt,passtxt,text);
            L.ADDUSER();

        }

        internal void LoeschenM(int id)
        {
            Login Value = new Login();

            Value.DeleteToAPI(id);
        }

        public void bearbeiten(int editID, string text1, string text2, string text3)
        {
            Login user = new Login(editID,text1,text2,text3);
            user.bearbeitenToApi(editID);
            
        }
        #endregion

    }
}