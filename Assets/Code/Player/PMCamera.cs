using UnityEngine;
using System.Collections;

namespace GG
{
    public class PMCamera : MonoBehaviour
    {
        #region variables
        public static PMCamera Instance;
        public Transform _target;                   //This is the camera's targeting position
        public bool isLeftShoulder = false;         //Registers wheter or not the camera is over the left or right shoulder (Naturally right)
        public float distance = 5f;                 //Normal distance from camera
        public float distanceMin = 3f;              //Closest range the camera can be to the player
        public float distanceMax = 10;              //Furtheset range the camera can be to the player
        public float distanceSmooth = 0.05f;        //smoothing rate for lerping of camera's position
        public float x_mouseSense = 5f;             //Sensitivity of the camera on the x position, can be modified in options
        public float y_mouseSense = 5f;             //Sensitivity of the camera on the y position, can be modified in opions
        public float mouseWheelSense = 5f;          //Sensitivity of the mouse wheel, can be modified in options
        public float yMinLim = -10f;                //minimum tilt on the y axis
        public float yMaxLim = 60f;                 //minimum tilt on the x axis
        public float xSmooth = 0.05f;               //Smoothing of movement on the x axis
        public float ySmooth = 0.1f;                //smoothing of the movemnt ont he y axis
        public float velX = 0f;                     //x velocity
        public float velY = 0f;                     //y velocity
        public float velZ = 0f;                     //z velocity

        private float velDistance = 0f;             // Velocity distance
        private float _mouseX = 0f;                 // Mouse position on in screen dimensions
        private float _mouseY = 0f;                 // Mouse position on in screen dimensions
        private float _startDistance = 0f;          // Distance Camera starts at
        private float _desiredDistance = 0f;        // Distance camera wants to be at from the character
        private Vector3 camPos;                     // Camera's position
        private Vector3 desiredPos = Vector3.zero;  // The camera's desired position, initiallized at Vector3.zero
        #endregion
        #region Unity Functions
        void Awake()
        {
            Instance = this;
            /*
            if (_target == null)
            {
                _target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            */
        }
        void Start()
        {
            distance = Mathf.Clamp(distance, distanceMin, distanceMax);
            _startDistance = distance;
            Reset();
        }
        void LateUpdate()
        {
            if (_target == null)
            {
                return;
            }
            HandlePlayerInput();
            CalculateDesiredPosition();
            UpdatePosition();
        }
#endregion
        #region Additional Functions
        void HandlePlayerInput()
        {
            var deadZone = 0.1f;
            //axis Input
            _mouseX += Input.GetAxis("Mouse X") * x_mouseSense;
            _mouseY += Input.GetAxis("Mouse Y") * y_mouseSense;
            //limiting Y poisitioning on mouse
            _mouseY = PMHelper.ClampAngle(_mouseY, yMinLim, yMaxLim);
            //Scrollig in and out
            if(Input.GetAxis("Mouse ScrollWheel") < -deadZone || Input.GetAxis("Mouse ScrollWheel") > deadZone)
            {
                _desiredDistance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * mouseWheelSense, distanceMin, distanceMax);
            }
        }
        public void Reset()
        {
            _mouseX = 0;
            _mouseY = 10;
            distance = _startDistance;
            _desiredDistance = distance;
        }
        void CalculateDesiredPosition()
        {
            //Evaluate Distance
            distance = Mathf.SmoothDamp(distance, _desiredDistance, ref velDistance, distanceSmooth);
            //Calculate desired posiotion
            desiredPos = CalculatePosition(_mouseY, _mouseX, distance);
        }
        Vector3 CalculatePosition(float RotX, float RotY, float Distance)
        {
            Vector3 direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(RotX, RotY, 0);
            return _target.position + rotation * direction;
        }
        void UpdatePosition()
        {
            var posX = Mathf.SmoothDamp(camPos.x, desiredPos.x, ref velX, xSmooth);
            var posY = Mathf.SmoothDamp(camPos.y, desiredPos.y, ref velY, ySmooth);
            var posZ = Mathf.SmoothDamp(camPos.z, desiredPos.z, ref velZ, xSmooth);
            camPos = new Vector3(posX, posY, posZ);

            transform.position = camPos;
            transform.LookAt(_target);

        }
        public static void UseExistsingOrCreateNewMainCamera()
        {
            GameObject tempCamera;
            GameObject targetLookAt;
            PMCamera myCamera;

            if(Camera.main != null)
            {
                tempCamera = Camera.main.gameObject;
            }
            else
            {
                tempCamera = new GameObject("Main Camera");
                tempCamera.AddComponent<Camera>();
                tempCamera.tag = "MainCamera";
            }

            tempCamera.AddComponent<PMCamera>();

            myCamera = tempCamera.GetComponent<PMCamera>();

            targetLookAt = GameObject.Find("targetLookAt") as GameObject;
            if(targetLookAt == null)
            {
                targetLookAt = new GameObject("targetLookAt");
                targetLookAt.transform.position = Vector3.zero;
            }

            myCamera._target = targetLookAt.transform;
        }
        #endregion
    }
}