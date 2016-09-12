using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using System.Linq;

namespace GG
{

    public class ScriptableObjectDatabase<T> : ScriptableObject where T: class
    {
        [SerializeField]
        List<T> database = new List<T>();
#if UNITY_EDITOR
        #region Functions
        public void Add(T entity)
        {
            database.Add(entity);
            EditorUtility.SetDirty(this);
        }
        public void Insert(int index, T entity)
        {
            database.Insert(index, entity);
            EditorUtility.SetDirty(this);
        }
        public void Remove(T entity)
        {
            database.Remove(entity);
            EditorUtility.SetDirty(this);
        }
        public void Remove(int index)
        {
            database.RemoveAt(index);
            EditorUtility.SetDirty(this);
        }
        public int Count
        {
            get { return database.Count; }
        }
        public T Get(int index)
        {
            return database.ElementAt(index);
        }
        public void Replace(int index, T entity)
        {
            database[index] = entity;
            EditorUtility.SetDirty(this);
        }
        #endregion
        #region Static Functions        
        public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

            U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;
            if(db == null)
            {
                if(!AssetDatabase.IsValidFolder(@"Assets/"+ dbPath))
                {
                    AssetDatabase.CreateFolder(@"Assets", dbPath);
                }
                db = ScriptableObject.CreateInstance <U>() as U;
                AssetDatabase.CreateAsset(db, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            return db;


        }
        #endregion
#endif
    }
}