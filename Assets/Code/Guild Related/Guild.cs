using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GG.CharacterSystem;

namespace GG.Guild
{
    public class Guild : MonoBehaviour
    {
        #region Variables
        private string _guildName;              //Name of the Guild (duh)
        private BaseCharacter _leader;          //The leader (you)
        private List<BaseCharacter> _members;  //The members list
        private List<AIParty> _parties;    //This should hold any if not all AI parties (fingers crossed)
        private int _coinBank;                  //The bank account for the group
        private double _interestRate;           //Allows the user to tax the ammount earned from a mission off the members
        private string _homeTown;               //Town where the guild hall is
        private string _homeNation;             //Nation that holds the guild hall
        private string _guildHall;              //Guild Hall type, this will need a revisit in the future
        #endregion
        #region Setters and Getters
        public string homeTown
        {
            set { _homeTown = value; }
            get { return _homeTown; }
        }
        public string homeNation
        {
            set { _homeNation = value; }
            get { return _homeNation; }
        }
        public string guildHall
        {
            set { _guildHall = value; }
            get { return _guildHall; }
        }
        public string guildName
        {
            set { _guildName = value; }
            get { return _guildName; }
        }
        public BaseCharacter leader
        {
            set { _leader = value; }
            get { return _leader; }
        }
        public List<BaseCharacter> members
        {
            set { _members = value; }
            get { return _members; }
        }
        public List<AIParty> npcParty
        {
            set { _parties = value; }
            get { return _parties; }
        }
        public int coinBank
        {
            set { _coinBank = value; }
            get { return _coinBank; }
        }
        public double interestRate
        {
            set { _interestRate = value; }
            get { return _interestRate; }
        }
        #endregion
        #region Constructors
        public Guild()
        {
            _guildName = "horizon";
            _leader = new BaseCharacter();
            _members = new List<BaseCharacter>();
            _interestRate = 0.05;
            _coinBank = 0;
        }
        #endregion
        #region functions
        public void BeginNewGuild()
        {
            _leader = GameObject.FindGameObjectWithTag("player").GetComponent<Character>().player;
        }
        public void AddMember(BaseCharacter newbie)
        {
            members.Add(newbie);
        }
        public void RemoveMember(BaseCharacter leaver)
        {
            members.Remove(leaver);
        }
        public void MakeLeader(BaseCharacter newLeader)
        {
            _leader = newLeader;
            _members.Remove(newLeader);
        }
        public void SwapLeader(int position)
        {
            _members.Add(leader);
            _leader = _members[position];
            _members.RemoveAt(position);
        }
        public int GetCount()
        {
            return _members.Count;
        }
        public void AddMoneyToBank(int coin)
        {
            _coinBank += coin;
        }
        public void SetInterest(double intRate)
        {
            _interestRate = intRate;
        }
        #endregion
    }
    enum StatusNames
    {
        Idle,
        Out_on_Journey,
        On_Mission,
        Crafting,
        Researching,
        On_Break
    };
}