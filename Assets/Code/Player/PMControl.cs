using UnityEngine;
using System.Collections;

namespace GG
{
    [RequireComponent(typeof(PMMotor))]
    public class PMControl : MonoBehaviour
    {
        #region variables
        public static CharacterController CharCon;
        public static PMControl Instance;
        public bool isCrouched = false;
        public  bool isRunning = false;
        public bool weaponDrawn = false;
        #endregion
        #region Unity Functions
        // Use this for initialization
        void Awake()
        {
            CharCon = GetComponent<CharacterController>();
            if(CharCon == null)
            {
                CharCon = gameObject.AddComponent<CharacterController>();
            }

            if(GetComponent<PMMotor>() == null)
            {
                gameObject.AddComponent<PMMotor>();
            }

            Instance = this;
            PMCamera.UseExistsingOrCreateNewMainCamera();
        }
        void Update()
        {
            if(Camera.main == null)
            {
                return;
            }
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!isCrouched)
                {
                    isCrouched = true;
                }
                else
                {
                    isCrouched = false;
                }
            }
            if (!isCrouched)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    isRunning = true;
                }
                if(Input.GetKeyUp(KeyCode.LeftShift))
                {
                    isRunning = false;
                }
            }
            GetLocomotionInput();
           HandleActionInput();
            PMMotor.Instance.UpdateMotor();
        }
        #endregion
        #region Other Functions
        void GetLocomotionInput()
        {
            var deadZone = 0.1f;

            PMMotor.Instance.verticalVel = PMMotor.Instance.moveVector.y;
            PMMotor.Instance.moveVector = Vector3.zero;
            
            if(Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
            {
                PMMotor.Instance.moveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
            }
            if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
            {
                PMMotor.Instance.moveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            }
        }
        void HandleActionInput()
        {
            if (Input.GetAxis("Jump")==1)
            {
                PMMotor.Instance.Jump();
             
            }
        }
        void Jump()
        {
            PMMotor.Instance.Jump();
        }
        #endregion
    }
}