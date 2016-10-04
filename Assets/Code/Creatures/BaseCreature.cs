using UnityEngine;
using System.Collections;
using GG.CharacterSystem;

namespace GG.CreatureSystem
{
    public class BaseCreature
    {
        #region Variables
        private string _name;
        private string _descript;
        private Vital _health;
        private BaseStats[] _stats;
        private int _attack;
        private int _defense;
        private int _exp;
        private int _gold;
        #endregion
        #region Setters and Getters
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string descript
        {
            get { return _descript; }
            set { _descript = value; }
        }
        public Vital health
        {
            get { return _health; }
            set { _health = value; }
        }
        public BaseStats[] stats
        {
            get { return _stats; }
            set { _stats = value; }
        }
        public int attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public int defence
        {
            get { return _defense; }
            set { _defense = value; }
        }
        public int exp
        {
            get { return _exp; }
            set { _exp = value; }
        }
        public int gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        #endregion
        #region Constructors

        public BaseCreature()
        {
            _name = "Goblin";
            _descript = string.Empty;
            _health = new Vital();
            _stats = new BaseStats[6];
            _attack = 0;
            _defense = 0;
            _exp = 20;
            _gold = 15;
        }
        
        #endregion
        #region Fuction
        #endregion
    }
}