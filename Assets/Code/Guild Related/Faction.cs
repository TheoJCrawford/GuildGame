using UnityEngine;
using System.Collections;

public class Faction {
    private string _name;
    private string _descript;
    private double _favour;
    private int _standingLevel;
    private int[] _threshold;
    //private IList<> _quests;

    public string name
    {
        set { _name = value; }
        get { return _name; }
    }
    public string descript
    {
        set { _descript = value; }
        get { return _descript; }
    }
    public double favour
    {
        set { _favour = value; }
        get { return _favour; }
    }
    public int standingLevel
    {
        set { _standingLevel = value; }
        get { return _standingLevel; }
    }

    public Faction()
    {
        _name = "Julian's fire brigade";
        _descript = "This is a random faction";
        _favour = 0;
        _standingLevel = 0;
    }

    public void AddFavour(int exp)
    {
        _favour += exp;
    }
    public void LoseFavour(int exp)
    {
        _favour -= exp;
    }
    public void RankUp()
    {
        _favour = 0;
        _standingLevel++;
    }
    public void RankDown()
    {
        _favour = 0;
        _standingLevel--;
    }
}
