using UnityEngine;
using System.Collections;
using GG.CharacterSystem;
using System;

namespace GG.CreatureSystem
{
    public class CSBaseCreature:ICSCreature
    {
        #region Variables
        private string _name;
        private CSSpecies _species;
        private string _descript;
        private Sprite _image;
        private Vital _health;
        private BaseStats[] _stats;
        private int _attack;
        private int _defense;
        private int _exp;
        private int _gold;

        public string name
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public Sprite image
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public string descript
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public CSSpecies species
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public int exp
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public int money
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }

        public int speed
        {
            get{throw new NotImplementedException();}
            set{throw new NotImplementedException();}
        }
        #endregion
        #region Setters and Getters

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