using UnityEngine;
using System.Linq;
using System.Collections;
using GG.CharacterSystem;

public class Character:MonoBehaviour
{
	public BaseCharacter player = new BaseCharacter();
    public bool _isPlayer = false;
    private string guildName = string.Empty;

    void Awake()
    {
        if(player.job.Count == 0)
        {
            for(int i = 0; i < JobsDatabase.GetDatabase<JobsDatabase>(@"Database", @"JobDatabase.asset").Count; i++)
            {
                player.job.Add(JobsDatabase.GetDatabase<JobsDatabase>(@"Database", @"JobDatabase.asset").Get(i));
            }
            player.job.ElementAt(player.curJob).ActivateJob();
        }
    }

}