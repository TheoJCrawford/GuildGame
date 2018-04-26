using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.BattleSystem.CreatureSystem;

namespace GG.QuestSystem
{
    public class QSOHunt : IQSObjective
    {
        #region Variables
        private bool _complete;
        private string _descript;
        private string _locale;

        private List<BSCreature> _targets;
        private List<int> _targetsNum;
        private List<int> _remaining;
        #endregion
        #region S&G
        public bool completion
        {
            get { return _complete; }
            set { _complete = value; }
        }
        public string descript
        {
            get { return _descript; }
            set { _descript = value; }
        }
        public string location
        {
            get { return _locale; }
            set { _locale = value; }
        }
        public List<BSCreature> targets
        {
            get { return _targets; }
            set { _targets = value; }
        }
        public List<int> targetNums
        {
            get { return _targetsNum; }
            set { _targetsNum = value; }
        }
        public List<int> remaining
        {
            get { return _remaining; }
            set { _remaining = value; }
        }
        #endregion
        #region Functions
        public void TriggerComponentCompletion()
        {
            //Check which creature was taken out?
            //Get its index
            //Subtract from remaining
        }
        public void TriggerNext()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}