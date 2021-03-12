using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gate
{
    public class Gate
    {
        #region Eigenschaften
        private string _name;
        private string _rolle;

        #endregion

        #region Accessoren/Modifier
        public string Name { get => _name; set => _name = value; }
        public string Rolle { get => _rolle; set => _rolle = value; }

        #endregion

        #region Konstruktoren
        public Gate()
        {
            Name = "";
            Rolle = "";
        }
        public Gate(string g,string r)
        {
            Name = g;
            Rolle = r;
        }

        #endregion

        #region Worker

        #endregion
    }
}