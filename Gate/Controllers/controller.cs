using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gate
{
    public class controller
    {
        #region Eigenschaften
        private List<Gate> _liste;

        #endregion

        #region Accessoren/Modifier
        public List<Gate> Liste { get => _liste; set => _liste = value; }

        #endregion

        #region Konstruktoren
        public controller()
        {
            Liste = new List<Gate>();
        }

        #endregion

        #region Worker
        public void SessionErstellen(string user,string rolle)
        {
            Gate g = new Gate();
            g.Name = user;
            Liste.Add(g);
        }
        #endregion
        
    }
}