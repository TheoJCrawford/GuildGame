﻿using System;
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
        private bool _isComplete;
        private float _qTime;       //Time it will take to finish quest. Time given is in game based days. Might change it to game based hours
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
        public float questTime
        {
            get{return _qTime;}
            set{_qTime = value;}
        }
        public string questGiver
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public string questReciever
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public bool isComplete
        {
            get{ return _isComplete; }
            set{ _isComplete = value; }
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
            _name = "Discus";
            _isComplete = false;
            _numOfEnemy = 1;
            _remainingEnemy = 1;
        }
        #endregion
        #region Fucntions
        public void TargetDown()
        {
            if (!_isComplete)
            {
                _remainingEnemy--;
            }
            if (_remainingEnemy == 0)
            {
                _isComplete = true;
            }
        }
        #endregion
    }
}