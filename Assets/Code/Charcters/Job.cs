using UnityEngine;
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
            set { _level = value; }
            get { return _level; }
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
#if UNITY_EDITOR
            set { _statEvolvers = value; }
#endif
            get { return _statEvolvers; }
        }
        #endregion
        #region Constructor
        public Job()
        {
            _icon = new Sprite();
            _name = string.Empty;
            _level = 1;
            _exp = 0;
            _abilityPoints = 0;
            _statEvolvers = new int[6] { 2, 2, 2, 2, 2, 2};
        }
        #endregion
        #region Functions
        public void AddExp(int Exp)
        {
            _exp += Exp;
            _abilityPoints += Mathf.RoundToInt(Exp / 5);
        }
        #endregion
    }
}