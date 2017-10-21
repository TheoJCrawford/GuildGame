using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using GG.BattleSystem.CharacterSystem;

namespace GG.BattleSystem
{
    public class PlayerParty:MonoBehaviour
    {
        private List<BaseCharacter> _party;

        public List<BaseCharacter> party
        {
            get { return _party; }
        }
        public BaseCharacter partymember(int index)
        {
            return _party.ElementAt(index);
        }

        public PlayerParty()
        {
            _party = new List<BaseCharacter>();
        }
        #region functions
        public void AddNewMember(BaseCharacter character)
        {
            if (_party.Count < 4)
            {
                _party.Add(character);
            }
            else
            {
                Debug.Log("Can not add more characters");
            }
        }
        public void RemoveMember(BaseCharacter character)
        {
            if (_party.Count < 0)
            {
                foreach (BaseCharacter chari in _party)
                {
                    if (character.name == chari.name && character.lastName == chari.lastName)
                    {
                        _party.Remove(chari);
                    }
                }
            }
        }
        public void UpadteMember(BaseCharacter character)
        {
            
        }
        public void RemoveMember(int index)
        {
            _party.RemoveAt(index);
        }
        #endregion
    }
}