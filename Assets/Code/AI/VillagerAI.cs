using UnityEngine;
using System.Collections;

namespace GG.AI
{
    /*
        Villager AI should do the following:
        -React to being bumped into by the character
        -React to talk interaction by characters
        -Move around the designated map
        -Occasionally pause
        -move AROUND other villagers so as to not have them bump into one another
        -This AI will probably be transfered into a crowd sim if I can figure it out
        */
    public class VillagerAI : MonoBehaviour
    {
        private FSMSystem _me;

        // Use this for initialization
        void Start()
        {
            MakeFSM();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void MakeFSM()
        {
            _me = new FSMSystem();

        }
    }
}