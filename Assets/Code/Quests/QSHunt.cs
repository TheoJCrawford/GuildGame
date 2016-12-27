using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.CreatureSystem;

namespace GG.QuestSystem
{
    public class QSHunt : IQSQuest
    {
        #region Variables
        //Common Variables
        private string _name;       //name of the quest
        private string _descript;   //Description of the quest
        private int _qTime;         //Time it will take to finish quest. Time given is in game based days. Might change it to game based hours

        private CSBaseCreature _target;
        #endregion
        #region Setters and getters
        public string descript
        {
            get{return _descript; }
            set{ _descript = value; }
        }

        public int moneyReward
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public string name
        {
            get{return _name;}
            set{ _name = value; }
        }

        public int questTime
        {
            get{return _qTime;}
            set{_qTime = value;}
        }
        #endregion
    }
}