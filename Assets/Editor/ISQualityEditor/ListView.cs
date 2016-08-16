using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor
    {
        private void ListView()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

            DisplayQualites();

            EditorGUILayout.EndScrollView();
        }
        
        void DisplayQualites()
        {
            for(int i = 0; i <_qualityDatabase.Count; i++)
            {
                GUILayout.BeginHorizontal("Box");
                //Sprite
                if (_qualityDatabase.Get(i).Icon)
                {
                    selectedTexture = _qualityDatabase.Get(i).Icon.texture;
                }
                else
                {
                    selectedTexture = null;
                }

                if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
                {
                    int ControlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, ControlerID);
                    selectedIndex = i;
                }
                string commandName = Event.current.commandName;
                if (selectedIndex != -1)
                {
                    if (commandName == "ObjectSelectorUpdated")
                    {
                        _qualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                        Repaint();
                    }
                }
                GUILayout.BeginVertical();
                //Name
                _qualityDatabase.Get(i).Name =GUILayout.TextField(_qualityDatabase.Get(i).Name);
                //remove
                if (GUILayout.Button("X", GUILayout.Width(25), GUILayout.Height(25))) {
                    if(EditorUtility.DisplayDialog("Delete Quality", "Do you want to delete" + _qualityDatabase.Get(i).Name + " from the database?", "Delete", "Cancel"))
                    {
                        _qualityDatabase.Remove(i);
                    }
                }
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
        }
        
    }
}