using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using GG.CharacterSystem;


public class CharacterCreator : MonoBehaviour {
    #region Variables
    //core variables
    private BaseCharacter _newCharacter;
    private GameObject _player;
    private int _screenIndex;

    private float _windowWidth;
    private float _windowHeight;
    private int _firstMNameLength;
    private int _firstFNameLength;
    private int _lastNameLength;
    //Default constants
    private const float DEFAULT_OFFSET_X = 50f;
    //Region select variables
    private int _contient;
    private int _village;
    //Name
    private int _FirstName;
    private int _lastName;
    private string _genderCheck;
    //Racial and Stat page constants
    private const float REROLL_BUTTON_HIEGHT = 60f;
    #endregion
    void Awake()
    {
        _newCharacter = new BaseCharacter();
        _FirstName = _newCharacter.RandomFirstName();
        _lastName = _newCharacter.RandomLastName();
        _windowHeight = Screen.height;
        _windowWidth = Screen.width / 2;
        _firstMNameLength = Enum.GetNames(typeof(MaleNames)).Length - 1;
        _firstFNameLength = Enum.GetNames(typeof(FemaleNames)).Length - 1;
        _lastNameLength = Enum.GetNames(typeof(LastName)).Length - 1;
        _contient = 0;
        if (_newCharacter.isMale)
        {
            _genderCheck = "Male";
        }
        else
        {
            _genderCheck = "Female";
        }
    }
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(_windowWidth, 0, _windowWidth, _windowHeight));
        GUI.Box(new Rect(0, 0, _windowWidth, _windowHeight), "Title");
        switch (_screenIndex)
        {
            case 1:
                RacePage();
                break;
            case 2:
                NameAgePage();
                break;
            default:
                RegionTownPage();
                break;
        }
        GUI.EndGroup();
    }
    void RegionTownPage()
    {
        if (GUI.Button(new Rect(DEFAULT_OFFSET_X, 150, 200, 200), "Regalim"))
        {
            _contient = 0;
        }
        switch (_contient)
        {
            default:
                break;
        }
        if (GUI.Button(new Rect(_windowWidth - DEFAULT_OFFSET_X, _windowHeight - 100f, 50, 50), "Next"))
        {
            _screenIndex++;
        }
        if (GUI.Button(new Rect(DEFAULT_OFFSET_X, _windowHeight - 100f, 50, 50), "Main Menu"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void RacePage()
    {    
        GUI.Label(new Rect(DEFAULT_OFFSET_X, 80, 80, 20), "Select Race: ");
        GUI.Label(new Rect(130, 80, 80, 20), Enum.GetName(typeof(RaceNames), _newCharacter.race));
        if (GUI.Button(new Rect(60, 100, 60, 60), "Human")) //human button
        {
            _newCharacter.race = 0;
            _newCharacter.RandomStatValues();
            _newCharacter.RacialAdjustments();
            _newCharacter.RandomAge();
            Debug.Log("I am now a " + Enum.GetName(typeof(RaceNames), _newCharacter.race));
        }
        if (GUI.Button(new Rect(120, 100, 60, 60), "Elf")) //elf button
        {
            _newCharacter.race = 1;
            _newCharacter.RandomStatValues();
            _newCharacter.RacialAdjustments();
            _newCharacter.RandomAge();
            Debug.Log("I am now a " + Enum.GetName(typeof(RaceNames), _newCharacter.race));
        }
        if (GUI.Button(new Rect(180, 100, 60, 60), "Dwalf"))
        {
            _newCharacter.race = 2;
            _newCharacter.RandomStatValues();
            _newCharacter.RacialAdjustments();
            _newCharacter.RandomAge();
            Debug.Log("I am now a " + Enum.GetName(typeof(RaceNames), _newCharacter.race));
        }
        if (GUI.Button(new Rect(240, 100, 60, 60), "Demonfolk"))
        {
            _newCharacter.race = 4;
            _newCharacter.RandomStatValues();
            _newCharacter.RacialAdjustments();
            _newCharacter.RandomAge();
            Debug.Log("I am now a " + Enum.GetName(typeof(RaceNames), _newCharacter.race));
        }
        if (GUI.Button(new Rect(300, 100, 60, 60), "Angelfolk"))
        {
            _newCharacter.race = 5;
            _newCharacter.RandomStatValues();
            _newCharacter.RacialAdjustments();
            _newCharacter.RandomAge();
        }
        if (GUI.Button(new Rect(200, 150, 80, 30), _genderCheck))
        {
            if (_newCharacter.isMale)
            {
                _genderCheck = "Female";
                _newCharacter.isMale = false;
            }
            else
            {
                _genderCheck = "Male";
                _newCharacter.isMale = true;
            }
            _newCharacter.RandomFirstName();
        }
        //Stat Rollers
        GUILayout.Label("Stats");
        for (int i = 0; i < Enum.GetNames(typeof(StatNames)).Length; i++)
        {
            GUI.Label(new Rect(DEFAULT_OFFSET_X, 175 + (20 * i), 30, 20), Enum.GetName(typeof(StatNameAbreviations), i));
            GUI.Label(new Rect(DEFAULT_OFFSET_X + DEFAULT_OFFSET_X, 175 + (20 * i), 30, 20), _newCharacter.GetStats(i).fullValue.ToString());
        }
        if (GUI.Button(new Rect(50, 300, REROLL_BUTTON_HIEGHT, REROLL_BUTTON_HIEGHT), "Reroll"))
        {
            _newCharacter.RandomStatValues();
        }
        //movers
        if (GUI.Button(new Rect(_windowWidth - DEFAULT_OFFSET_X, _windowHeight - 100f, 50, 50), "Next"))
        {
            _screenIndex++;
        }
        if (GUI.Button(new Rect(DEFAULT_OFFSET_X, _windowHeight - 100f, 50, 50), "Back"))
        {
            _screenIndex--;
        }
    }
    void NameAgePage()
    {
        GUI.Label(new Rect(DEFAULT_OFFSET_X, 75, 300, 25), "Name: " + _newCharacter.firstName + " " + _newCharacter.lastName);
        //first name code
        if (GUI.Button(new Rect(250, 150, 100, 24), "Next Name"))
        {
            _FirstName++;

            if (_newCharacter.isMale)
            {
                if (_FirstName > _firstMNameLength)
                {
                    _FirstName = 0;
                }
                _newCharacter.firstName = Enum.GetName(typeof(MaleNames), _FirstName);
            }
            else
            {
                if (_FirstName > _firstFNameLength)
                {
                    _FirstName = 0;
                }
                _newCharacter.firstName = Enum.GetName(typeof(FemaleNames), _FirstName);
            }

        }
        if (GUI.Button(new Rect(250, 175, 110, 24), "Pervious Name"))
        {
            _FirstName--;

            if (_newCharacter.isMale)
            {
                if (_FirstName < 0)
                {
                    _FirstName = Enum.GetNames(typeof(MaleNames)).Length;
                }
                _newCharacter.firstName = Enum.GetName(typeof(MaleNames), _FirstName);
            }
            else
            {
                if (_FirstName < 0)
                {
                    _FirstName = Enum.GetNames(typeof(FemaleNames)).Length;
                }
                _newCharacter.firstName = Enum.GetName(typeof(FemaleNames), _FirstName);
            }

        }
        if (GUI.Button(new Rect(50, 100, 100, 50), "Randomize First Name"))
        {
            _FirstName = _newCharacter.RandomFirstName();
        }
        //Last name code
        if (GUI.Button(new Rect(200, 100, 100, 50), "Randomize Last Name"))
        {
            _lastName = _newCharacter.RandomLastName();
        }
        if (GUI.Button(new Rect(360, 150, 110, 24), "Next Last Name"))
        {
            _lastName++;
            if (_lastName > _lastNameLength)
            {
                _lastName = 0;
            }
            _newCharacter.lastName = Enum.GetName(typeof(LastName), _lastName);
        }
        if (GUI.Button(new Rect(360, 175, 110, 24), "Previous Last Name"))
        {
            _lastName--;
            if (_lastName < 0)
            {
                _lastName = _lastNameLength;
            }
            _newCharacter.lastName = Enum.GetName(typeof(LastName), _lastName);
        }
        //age
        GUI.Label(new Rect(DEFAULT_OFFSET_X, 150, 60, 24), "Age: " + _newCharacter.age);
        if (GUI.Button(new Rect(120, 150, 60, 60), "Age"))
        {
            _newCharacter.RandomAge();
        }
        if (GUI.Button(new Rect(DEFAULT_OFFSET_X, _windowHeight - 100f, 50, 50), "Back"))
        {
            _screenIndex--;
        }
        if (GUI.Button(new Rect(_windowWidth - DEFAULT_OFFSET_X, _windowHeight - 100f, 50, 50), "Testing Room"))
        {
            /*
            Analytics.CustomEvent("Chracter Created", new Dictionary<string, object>
            {
                {"Race", _newCharacter.race },
                {"Gender", _newCharacter.isMale }
            });
            */
            SceneManager.LoadScene("Testing for movement");

        }
    }
}