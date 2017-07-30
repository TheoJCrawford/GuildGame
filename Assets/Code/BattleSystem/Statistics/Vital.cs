using UnityEngine;
using System.Collections;
using System;

namespace GG.BattleSystem
{
    public class Vital
    {
        #region Variables
        private string _name;           //Stat name
        private int _baseValue;         //Base value
        private double _levelBonus;     //levelBonus
        private double _bonusVal;       //Bonuses from buffs
        private double _gearVal;        //Effect from gear
        private int _fullValue;         //Shown Value
        private int _curValue;                  //The current value of the stat
        #endregion
        #region Setters and Getters
        public  string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public  int baseValue
        {
            set { _baseValue = value; }
            get { return _baseValue; }
        }
        public  int fullValue
        {
            set { _fullValue = value; }
            get { return _fullValue; }
        }
        public  double bonusVal
        {
            set { _bonusVal = value; }
            get { return _bonusVal; }
        }
        public  double setGearVal
        {
            set { _gearVal = value; }
        }
        public int GetCurVale
        {
            get { return _curValue; }
        }
        #endregion
        #region constructors
        public Vital()
        {
            _name = string.Empty;
            _baseValue = 100;
            _gearVal = 0;
            _bonusVal = 0;
            _fullValue = 100;
            _curValue = _fullValue;
        }
        #endregion
        #region functions
        public void UpdateVital()
        {
            _fullValue = Convert.ToInt16( _baseValue + _gearVal + _bonusVal);
        }
        public void ModifyCurValue(int Change)
        {
            _curValue += Change;
            if(_curValue > _fullValue)
            {
                _curValue = _fullValue;
            }
            if(_curValue < 0)
            {
                _curValue = 0;
            }
        }
        public void PercentModifyCurValue(double Change)
        {
            _curValue = Convert.ToInt32(_curValue / Change);
        }
        #endregion
    }
    #region enums
    public enum VitalNames
    {
        Health,
        Mana
    };
    public enum VitalNameAbreviations
    {
        HP,
        MP
    };
    #endregion
    }