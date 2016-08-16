using UnityEngine;
using System.Collections;
using System;

namespace GG.ItemSystem
{
    [Serializable]
    public class ISQuality : IISQuality
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _icon;

        public string Name
        {
            get{ return _name; }

            set{ _name = value; }
        }

        public Sprite Icon
        {
            get
            { return _icon; }

            set { _icon = value; }
        }

        public ISQuality()
        {
            _name = string.Empty;
            _icon = new Sprite();
        }
    }
}