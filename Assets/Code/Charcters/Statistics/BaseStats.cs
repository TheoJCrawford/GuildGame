using System.Collections;
using System;

namespace GG.CharacterSystem {
public class BaseStats{
	#region variables
	private string _name;			//Stat name
	private int _baseValue;			//Stat you see, this one goes up in level!
	private double _bonus;			//Bonuses if it comes from gear
	private int _fullValue;			//Shown Value
	private int _expToLvl;			//hidden value
	private int _LevelTran;			//This is added to the base value of the class when you level (hidden value)
	private float _percentEffect;	//Effect it plays on certain stats
	#endregion
	#region Setters and Getters
	public string name{
		set{_name = value;}
		get{return _name;}
	}
	public int baseValue{
		set{_baseValue = value;}
		get{return _baseValue;}
	}
	public int fullValue{
		set{_fullValue = value;}
		get{return _fullValue;}
	}
	public double bonus{
		set{_bonus = value;}
		get{return _bonus;}
	}
	public int expToLvl{
		set{_expToLvl = value;}
		get{return _expToLvl;}
	}
	#endregion
	#region Constructors
	public BaseStats(){
		_name = "Strength";
		_baseValue = 10;
		_bonus = 0.0;
		_fullValue = 10;
		_expToLvl = 250;
		_LevelTran = 0;
	}
	#endregion
	#region Functions
	public void SetFullValue(){
		_fullValue = _baseValue + _LevelTran;
	}
	public void StatUp(){
		_LevelTran++;
		_baseValue++;
		_expToLvl = (_LevelTran + 1) * 50;
	}
	public void AddExp(int exp){
		_expToLvl -= exp;
            if(_expToLvl <= 0)
            {
                _expToLvl = 0;
                StatUp();
            }
    }
	#endregion
}
public enum StatNames{
	Strength,
	Dexterity,
	Vitality,
	Intelligence,
	Mind,
	Charisma
};
    public enum StatNameAbreviations
    {
        STR,
        DEX,
        VIT,
        INT,
        MND,
        CHR
    };
}