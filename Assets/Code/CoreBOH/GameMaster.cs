using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
     public string state;
    public static GameMaster gm;
    // Use this for initialization
    void Start()
    {
        gm = this;
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
