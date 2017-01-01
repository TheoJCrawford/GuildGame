using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.CreatureSystem;

namespace GG.QuestSystem
{
    public class QSOHunt : IQSObjective
    {
        private bool _complete;
        private string _descript;



        public bool completion
        {
            get{ return _complete; }
            set{ _complete = value; }
        }

        public string descript
        {
            get{ return _descript; }
            set{ _descript = value; }
        }

        public void TriggerNext()
        {
            throw new NotImplementedException();
        }
    }
}