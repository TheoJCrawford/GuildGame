using UnityEngine;
using System.Collections;

public class PMGridMovement : MonoBehaviour {
    public float _speed = 3;
    public float rotSpeed = 10;
    private Vector3 _pos;
    private Transform _tr;
    private Quaternion _rot;
    private float _rotationVal;
    private string _facing;
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
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * _speed);
    }
    void GetDirection() {
        if(_tr.rotation.y == 0)
        {
            _facing = "North";
            Debug.LogWarning("I am seen");
        }
        else if(transform.rotation.y == 90 || transform.rotation.y == -270)
        {
            _facing = "East";
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (_facing)
            {
                case "North":
                    _rot = Quaternion.LookRotation(Vector3.left);
                    _facing = "West";
                    break;
                case "West":
                    _rot = Quaternion.LookRotation(Vector3.back);
                    _facing = "South";
                    break;
                case "South":
                    _rot = Quaternion.LookRotation(Vector3.right);
                    _facing = "East";
                    break;
                case "East":
                    _rot = Quaternion.LookRotation(Vector3.forward);
                    _facing = "North";
                    break;
                }

            }
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_facing)
            {
                case "North":
                    _rot = Quaternion.LookRotation(Vector3.right);
                    _facing = "East";
                    break;
                case "East":
                    _rot = Quaternion.LookRotation(Vector3.back);
                    _facing = "South";
                    break;
                case "South":
                    _rot = Quaternion.LookRotation(Vector3.left);
                    _facing = "West";
                    break;
                case "West":
                    _rot = Quaternion.LookRotation(Vector3.forward);
                    _facing = "North";
                    break;
            }
        }
    }
    void MovementMotor()
    {
        if (_tr.rotation == _rot)
        {
            switch (_facing)
            {
                case "North":
                    if (Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
                    {
                        _pos += Vector3.forward;
                    }
                    if (Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
                    {
                        _pos += Vector3.back;
                    }
                    break;
                case "East":
                    if (Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
                    {
                        _pos += Vector3.right;
                    }
                    if (Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
                    {
                        _pos += Vector3.left;
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
                    if (Input.GetAxis("Vertical") > 0 && _tr.position == _pos)
                    {
                        _pos += Vector3.left;
                    }
                    if (Input.GetAxis("Vertical") < 0 && _tr.position == _pos)
                    {
                        _pos += Vector3.right;
                    }
                    break;

            }
        }
    }
    
}
