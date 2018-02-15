using UnityEngine;
using UnityEditor;
using GG.BattleSystem.CreatureSystem;

namespace GG.BattleSystem
{
    [CustomEditor(typeof(EnemyParty))]
    public class TestEnemyParty : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EnemyParty testCase = (EnemyParty)target;
            if(GUILayout.Button("Add Creature"))
            {
                testCase.party.Add(new CSBaseCreature());
            }
            if (GUILayout.Button("Clear Party"))
            {
                testCase.party.Clear();
            }
            if (testCase.party.Count > 0)
            {
                for(int i = 0; i <testCase.party.Count; i++)
                {
                    GUILayout.Label(testCase.GetCreature(i).name);
                    GUILayout.Button("X");
                }
            }
        }
    }
}