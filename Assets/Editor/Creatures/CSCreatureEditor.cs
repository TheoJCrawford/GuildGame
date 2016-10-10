using UnityEngine;
using UnityEditor;
using System.Collections;
namespace GG.CreatureSystem.editor
{

    public class CSCreatureEditor : EditorWindow
    {
        private CSCreatureDatabase _db;
        private int _indexer;

        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_NAME = @"CreatureDatabase.asset";

        [MenuItem("Horizon Guild/Creatures/Creature Editor")]
        static void Init()
        {
            CSCreatureEditor window = EditorWindow.GetWindow<CSCreatureEditor>();
            window.titleContent = new GUIContent("Creature Editor");
            window.Show();
            window.minSize = new Vector2(800, 800);
            window.maxSize = new Vector2(800, 800);
        }
        void OnEnable()
        {
            _db = CSCreatureDatabase.GetDatabase<CSCreatureDatabase>(DATABASE_FOLDER_NAME, DATABASE_NAME);
            _indexer = -1;
        }
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(5, 5, 100, 800));
            ListView();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(110, 5, 680, 800));
            GUILayout.EndArea();
        }
        #region Non Unity Functions
        void ListView()
        {
            if(GUILayout.Button("New Creature"))
            {
                _db.Add(new CSBaseCreature());
                _indexer++;
            }
            if(GUILayout.Button("Delete Creature"))
            {
                if (_indexer > -1)
                {
                    _db.Remove(_indexer);
                }
            }
            GUILayout.Box(" ", GUILayout.MinHeight(.1f), GUILayout.MaxHeight(.1f), GUILayout.ExpandWidth(true));
            if ( _db.Count > 0)
            {
                for(int i = 0; i > _db.Count; i++)
                {
                    GUILayout.Button(_db.Get(i).name);
                }
            }
        }
        #endregion
    }
}