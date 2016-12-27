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
        private int _coinGain;
        //unique Variables
        private string _location;
        private int _numOfEnemy;
        private int _remainingEnemy;
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
            get{return _coinGain; }
            set{ _coinGain = value; }
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
        //uniques
        public int numOfEnemy
        {
            get { return _numOfEnemy; }
            set { _numOfEnemy = value; }
        }
        public int remainingEnemies
        {
            get { return _remainingEnemy; }
            set { _remainingEnemy = value; }
        }
        public CSBaseCreature target
        {
            get { return _target; }
            set { _target = value; }
        }
        #endregion
        #region Constructor
        public QSHunt()
        {

        }
        #endregion
    }
}