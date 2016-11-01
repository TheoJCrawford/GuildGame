using UnityEngine;
using GG.CharacterSystem;
using GG;
using System;

namespace GG.CreatureSystem
{
    [Serializable]
    public class CSBaseCreature
    {
        #region Variables
        private string _name;
        private CSSpecies _species;
        private string _descript;
        private Sprite _image;
        private Vital _vital;
        [SerializeField]
        private CSCreatureStat[] _coreStats;
        private int _speed; //this will be replaced later
        private FSMSystem _ai;
        private int _attack;
        private int _defense;
        private int _exp;
        private int _gold;
        #endregion
        #region Setters and Getters
        public string name
        {
            get{return _name;}
            set{_name = value;}
        }

        public Sprite image
        {
            get{return _image;}
            set{_image = value;}
        }

        public string descript
        {
            get{return _descript;}
            set{_descript = value;}
        }

        public CSSpecies species
        {
            get{return _species;}
            set{ _species = value;}
        }

        public int exp
        {
            get{return _exp;}
            set{_exp = value;}
        }

        public int money
        {
            get{return _gold;}
            set{ _gold = value;}
        }

        public int speed
        {
            get{return _speed;}
            set{_speed = value;}
        }

        public CSCreatureStat coreStats(int index)
        {
            return _coreStats[index];
        }

        public Vital vitals
        {
            set{_vital = value;}
            get{return _vital;}
        }

        public FSMSystem ai
        {
            get{return _ai;}
            set{_ai = value;}
        }
        #endregion
        #region Constructors

        public CSBaseCreature()
        {
            _name = "Goblin";
            _descript = string.Empty;
            _image = new Sprite();
            _vital = new Vital();
            _species = new CSSpecies();
            _coreStats = new CSCreatureStat[6];
            for(int i = 0; i < _coreStats.Length; i++)
            {
                _coreStats[i] = new CSCreatureStat();
            }
            _ai = new FSMSystem();
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