using System.Collections;
using System;

namespace GG.BattleSystem
{
    public class BaseStats
    {
        #region variables
        private string _name;           //Stat name
        private int _baseValue;         //Base value
        private double _levelBonus;     //levelBonus
        private double _bonusVal;       //Bonuses from buffs
        private double _gearVal;        //Effect from gear
        private int _fullValue;         //Shown Value
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
        public double bonusVal
        {
            set { _bonusVal = value; }
            get { return _bonusVal; }
        }
        public double setGearVal
        {
            set { _gearVal = value; }
        }
        #endregion
        #region Constructors
        public BaseStats()
        {
            _name = "Strength";
            _baseValue = 10;
            _bonusVal = 0.0;
            _fullValue = 10;

        }
        #endregion
        #region Functions
        public void SetFullValue()
        {
            _fullValue = _baseValue + Convert.ToInt16(_bonusVal) + Convert.ToInt16(_gearVal);
        }
        #endregion
    }
    #region Enums
    public enum StatNames
    {
        Physical_Attack,
        Magic_Attack,
        Physical_Defence,
        Magic_Defence,
        Speed,
        Evasion,
        Insight,
        Charisma
    };
    public enum StatNameAbreviations
    {
        PA,
        MA,
        PD,
        MD,
        SP,
        EV,
        INS,
        CHR
    };
    #endregion
}