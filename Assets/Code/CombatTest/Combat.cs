using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour
{
    public int Damage = 10;
    public int defence = 5;
    public float attackspeed = 12;
    private Transform me;

    // Use this for initialization
    void Start()
    {
        me = transform.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray attackRay = new Ray(transform.position, transform.forward);
        if (Input.GetButton("Attack"))
        {
            if (attackspeed >= 1.5f)
            {
                RaycastHit hit;

                if (Physics.Raycast(attackRay, out hit, 1f))
                {
                        if (hit.collider.tag == "Enemy")
                        {
                            Debug.Log("Enemy Hit!");
                        }
                        if (hit.collider.tag == "Destructible")
                        {
                            Debug.Log("Destructible hit!");
                        }
                }
                attackspeed = 0;
            }
            
        }
        if(attackspeed < 1.5f)
        {
            attackspeed += Time.deltaTime;
        }
    }
}
