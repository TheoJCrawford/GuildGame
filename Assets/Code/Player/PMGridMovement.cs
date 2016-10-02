using UnityEngine;
using System.Collections;

public class PMGridMovement : MonoBehaviour {
    private float _speed = 2;
    private Vector3 _pos;
    private Transform _tr;
	// Use this for initialization
	void Start () {
        _pos = transform.position;
        _tr = transform;
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
        {
            _pos += Vector3.right;
        }
        if(Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
        {
            _pos += Vector3.left;
        }
        if(Input.GetAxis("Horizontal") > 0 && _tr.position == _pos)
        {
            _pos += Vector3.up;
        }
        if(Input.GetAxis("Horizontal") < 0 && _tr.position == _pos)
        {
            _pos += Vector3.back;
        }

        transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * _speed);

    }
}
