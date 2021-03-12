using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Login.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        public string Get(string name="",string passwort="")
        {
            MySqlConnection Conn = new MySqlConnection();
            string MyConnectionString = "Server=localhost;Port=3306;Database=loginverwaltung; Uid =user;Password=user";
            string sql = "SELECT COUNT( * )FROM `login` WHERE `Username` = '" + name + "'AND `passwort` = '" + passwort+ "'";
            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch (MySqlException)
            {
                //Datenbank nicht verfügbar

                return "3";
               

            }

            MySqlCommand command = new MySqlCommand(sql, Conn);

            string index = command.ExecuteScalar().ToString();

            

            return index.ToString();
        }
       
        // GET: api/Message/5
        public List<Login> Get(int id)
        {
            List<Login> list = new List<Login>();
            string connectionstring = "Server=localhost;Port=3306;Database=loginverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "SELECT * FROM `login`  ";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id1 = reader.GetValue(0).ToString();
                        string name = reader.GetValue(1).ToString();
                        string Passwort = reader.GetValue(2).ToString();
                        string rolle = reader.GetValue(3).ToString();

                        Login value = new Login(Convert.ToInt32(id1), name, Passwort, rolle);
                        list.Add(value);
                    }
                }
                else
                { }
            }
            catch (MySqlException)
            {
                return new List<Login>();
            }
            conn.Close();
            return list;
        }

        // POST: api/Message
        public void Post([FromBody]string value)
        {
            Login P = (Login)JsonConvert.DeserializeObject(value, typeof(Login));

            string connectionstring = "Server=localhost;Port=3306;Database=loginverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {


                string sqlstring = "INSERT INTO `login`(`Username`, `passwort`, `Rolle`) VALUES ('"+P.Username+ "','" + P.Passwort + "','" + P.Rolle + "')";
                conn.Open();

                MySqlCommand command = new MySqlCommand(sqlstring, conn);
                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                }
                else
                {
                }
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
            string ergebnis = "false;";
            Login value1 = (Login)JsonConvert.DeserializeObject(value, typeof(Login));
            string connectionstring = "Server=localhost;Port=3306;Database=loginverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "UPDATE `login` SET Username='" + value1.Username + "',`passwort`='" + value1.Passwort + "',`Rolle`='" + value1.Rolle+"' WHERE id="+id;
                MySqlCommand command = new MySqlCommand(sqlstring, conn);
                conn.Open();
                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                    ergebnis = "false";
                }
                else
                {
                    ergebnis = "ok";
                }
                conn.Close();


            }
            catch (Exception)
            {
            }
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
            string connectionstring = "Server=localhost;Port=3306;Database=loginverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "DELETE FROM `login` WHERE id=" + id ;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                }
                else
                {
                }
                conn.Close();



            }
            catch (Exception)
            {
            }
        }
    }
}
