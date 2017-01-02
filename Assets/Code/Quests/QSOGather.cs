﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.QuestSystem
{
    class QSOGather : IQSObjective
    {
        #region variables
        private bool _completion;
        private string _descript;
        private string _locale;
        #endregion
        public bool completion
        {
            get{ return _completion; }
            set{ _completion = value; }
        }

        public string descript
        {
            get{return _descript;}
            set{ _descript = value; }
        }

        public string location
        {
            get{return _locale;}
            set{ _locale = value; }
        }

        public void TriggerNext()
        {
            throw new NotImplementedException();
        }
        public QSOGather()
        {
            _descript = " ";
            _completion = false;
        }
    }
}
