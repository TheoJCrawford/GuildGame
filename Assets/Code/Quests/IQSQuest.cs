using System.Collections;
using System.Collections.Generic;
using GG.ItemSystem;

namespace GG.QuestSystem
{
    public interface IQSQuest
    {
        string name { set; get; }               //Name of the Quest
        bool isComplete { set; get; }           //All conditions for completion
        string descript { set; get; }           //Desscription
        string questGiver { set; get; }         //Who gave the quest
        string questReciever { set; get; }        //Hand in
                                                //Item rewards
        int moneyReward { set; get; }           //gold rewards
        float questTime { set; get; }             //Time Length - Maybe for AI parties only
    }
}