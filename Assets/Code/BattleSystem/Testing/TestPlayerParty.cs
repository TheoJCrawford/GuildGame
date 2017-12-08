using UnityEngine;
using System.Collections.Generic;
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
            if (GUILayout.Button("Remove Partymembers"))
            {
                
            }
            GUILayout.BeginVertical();
            if (testCase.party.Count > 0)
            {
                
                for(int i =0; i < testCase.party.Count; i++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(testCase.partymember(i).name);
                    if (GUILayout.Button("X"))
                    {
                        testCase.party.RemoveAt(i);
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
        }
    }
}