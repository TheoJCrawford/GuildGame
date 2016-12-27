using UnityEngine;
using System.Collections.Generic;

public class AIParty : MonoBehaviour {
    #region variables
    private string _leader;              //The party leader
    private List<string> _members;       //Party members
    private string _status;                 //Reading where they are
    private float _timeRemaining;           //Time until they arrive home
    #endregion
    #region Setters and getters
    public string leader
    {
        set { _leader = value; }
        get { return _leader; }
    }
    public List<string> members
    {
        get { return _members; }
        set { _members = value; }
    }
    public float timeRemaining
    {
        set { _timeRemaining = value; }
        get { return _timeRemaining; }
    }
    public string status
    {
        get { return _status; }
        set { _status = value; }
    }
    #endregion
    #region Constructors
    public AIParty()
    {
        _leader = new Character().name;
        _members = new List<string>();
        _status = "Idle";
        _timeRemaining = 0.0f;
    }
    public AIParty(Character Lead, Character mem1, Character mem2, Character mem3, Character mem4, Character mem5, Character mem6, Character mem7)
    {
        _leader = Lead.name;
        _members.Add(mem1.name);
        _members.Add(mem2.name);
        _members.Add(mem3.name);
        _members.Add(mem4.name);
        _members.Add(mem5.name);
        _members.Add(mem6.name);
        _members.Add(mem7.name);
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
            _members.Add(member.name);
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
