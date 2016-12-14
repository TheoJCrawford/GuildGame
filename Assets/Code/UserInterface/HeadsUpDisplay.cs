using UnityEngine;
using System.Collections;

namespace GG
{
    public class HeadsUpDisplay : MonoBehaviour
    {
        #region Variables
        private Character _mainCharacter;
        private float _maxBarWidth;
        private float _hpBarWdith;
        private float _barHieght = 20f;
        #endregion
        void Awake()
        {
            _mainCharacter = GameObject.Find("PlayerCharacter").GetComponent<Character>();
        }
        void Start()
        {
            _maxBarWidth = Screen.width * 0.65f;
            _hpBarWdith = _maxBarWidth;

        }
        void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                gameObject.GetComponent<Character>().player.AddToCurVitals(0, -1);
                AdjHealthBar();
            }
        }
        void OnGUI()
        {
            GUI.Box(new Rect(5, 5, _maxBarWidth, _barHieght), _mainCharacter.player.GetVitals(0).name + " :" + _mainCharacter.player.GetVitals(0).curValue.ToString() + "/" + _mainCharacter.player.GetVitals(0).fullValue.ToString());
            GUI.Box(new Rect(5, 5 + _barHieght, _maxBarWidth, _barHieght), _mainCharacter.player.GetVitals(1).name + " :" + _mainCharacter.player.GetVitals(1).curValue.ToString() + "/" + _mainCharacter.player.GetVitals(1).fullValue.ToString());
            GUI.Box(new Rect(5, 5 + _barHieght * 2, _maxBarWidth, _barHieght), _mainCharacter.player.GetVitals(2).name + " :" + _mainCharacter.player.GetVitals(2).curValue.ToString() + "/" + _mainCharacter.player.GetVitals(2).fullValue.ToString());
        }
        void AdjHealthBar()
        {
            _hpBarWdith = _maxBarWidth * (_mainCharacter.player.GetVitals(0).curValue / _mainCharacter.player.GetVitals(0).fullValue);
        }
    }
}