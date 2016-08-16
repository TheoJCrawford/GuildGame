using UnityEngine;
using System.Collections;

public class HeadsUpDisplay : MonoBehaviour {
    #region Variables
    private float _maxBarWidth;
    private float _hpBarWdith;
    private float _barHieght = 20f;
    #endregion
    void Start () {
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
	void OnGUI () {
        GUI.Box(new Rect(5, 5, _maxBarWidth, _barHieght), gameObject.GetComponent<Character>().player.GetVitals(0).name + " :" + gameObject.GetComponent<Character>().player.GetVitals(0).curValue.ToString() + "/" + gameObject.GetComponent<Character>().player.GetVitals(0).fullValue.ToString());
        GUI.Box(new Rect(5, 5 + _barHieght, _maxBarWidth, _barHieght), gameObject.GetComponent<Character>().player.GetVitals(1).name + " :" + gameObject.GetComponent<Character>().player.GetVitals(1).curValue.ToString() + "/" + gameObject.GetComponent<Character>().player.GetVitals(1).fullValue.ToString());
        GUI.Box(new Rect(5, 5 + _barHieght * 2, _maxBarWidth, _barHieght), gameObject.GetComponent<Character>().player.GetVitals(2).name + " :" + gameObject.GetComponent<Character>().player.GetVitals(2).curValue.ToString() + "/" + gameObject.GetComponent<Character>().player.GetVitals(2).fullValue.ToString());
    }
    void AdjHealthBar()
    {
        _hpBarWdith = _maxBarWidth * (gameObject.GetComponent<Character>().player.GetVitals(0).curValue / gameObject.GetComponent<Character>().player.GetVitals(0).fullValue);
    }
}
