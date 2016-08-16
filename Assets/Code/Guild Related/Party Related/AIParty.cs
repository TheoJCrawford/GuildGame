using UnityEngine;
using System.Collections.Generic;

public class AIParty : MonoBehaviour {
    #region variables
    private Character _leader;              //The party leader
    private List<Character> _members;       //Party members
    private string _status;                 //Reading where they are
    private float _timeRemaining;           //Time until they arrive home
    #endregion
    #region Setters and getters
    public Character leader
    {
        set { _leader = value; }
        get { return _leader; }
    }
    public List<Character> members
    {
        get { return _members; }
        set { _members = value; }
    }
    public float timeRemaining
    {
        set { _timeRemaining = value; }
        get { return _timeRemaining; }
    }
    #endregion
    #region Constructors
    public AIParty()
    {
        _leader = new Character();
        _members = new List<Character>();
        _status = "Idle";
        _timeRemaining = 0.0f;
    }
    public AIParty(Character Lead, Character mem1, Character mem2, Character mem3, Character mem4, Character mem5, Character mem6, Character mem7)
    {
        _leader = Lead;
        _members.Add(mem1);
        _members.Add(mem2);
        _members.Add(mem3);
        _members.Add(mem4);
        _members.Add(mem5);
        _members.Add(mem6);
        _members.Add(mem7);
        _status = "Idle";
        _timeRemaining = 0f;
    }
    #endregion
    #region Functions
    public void AddMemberToAIParty(Character member)
    {
        if (_members.Count == 7)
        {
            return;
        }
        else
        {
            _members.Add(member);
        }
    }
    public void RememoveMember(int index)
    {
        if(_members.Count > 1)
        {
            _members.RemoveAt(index);
        }
    }
    #endregion
}
