using UnityEngine;
using System;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
namespace GG.CharacterSystem
{
    /*
    This files is for testing purposes! Currently testing out the idea of classes withing the game and adding a form of evolution to the characters.
    Ducumentation on classes will be filled in... soon(tm).
    if it works out as intended, this WILL replace the original system    
    */
    [Serializable]
    public class Job
    {
        #region variables
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private string _name;
        [SerializeField]
        private int _level;
        [SerializeField]
        private int _exp;
        [SerializeField]
        private int _speedVal;
        [SerializeField]
        private int _lvlUpReq;
        [SerializeField]
        private int _abilityPoints;
        [SerializeField]
        private int[] _statEvolvers;
        [SerializeField]
        private List<string> _unlockClassNames;
        [SerializeField]
        private List<int> _unlockClasskLevels;
        [SerializeField]
        private List<bool> _unlockClassReq;
        #endregion
        #region Setters and getter
        public Sprite icon
        {
            set { icon = value; }
            get { return _icon; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int level
        {
            set { _level = value; }
            get { return _level; }
        }
        public int speedVal
        {
            set { _speedVal = value; }
            get { return _speedVal; }
        }
        public int lvlUpReq
        {
            set { _lvlUpReq = value; }
            get { return _lvlUpReq; }
        }
        public int exp
        {
            set { _exp = value; }
            get { return _exp; }
        }
        public int AP
        {
            set { _abilityPoints = value; }
            get { return _abilityPoints; }
        }
        public int[] statEvolve
        {
            set { _statEvolvers = value; }
            get { return _statEvolvers; }
        }
        public List<string> unlockNames
        {
            get { return _unlockClassNames; }
            set { _unlockClassNames = value; }
        }
        public List<int> unlockLevels
        {
            get { return _unlockClasskLevels; }
            set { _unlockClasskLevels = value; }

        }
        public List<bool> unlockMet
        {
            get { return _unlockClassReq; }
            set { _unlockClassReq = value; }
        }
#endregion
#region Constructor
        public Job()
        {
            _icon = new Sprite();
            _name = string.Empty;
            _level = 0;
            _exp = 0;
            _speedVal = 0;
            _lvlUpReq = 1000;
            _abilityPoints = 0;
            _statEvolvers = new int[6] { 2, 2, 2, 2, 2, 2};
            _unlockClassNames = new List<string>();
            _unlockClasskLevels = new List<int>();
            _unlockClassReq = new List<bool>();
            
        }
#endregion
#region Functions
        public void AddExp(int Exp)
        {
            _exp += Exp;
            _abilityPoints += Exp;
        }
        public void AddAP(int Ap)
        {
            _abilityPoints += Ap;
        }
        public void LevelUp()
        {
            _level++;
            _lvlUpReq *= _level;
        }
        public void ActivateJob()
        {
            if (_level >= 1)
            {
                return;
            }
            else {
                _level++;
            }
        }
#endregion
    }
}