using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Personenverwaltung.Controllers
{
    public class MessageController : ApiController
    {
        private Controller _verwalter;

        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        // GET: api/Message
        public List<Person> Get()
        {
            List<Person> list = new List<Person>();
            string connectionstring = "Server=localhost;Port=3306;Database=personverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "SELECT * FROM `personverwaltung`; ";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetValue(0).ToString();
                        string name = reader.GetValue(1).ToString();
                        string Geburtsdatum = reader.GetValue(2).ToString();
                        string Einsatzbereich = reader.GetValue(3).ToString();
                        string Position = reader.GetValue(4).ToString();
                        string Sportart = reader.GetValue(5).ToString();
                        string AnzahlSpiele = reader.GetValue(6).ToString();
                        Person value = new Person(Convert.ToInt32(id),name,Geburtsdatum,Einsatzbereich,Position,Sportart,AnzahlSpiele);
                        list.Add(value);
                    }
                }
                else
                { }
            }
            catch (MySqlException)
            {
                return new List<Person>();
            }
            conn.Close();
            return list;
        }

        // GET: api/Message/5
        public List<Person> Get(int id)
        {
            List<Person> list = new List<Person>();
            string connectionstring = "Server=localhost;Port=3306;Database=personverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "SELECT * FROM `personverwaltung`; ";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id1 = reader.GetValue(0).ToString();
                        string name = reader.GetValue(1).ToString();
                        string Geburtsdatum = reader.GetValue(2).ToString();
                        string Einsatzbereich = reader.GetValue(3).ToString();
                        string Position = reader.GetValue(3).ToString();
                        string Sportart = reader.GetValue(3).ToString();
                        string AnzahlSpiele = reader.GetValue(3).ToString();
                        Person value = new Person(Convert.ToInt32(id1), name, Geburtsdatum, Einsatzbereich, Position, Sportart, AnzahlSpiele);
                        list.Add(value);
                    }
                }
                else
                { }
            }
            catch (Exception)
            {
                return new List<Person>();
            }
            conn.Close();
            return list;
        }

        // POST: api/Message
        public void Post([FromBody]string value)
        {
            Person P = (Person)JsonConvert.DeserializeObject(value, typeof(Person));

            string connectionstring = "Server=localhost;Port=3306;Database=personverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                 
                
                string sqlstring = "INSERT INTO `personverwaltung`(`Name`, `Geburtsdatum`, `Einsatzbereich`, `Position`, `Sportart`, `AnzahlSpiele`) VALUES ('"+P.Name+"','"+P.Geburtsdatum+"','"+P.Einsatzbereich+"','"+P.Position+"','"+P.Sportart+"','"+P.AnzahlSpiele+"')";
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
            Person value1 = (Person)JsonConvert.DeserializeObject(value, typeof(Person));
            string connectionstring = "Server=localhost;Port=3306;Database=personverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "UPDATE `personverwaltung` SET `Name`='"+value1.Name+"',`Geburtsdatum`='"+value1.Geburtsdatum+"',`Einsatzbereich`='"+value1.Einsatzbereich+"',`Position`='"+value1.Position+"',`Sportart`='"+value1.Sportart+"',`AnzahlSpiele`='"+value1.AnzahlSpiele+"' WHERE id=" + id;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

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
            connectionstring = "Server=localhost;Port=3306;Database=mannschaftsverwaltung; Uid =user;Password=user";
            conn = new MySqlConnection(connectionstring);
            string sql = "UPDATE `mannschaftsverwaltung` SET `person_name`='" + value1.Name + "',`person_Einsatzsbereich`='" + value1.Einsatzbereich + "' WHERE `Person_id`=" + id;
            conn.Open();
            MySqlCommand command1 = new MySqlCommand(sql, conn);

            int anz1 = command1.ExecuteNonQuery();
            if (anz1 <= 0)
            {
                ergebnis = "false";
            }
            else
            {
                ergebnis = "ok";
            }
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
            string connectionstring = "Server=localhost;Port=3306;Database=personverwaltung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "DELETE FROM `personverwaltung` WHERE `ID` = " + id;
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
    }
}
