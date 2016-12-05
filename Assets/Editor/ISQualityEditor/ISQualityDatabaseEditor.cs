using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow
    {

        private ISQualityDatabase _qualityDatabase;

        private Vector2 _scrollPos; //List view things

        //Temps
        //private ISQuality selectedQuality;
        private Texture2D selectedTexture;
        int selectedIndex = -1;

        //constants
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FILE_NAME = "GGQualityDatabase.asset";
        const int SPRITE_BUTTON_SIZE = 64;


        [MenuItem("Horizon Guild/Item/Quality Editor %#q")]
        public static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent = new GUIContent("Quality Database");
            window.Show();
        }
        void OnEnable()
        {
            _qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
        }
        void OnGUI()
        {
            if(_qualityDatabase == null)
            {
                Debug.LogWarning("Database not found, sucker!");
                return;
            }
            ListView();
            GUILayout.BeginHorizontal("box", GUILayout.ExpandWidth(true));
            BottomBar();
            GUILayout.EndHorizontal();
        }

        void BottomBar()
        {
            GUILayout.Label("Qualities: " + _qualityDatabase.Count);
            if (GUILayout.Button("Add"))
            {
                _qualityDatabase.Add(new ISQuality());
            }
        }
    }
}
