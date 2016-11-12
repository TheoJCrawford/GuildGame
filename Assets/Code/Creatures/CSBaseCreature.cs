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
        [SerializeField]
        private string _name;
        [SerializeField]
        private CSSpecies _species;
        [SerializeField]
        private string _descript;
        [SerializeField]
        private Sprite _image;
        [SerializeField]
        private Vital _vital;
        [SerializeField]
        private CSCreatureStat[] _coreStats;
        [SerializeField]
        private int _speed; //this will be replaced later
        [SerializeField]
        private FSMSystem _ai;
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
            ActivateStats();
            _ai = new FSMSystem();
            _attack = 0;
            _defense = 0;
            _exp = 20;
            _gold = 15;
            
        }
        
        #endregion
        #region Fuction
        public void ActivateStats()
        {
            for (int i = 0; i < _coreStats.Length; i++)
            {
                _coreStats[i] = new CSCreatureStat();
                _coreStats[i].name = Enum.GetName(typeof(GG.CharacterSystem.StatNames), i);
            }
        }
        #endregion
    }
}