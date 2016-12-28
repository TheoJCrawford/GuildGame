using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.QuestSystem
{
    class QSGather : IQSQuest
    {
        #region variables
        //cores
        private string _name;
        private bool _isComplete;
        private string _descript;
        private int _mReward;
        private float _qTime;
        //uniques
        //Items needed
        private List<int> _quanity;
        private List<int> _remaining;
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
        public float questTime
        {
            get{ return _qTime; }
            set{ _qTime = value; }
        }
        public List<int> quantity
        {
            get { return _quanity; }
            set { _quanity = value; }
        }
        public List<int> remaining
        {
            get { return _remaining; }
            set { _remaining = value; }
        }
        public bool isComplete
        {
            get{ return _isComplete; }
            set{ _isComplete = value; }
        }
        #endregion
        #region Constructor
        public QSGather()
        {
            _name = " ";
            _descript = " ";
            _mReward = 0;
            _qTime = 10;
        }

        public void TargetDown()
        {
            
        }
        #endregion

    }
}
