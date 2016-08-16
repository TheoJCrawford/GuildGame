using UnityEngine;
using System.Collections;
using System;

namespace GG.CharacterSystem
{
    public class Vital
    {
        #region Variables
        private const int _incrimentalBoost = 10;    //the incriment per level up
        private string _name;                   //Vital name
        private int _baseValue;                 //the base value
        private int _levelBonus;                //bouns from sinking levels into the vital
        private int _level;
        private int _expToLevel;                //experience required to level
        private double _gearModifier;           //value assigned from gear
        private double _percentEffect;          //Percentage of how much is added from a key stat
        private int _statValue;                 //Value from stats
        private int _fullValue;                 //Full value
        private int _curValue;                  //The current value of the stat
        #endregion
        #region set and get
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int baseValue
        {
            set { _baseValue = value; }
            get { return _baseValue; }
        }
        public int level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int expToLevel
        {
            set { _expToLevel = value; }
            get { return _expToLevel; }
        }
        public double gearModifier
        {
            set { _gearModifier = value; }
            get { return _gearModifier; }
        }
        public double percentEffect
        {
            set { _percentEffect = value; }
            get { return _percentEffect; }
        }
        public int fullValue
        {
            set { _fullValue = value; }
            get { return _fullValue; }
        }
        public int curValue
        {
            set { _curValue = value; }
            get { return _curValue; }
        }
        #endregion
        #region constructors
        public Vital()
        {
            _name = string.Empty;
            _baseValue = 100;
            _percentEffect = 1.2;
            _gearModifier = 0;
            _statValue = 0;
            _fullValue = 100;
            _level = 0;
            _expToLevel = 250;
            _levelBonus = 0;
            _curValue = _fullValue;
        }
        #endregion
        #region functions
        public void UpdateStatEffect(int stat)
        {
            _statValue = Convert.ToInt16(stat * _percentEffect);
        }
        private void VitalUp()
        {
            _level++;
            _baseValue+= _incrimentalBoost;
            _expToLevel = (_level + 1) * 250;
        }
        public void AddExp(int exp)
        {
            _expToLevel -= exp;
            if(_expToLevel <= 0)
            {
                _expToLevel = 0;
                VitalUp();
            }
        }
        public void UpdateVital()
        {
            _fullValue = Convert.ToInt16(_statValue + _baseValue + _gearModifier+ _levelBonus);
        }
        #endregion
    }
    #region enums
    public enum VitalNames
    {
        Health,
        Mana,
        Stamina
    };
    #endregion
}