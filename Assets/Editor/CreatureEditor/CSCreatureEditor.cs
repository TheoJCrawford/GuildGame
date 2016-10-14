using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CreatureSystem
{
    public class CSCreatureEditor : EditorWindow
    {
        const string DATABASE_NAME = @"CSCreatureDatabase.asset";
        const string DATABASE_FOLDER = @"Database";

        private CSCreatureDatabase _db;

        [MenuItem("Horzon Guild/Creatures/Creature Editor")]
        private static void Init()
        {

        }
        void OnEnable()
        {
            _db = CSCreatureDatabase.GetDatabase<CSCreatureDatabase>(DATABASE_FOLDER, DATABASE_NAME);
        }
        void OnGUI()
        {

        }
    }
}