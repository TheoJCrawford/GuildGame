using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace GG.ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        /*   [HideInInspector]
           public List<ISQuality> db = new List<ISQuality>();

           public void Add(ISQuality quality)
           {
               db.Add(quality);
               EditorUtility.SetDirty(this);
           }
           public void Insert(int index, ISQuality quality)
           {
               db.Insert(index, quality);
               EditorUtility.SetDirty(this);
           }
           public void Remove(ISQuality quality)
           {
               db.Remove(quality);
               EditorUtility.SetDirty(this);
           }
           public void Remove(int index)
           {
               db.RemoveAt(index);
               EditorUtility.SetDirty(this);
           }
           public int Count
           {
               get { return db.Count; }
           }
           public ISQuality Get(int index)
           {
               return db.ElementAt(index);
           }
           public void Replace(int index, ISQuality quality)
           {
               db[index] = quality;
               EditorUtility.SetDirty(this);
           }
           */
    }
}