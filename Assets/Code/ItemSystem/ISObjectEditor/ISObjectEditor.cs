using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        [MenuItem("Horizon Guild/Item/Item System Database %#I")]
        public static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.titleContent = new GUIContent("Item System");
            window.minSize = new Vector2(800, 600);
            window.Show();
        }
        void OnEnable()
        {

        }
        void OnGUI()
        {
            TopTabbar();

            GUILayout.BeginHorizontal();
            ListView();
            ItemDetail();
            GUILayout.EndHorizontal();
            BottomStatusBar();
        }
    }
}