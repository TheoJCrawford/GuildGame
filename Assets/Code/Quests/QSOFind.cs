using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.QuestSystem
{
    class QSOFind : IQSObjective
    {
        private bool _complete;


        public bool completion
        {
            get{ return _complete; }
            set{ _complete = value; }
        }

        public string descript
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public string location
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public void TriggerComponentCompletion()
        {
            throw new NotImplementedException();
        }

        public void TriggerNext()
        {
            throw new NotImplementedException();
        }
    }
}
