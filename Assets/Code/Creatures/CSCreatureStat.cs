using UnityEngine;
using System.Collections;

namespace GG.CreatureSystem
{
    public class CSCreatureStat
    {
        #region Variables
        private string _name;
        private int _lowerValue;
        private int _upperValue;
        private int _combatValue;
        private double _alterationValue;
        private int _finalValue;
        #endregion
        #region Setters and Getters
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int lowerVal
        {
            set { _lowerValue = value; }
            get { return _lowerValue; }
        }
        public int upperVal
        {
            set { _upperValue = value; }
            get { return _upperValue; }
        }
        public int combatVal
        {
            set { _combatValue = value; }
            get { return _combatValue; }
        }
        public double alteration
        {
            set { _alterationValue = value; }
            get { return _alterationValue; }
        }
        public int fullVal
        {
            set { _finalValue = value; }
            get { return _finalValue; }
        }
        #endregion 
        #region

        #endregion
        #region

        #endregion
    }
}