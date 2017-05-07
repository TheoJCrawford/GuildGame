using UnityEngine;
using System.Collections;

namespace GG
{
    public class HeadsUpDisplay : MonoBehaviour
    {
        #region Variables
        private bool _isPaused;
        #endregion
        void Awake()
        {
            _isPaused = false;
        }
        void Start()
        {

        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    _isPaused = false;
                    Time.timeScale = 1;
                }
                else
                {
                    _isPaused = true;
                    Time.timeScale = 0;
                }
            }
        }
        void OnGUI()
        {
            if (_isPaused)
            {
                PauseMenu();
            }
        }
        void PauseMenu()
        {
            GUI.BeginGroup(new Rect(500, 200, 150, 200), " ");
            if (GUI.Button(new Rect(0, 0, 150, 200), "Unpaused"))
            {
                _isPaused = true;
                Time.timeScale = 1;
            }

            if(GUI.Button(new Rect(20, 0, 150, 20), "Exit Game"))
            {
                Application.Quit();
            }
            GUI.EndGroup();
            
        }
    }
}