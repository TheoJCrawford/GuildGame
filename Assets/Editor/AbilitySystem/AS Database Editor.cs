using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace GG.AbilitySystem.Editor
{
    public class ASObjectEditor:EditorWindow
    {
        [MenuItem("Horizon Guild/Ability/Abilty System Editor")]
        static void Init()
        {
            ASObjectEditor window = EditorWindow.GetWindow<ASObjectEditor>();
            window.titleContent = new GUIContent("Ability Editor");
        }
    }
}