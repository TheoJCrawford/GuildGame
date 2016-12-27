using System.Collections;
using System.Collections.Generic;
using GG.ItemSystem;

namespace GG.QuestSystem
{
    public interface IQSQuest
    {
        string name { set; get; }               //Name of the Quest
        string descript { set; get; }           //Desscription
                                                 //Item rewards
        int moneyReward { set; get; }           //gold rewards
        int questTime { set; get; }             //Time Length - Maybe for AI parties only
    }
}