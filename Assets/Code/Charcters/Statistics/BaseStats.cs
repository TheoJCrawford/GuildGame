using System.Collections;
using System;

namespace GG.CharacterSystem
{
    public class BaseStats
    {
        #region variables
        private string _name;           //Stat name
        private int _baseValue;         //Stat you see, this one goes up in level!
        private double _bonus;          //Bonuses if it comes from gear
        private int _fullValue;         //Shown Value
        private float _percentEffect;   //Effect it plays on certain stats
        #endregion
        #region Setters and Getters
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
        public int fullValue
        {
            set { _fullValue = value; }
            get { return _fullValue; }
        }
        public double bonus
        {
            set { _bonus = value; }
            get { return _bonus; }
        }
        public float perEffect
        {
            get { return _percentEffect; }
            set { _percentEffect = value; }
        }
        #endregion
        #region Constructors
        public BaseStats()
        {
            _name = "Strength";
            _baseValue = 10;
            _bonus = 0.0;
            _fullValue = 10;
            _percentEffect = .33f;

        }
        #endregion
        #region Functions
        public void SetFullValue()
        {
            _fullValue = _baseValue + Convert.ToInt16(_bonus);
        }
        #endregion
    }
    public enum StatNames
    {
        Strength,
        Dexterity,
        Vitality,
        Intelligence,
        Mind,
        Charisma
    };
    public enum StatNameAbreviations
    {
        STR,
        DEX,
        VIT,
        INT,
        MND,
        CHR
    };
}