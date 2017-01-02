using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.QuestSystem
{
    class QSOTalk : IQSObjective
    {
        #region vairables
        //Interface related
        private string _descript;
        private string _location;
        //private NPC _npc;
        private bool _complete;
        #endregion
        #region S&G
        public bool completion
        {
            get{return _complete; }
            set{ _complete = value;}
        }

        public string descript
        {
            get{ return _descript; }
            set{ _descript = value; }
        }

        public string location
        {
            get{ return _location; }
            set{ _location = value; }
        }
        #endregion
        #region
        public QSOTalk()
        {

        }
        #endregion
        public void TriggerNext()
        {
            throw new NotImplementedException();
        }
    }
}
