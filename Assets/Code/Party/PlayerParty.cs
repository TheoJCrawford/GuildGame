﻿using UnityEngine;
using System.Collections.Generic;
using GG.BattleSystem.CharacterSystem;

namespace GG.BattleSystem
{
    public class PlayerParty
    {
        private List<BaseCharacter> _party;

        public List<BaseCharacter> party
        {
            get { return _party; }
            set { _party = value; }
        }

        public PlayerParty()
        {
            _party = new List<BaseCharacter>();
        }
        #region functions
        public void AddNewMember(BaseCharacter character)
        {
            _party.Add(character);
        }
        public void RemoveMember(BaseCharacter character)
        {
            foreach(BaseCharacter chari in _party)
            {
                if(character.name == chari.name && character.lastName == chari.lastName)
                {
                    _party.Remove(chari);
                }
            }
        }
        public void RemoveMember(int index)
        {
            _party.RemoveAt(index);
        }
        #endregion
    }
}