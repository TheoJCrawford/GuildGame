using UnityEngine;
using System.Collections;
using UnityEditor;
using GG.BattleSystem.CharacterSystem;

namespace GG.BattleSystem
{
    [CustomEditor(typeof(PlayerParty))]
    public class TestPlayerParty : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            PlayerParty testCase = (PlayerParty)target;
            if(GUILayout.Button("Add Party Member"))
            {
                testCase.AddNewMember(new BaseCharacter());
            }
            if(testCase.party.Count > 0)
            {
                GUILayout.BeginVertical();
                for(int i =0; i < testCase.party.Count; i++)
                {
                    GUILayout.Label(testCase.partymember(i).name);
                }
                GUILayout.EndVertical();
            }
        }
    }
}