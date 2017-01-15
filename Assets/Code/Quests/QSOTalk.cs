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
        private string _npcTarget;
        private bool _complete;
        #endregion
        #region S&G
        public bool completion
        {
            get{return _complete; }
            set{ _complete = value;}
        }
        public string npcTarget
        {
            get { return _npcTarget; }
            set { _npcTarget = value; }
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
        #region Functions
        public void TriggerNext()
        {
            throw new NotImplementedException();
        }

        public void TriggerComponentCompletion()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
