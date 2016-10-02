using UnityEngine;
using System.Collections;

public class PMGridMovement : MonoBehaviour {
    private float _speed = 2;
    private Vector3 _pos;
    private Transform _tr;
    private Quaternion _rot;
	// Use this for initialization
	void Start () {
        _pos = transform.position;
        _tr = transform;
        _rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
	}
	// Update is called once per frame
	void Update () {
        #region Movement
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
            _pos += Vector3.forward;
        }
        if(Input.GetAxis("Horizontal") < 0 && _tr.position == _pos)
        {
            _pos += Vector3.back;
        }
        #endregion
        /*
        #region Rotate Camera
        if (Input.GetKey(KeyCode.Q) && _tr.rotation == _rot)
        {
            _rot.y += 90;
        }
        if(Input.GetKey(KeyCode.E) && _tr.rotation == _rot)
        {
            _rot.y -= 90;
        }
        #endregion
        */
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, Time.deltaTime * _speed);
        if (_tr.rotation == _rot)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * _speed);
        }

    }
}
