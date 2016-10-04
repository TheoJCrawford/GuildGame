using UnityEngine;
using UnityEditor;
using System.Collections;

public class CSSpeciesEditor : EditorWindow {
    [MenuItem("Horizon Guild/Database/Species Editor")]
    public static void Init()
    {
        CSSpeciesEditor window = EditorWindow.GetWindow<CSSpeciesEditor>();
        window.Show();
    }
}
