using UnityEngine;
using System.Collections;

public class PMGridMovement : MonoBehaviour {
    private float _speed = 3;
    private Vector3 _pos;
    private Transform _tr;
    private Quaternion _rot;
    private float _rotationVal;
    public string _facing;
	// Use this for initialization
	void Start () {
        _pos = transform.position;
        _tr = transform;
        _rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        GetDirection();
    }
	// Update is called once per frame
	void Update () {
        #region Movement
        MovementMotor();
        #endregion
        transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * _speed);
        

    }
    void GetDirection() {
        if(transform.rotation.y == 0)
        {
            _facing = "North";
        }
        else if(transform.rotation.y == 90)
        {
            _facing = "East";
        }
        else if(transform.rotation.y == 180 || transform.rotation.y == -180)
        {
            _facing = "South";
        }
        if(transform.rotation.y == 270 || transform.rotation.y == -270)
        {
            _facing = "West";
        }
    }
    void MovementMotor()
    {
        switch (_facing)
        {
            case "North":
                if(Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
                {
                    _pos += Vector3.forward;
                }
                if(Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
                {
                    _pos += Vector3.back;
                }
                break;
            case "East":

                break;
            case "South":
                if (Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
                {
                    _pos += Vector3.back;
                }
                if (Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
                {
                    _pos += Vector3.forward;
                }
                    break;
            case "West":

                break;

        }
    }
}
