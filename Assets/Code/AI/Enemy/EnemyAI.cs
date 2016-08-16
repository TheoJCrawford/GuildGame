using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray sight = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(sight, out hit, 1f))
        {
            if(hit.collider.tag== "Player")
            {
                hit.transform.gameObject.GetComponent<Character>().player.AddToCurVitals(0, -5);
            }
        }
	}
}
