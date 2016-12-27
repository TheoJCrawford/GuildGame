using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.QuestSystem
{
    class QSGather : IQSQuest
    {
        #region
        private string _name;
        private string _descript;
        private int _mReward;
        #endregion
        #region Setters and Geters
        public string descript
        {
            get{return _descript; }
            set{ _descript = value; }
        }
        public int moneyReward
        {
            get{return _mReward;}
            set{_mReward = value; }
        }

        public string name
        {
            get{return _name;}
            set{_name = value;}
        }

        public string questGiver
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }
        public string questReciever
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }
        public int questTime
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }
        #endregion
    }
}
