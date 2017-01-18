using UnityEngine;
using System.Collections;
using GG.CharacterSystem;


public class GuildMember{
    private BaseCharacter _character;
    private string _status;


    public GuildMember()
    {
        _character = new BaseCharacter();
        _status = "Idling";
    }
    public GuildMember(BaseCharacter chary)
    {
        _character = chary;
        _status = "Idling";
    }
    public enum StatusName
    {
        Idling,
        Crafting,
        Gathering,
        On_Mission
    };

}
