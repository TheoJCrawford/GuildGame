using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.QuestSystem
{
    interface IQSObjective
    {
        string descript { set; get; }
        bool completion { set; get; }
        void TriggerNext();
    }
}
