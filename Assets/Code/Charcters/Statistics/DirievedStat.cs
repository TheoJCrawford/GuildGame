using System;

namespace GG.CharacterSystem {
public class DirievedStat
{
	private string _name;
	private int _statValue;		//Value Derrived from stats
	private float _statWeight;	//Gives Stats a weight on how much the core stats contributes
	private int _modValue;		//Value derived from passives
	private int _gearValue;		//value derrived from equipment
	private int _fullValue;		//Collective total

	#region
	public string name{
		set{_name = value;}
		get{return _name;}
	}
	public int statValue{
		set{_statValue = value;}
		get{return _statValue;}
	}
	public int modValue{
		set{_modValue = value;}
		get{return _modValue;}
	}
	public int gearValue{
		set{_gearValue = value;}
		get{return _gearValue;}
	}
	public int fullValue{
		set{_fullValue = value;}
		get{return _fullValue;}
	}
	#endregion
	#region constructor
	public DirievedStat ()
	{
		_name = string.Empty;
		_statValue = 0;
		_statWeight = 1f;
		_modValue = 0;
		_gearValue = 0;

	}
	#endregion
	#region functions
	public void FullStatValue(int stat){
		_fullValue = Convert.ToInt32(_statValue* _statWeight + _modValue  + _gearValue);
	}
	#endregion
}
public enum DerievedStatNames{
	Attack_Speed, 					//Affects the speed at which weaponskills refresh
	Magic_Power,
	Cast_speed,
	Critical_Chance,
	Critical_Damage,
	Physical_Defence,
	Magical_Defence,



}
}
