using UnityEngine;
using System;
using GG.CharacterSystem;

namespace GG.CreatureSystem
{
    [Serializable]
    public class CSBaseCreature
    {
        #region Variables
        [SerializeField]
        private string _name;
        [SerializeField]
        private CSSpecies _species;
        [SerializeField]
        private string _descript;
        [SerializeField]
        private Sprite _image;
        [SerializeField]
        private Vital _health;
        [SerializeField]
        private BaseStats[] _stats;
        [SerializeField]
        private int _attack;
        [SerializeField]
        private int _defense;
        [SerializeField]
        private int _exp;
        [SerializeField]
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
        public Sprite image
        {
            get { return _image; }
            set { _image = value; }
        }
        public Vital health
        {
            get { return _health; }
            set { _health = value; }
        }
        public CSSpecies species
        {
            get { return _species; }
            set { _species = value; }
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

        public CSBaseCreature()
        {
            _name = "Goblin";
            _descript = string.Empty;
            _image = new Sprite();
            _health = new Vital();
            _species = new CSSpecies();
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