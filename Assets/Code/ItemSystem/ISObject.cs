using UnityEngine;
using System.Collections;
using System;

namespace GG.ItemSystem
{
    public class ISObject : IISObject
    {
        #region Variables

        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private int _price;
        [SerializeField]
        private ISQuality _quality;
        [SerializeField]
        private double _weight;
        #endregion
        #region Setters and Getters
        Sprite IISObject.ISIcon
        {
            get{ return _icon; }
            set{ _icon = value; }
        }
        string IISObject.ISName
        {
            get{ return _name; }
            set{ _name = value; }
        }
        ISQuality IISObject.ISQuality
        {
            get{ return _quality; }
            set{ _quality = value; }
        }
        int IISObject.ISValue
        {
            get
            { return _price; }
            set
            { _price = value; }
        }
        double IISObject.ISWeight
        {
            get{ return _weight; }
            set{ _weight = value; }
        }
        #endregion

        public ISObject() {
            _name = string.Empty;
            _icon = new Sprite();
            _price = 0;

            _weight = 0;
        }
    }
}