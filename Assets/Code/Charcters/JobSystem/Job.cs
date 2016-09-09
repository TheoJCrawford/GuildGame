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
        private Sprite _icon;
        private string _name;
        private int _level;
        private int _exp;
        private int _lvlUpReq;
        private int _abilityPoints;
        private int[] _statEvolvers;
        private List<string> _unlockClassNames;
        private List<int> _unlockClasskLevels;
        public List<bool> _unlockClassReq;
        #endregion
        #region Setters and getter
        public Sprite icon
        {
#if UNITY_EDITOR
            set { icon = value; }
#endif
            get { return _icon; }
        }
        public string name
        {
#if UNITY_EDITOR
            set { _name = value; }
#endif
            get { return _name; }
        }
        public int level
        {
#if UNITY_EDITOR
            set { _level = value; }
#endif
            get { return _level; }
        }
        public int lvlUpReq
        {
#if UNITY_EDITOR
            set { _lvlUpReq = value; }
#endif
            get { return _lvlUpReq; }
        }
        public int exp
        {
#if UNITY_EDITOR
            set { _exp = value; }
#endif
            get { return _exp; }
        }
        public int AP
        {
#if UNIT_EDITOR
            set { _abilityPoints = value; }
#endif
            get { return _abilityPoints; }
        }
        public int[] statEvolve
        {
#if UNITY_EDITOR
            set { _statEvolvers = value; }
#endif
            get { return _statEvolvers; }
        }
        public List<string> unlockNames
        {
            get { return _unlockClassNames; }
#if UNITY_EDITOR
            set { _unlockClassNames = value; }
#endif
        }
        public List<int> unlockLevels
        {
            get { return _unlockClasskLevels; }
#if UNITY_EDITOR
            set { _unlockClasskLevels = value; }
#endif
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
            _lvlUpReq = 1000;
            _abilityPoints = 0;
            _statEvolvers = new int[6] { 2, 2, 2, 2, 2, 2};
            
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