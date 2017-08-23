using UnityEngine;
using System;
using System.Collections;
using GG.BattleSystem.CharacterSystem;
public class Character:MonoBehaviour
{
	public BaseCharacter player = new BaseCharacter();
    public bool _isPlayer = false;
    private string guildName = string.Empty;

    void Awake()
    {

    }

}