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
        _rot = transform.rotation;
        GetDirection();
    }
	// Update is called once per frame
	void Update () {
        #region Movement
        RotateDirection();
        MovementMotor();
        #endregion
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, _speed * Time.deltaTime);
        if (_tr.rotation == _rot)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * _speed);
        }
        

    }
    void GetDirection() {
        if(_tr.rotation.y == 0)
        {
            _facing = "North";
            Debug.LogWarning("I am seen");
        }
        else if(transform.rotation.y == 90 || transform.rotation.y == -270)
        {
            _facing = "Eastern";
            Debug.LogWarning("I am seen");
        }
        else if (transform.rotation.y == 180 || transform.rotation.y == -180)
        {
            _facing = "South";
            Debug.LogWarning("I am seen");
        }
        else if (transform.rotation.y == 270 || transform.rotation.y == -90)
        {
            _facing = "West";
            Debug.LogWarning("I am seen");
        }
    }
    void RotateDirection()
    {
            switch (_facing)
            {
                case "North":
                if (Input.GetKeyDown(KeyCode.Q))
                {

                    _rot = Quaternion.LookRotation(Vector3.left);
                    _facing = "West";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _rot = Quaternion.LookRotation(Vector3.right);
                    _facing = "Eastern";
                }
                break;
            case "Eastern":
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _rot = Quaternion.LookRotation(Vector3.forward);
                    _facing = "North";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _rot = Quaternion.LookRotation(Vector3.back);
                }_facing = "South";
                    break;
            case "South":
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _rot = Quaternion.LookRotation(Vector3.right);
                    _facing = "Eastern";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _rot = Quaternion.LookRotation(Vector3.left);
                    _facing = "West";
                }
                break;
            case "West":
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _rot = Quaternion.LookRotation(Vector3.back);
                    _facing = "South";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _rot = Quaternion.LookRotation(Vector3.forward);
                    _facing = "North";
                }
                break;

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
            case "Eastern":
                if(Input.GetAxis("Horizontal") < 0 && _tr.position == _pos)
                {
                    _pos += Vector3.forward;
                }
                if(Input.GetAxis("Horizontal") > 0 && _tr.position == _pos)
                {

                }
                if (Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
                {

                }
                if (Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
                {

                }
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
