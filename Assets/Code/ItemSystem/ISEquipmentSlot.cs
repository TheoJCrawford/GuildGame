using UnityEngine;
using System.Collections;
using System;

namespace GG.ItemSystem
{
    public class ISEquipmentSlot : IISEquipmentSlot
    {
        private string _name;
        private Sprite _icon;



        public Sprite icon
        {
            get{ return _icon; }

            set{ _icon = value; }
        }

        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }

        public ISEquipmentSlot()
        {
            _name = string.Empty;
            _icon = new Sprite();
        }
    }
}