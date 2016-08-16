using UnityEngine;
using System.Collections;

namespace GG.ItemSystem
{
    public interface IISObject
    {
        //name
        string ISName { set; get; }
        //icon
        Sprite ISIcon { set; get; }
        //value
        int ISValue { set; get; }
        //weight
        double ISWeight { set; get; }
        //quality  
        ISQuality ISQuality { set; get; }


        //Send these to other item interfaces
        //equip
        //quesItem flag
        //Durability
        //takenDamage
    }
}