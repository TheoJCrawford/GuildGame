using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
     public string state;
    // Use this for initialization
    void Start()
    {
        state = "Normal";
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "Combat")
        {

        }
    }
}
