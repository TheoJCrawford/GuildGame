using UnityEngine;
using System.Collections;

namespace GG
{
    public class PMMotor : MonoBehaviour
    {
        #region
        public static PMMotor Instance;
        public float walkSpeed = 10f;       // default walking speed
        public float crouchSpeed;           // The spend when you crouch
        public float runSpeed;              // Runninng speed
        public float jumpSpeed = 6f;        // THe velocity the player jumps at
        public float gravity = 9.81f;       //The speed that the game pulls the player to the ground
        public float terminalVel = 20f;     //Terminal Velocity
        public float slideThresh = 0.6f;        //
        public float maxCntlSlideMag = 0.4f;    //maxinum slidable threshold
        public Vector3 moveVector { get; set; } //Movement
        public float verticalVel { get; set; } //Vertical velocity

        private Vector3 _slideDirection;       //the direction the user will slide in
        #endregion
        #region Unity specific functions
        void Awake()
        {
            Instance = this;
            if(gameObject.GetComponent<PMControl>() == null)
            {
                gameObject.AddComponent<PMControl>();
            }
        }
        #endregion
        #region Functions
        public void UpdateMotor()
        {
            SnapAllignCharacterWithCamera();
            ProcessMotion();
        }
        void ProcessMotion()
        {
            //Transform moveVector to world space
            moveVector = transform.TransformDirection(moveVector);
            // Normalize MoveVector if Magnitude is >1
            if(moveVector.magnitude > 1)
            {
                moveVector = Vector3.Normalize(moveVector);
            }

            ApplySlide();
            //Multiply moveVector by MoveSpeed
            if (!PMControl.Instance.isCrouched)
            {
                if (PMControl.Instance.isRunning)
                {
                    moveVector *= runSpeed;
                }
                else
                {
                    moveVector *= walkSpeed;
                }
            }
            else
            {
                moveVector *= crouchSpeed;
            }
            //reapply Vertical Velocity
            moveVector = new Vector3(moveVector.x, verticalVel, moveVector.z);
            //Apply Cravity
            ApplyGravity();
            //Move the Character in World Spcae (Character.Move)
            PMControl.CharCon.Move(moveVector * Time.deltaTime);
        }
        void ApplyGravity()
        {
            if(moveVector.y > -terminalVel)
            {
                moveVector = new Vector3(moveVector.x, moveVector.y - gravity * Time.deltaTime, moveVector.z);
            }

            if(PMControl.CharCon.isGrounded && moveVector.y < -1)
            {
                moveVector = new Vector3(moveVector.x, -1, moveVector.z);
            }
        }
        void ApplySlide()
        {
            _slideDirection = Vector3.zero;
            if (PMControl.CharCon.isGrounded)
            {
                return;
            }
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hitInfo))
            {
                if (hitInfo.normal.y < slideThresh)
                {
                    _slideDirection = new Vector3(hitInfo.normal.x, -hitInfo.normal.y, hitInfo.normal.z);
                }
                if (_slideDirection.magnitude < maxCntlSlideMag)
                {
                    moveVector += _slideDirection;
                }
                else
                {
                    moveVector = _slideDirection;
                }
            }
        }
        public void Jump()
        {
            if (PMControl.CharCon.isGrounded)
            {
                verticalVel = jumpSpeed;
            }
        }
        void SnapAllignCharacterWithCamera()
        {
            if (moveVector.x !=0 || moveVector. z != 0)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        #endregion
    }
}