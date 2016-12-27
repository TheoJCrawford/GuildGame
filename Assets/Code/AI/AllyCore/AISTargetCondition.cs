using System;
using UnityEngine;

namespace GG.AllyAI
{
    public class AISTargetCondition
    {
        #region Variables
        private string _target;
        private string _stateVariance;
        private float _precentEffect;
        #endregion
        #region Setters and Getters
        public string target
        {
            set { _target = value; }
            get { return _target; }
        }
        public string stateVariance
        {
            set { _stateVariance = value; }
            get { return _stateVariance; }
        }
        public float precentEffect
        {
            set { _precentEffect = value; }
            get { return _precentEffect; }
        }
        #endregion
        #region Constructor
        public AISTargetCondition()
        {
            _target = "Self";
            _precentEffect = 50f;
        }
        #endregion
    }
    public enum TargetNames {
        Self,
        PartyAlly,
        Ally,
        Enemy
    };
}
