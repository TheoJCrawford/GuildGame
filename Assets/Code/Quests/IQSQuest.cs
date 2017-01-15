using System.Collections;
using System.Collections.Generic;
using GG.ItemSystem;

namespace GG.QuestSystem
{
    public interface ISQuest
    {
        string name { set; get; }                   //Name of the Quest
        
        string descript { set; get; }               //Description
        float questTime { set; get; }               //Time Length - Maybe for AI parties only
    }
}