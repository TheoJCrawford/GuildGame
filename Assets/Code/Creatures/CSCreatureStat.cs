using System;

namespace GG.CreatureSystem
{
    public class CSCreatureStat
    {
        #region Variables
        private string _name;
        private int _lowerValue;
        private int _upperValue;
        private int _combatValue;
        private int _alterdVal;
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
        public int alterdVal
        {
            set { _alterdVal = value; }
            get { return _alterdVal; }
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
        #region Setter and Getter
        public CSCreatureStat()
        {
            _name = "Mepo";
            _lowerValue = 5;
            _upperValue = 20;
            _combatValue = 50;
            _alterationValue = 0;
            _alterdVal = 0;
            _finalValue = 50;
        }
        #endregion
        #region Functions
        public void RanomizeStat()
        {
            Random sink = new Random();
            _combatValue = sink.Next(_lowerValue, upperVal);
        }
        public void SetAlteredVal()
        {
            _alterdVal = Convert.ToInt16(_alterationValue * combatVal);
        }
        public void UpdateFinalVal()
        {
            _finalValue = _alterdVal + combatVal;
        }
        #endregion
    }
}