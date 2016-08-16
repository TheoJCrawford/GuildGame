using UnityEngine;
using System.Collections;
using System;

namespace GG.ItemSystem
{
    [System.Serializable]
    public class ISWeapon : ISObject, IISWeapon, IISQuality, IISDestructable, IISEquipable, IISGameObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _durability;
        [SerializeField] private int _minDamage;
        [SerializeField] private int _maxDurability;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ISEquipmentSlot _equipSlot;

        public ISWeapon(int Durability, int MaxDurability, ISEquipmentSlot equipSlot)
        {
            _durability = Durability;
            _maxDurability = MaxDurability;
            _equipSlot = equipSlot;
        }
        public ISWeapon()
        {
            _equipSlot = new ISEquipmentSlot();
        }
        public Sprite Icon
        {
            get{ return _icon; }
            set{ _icon = value; }
        }
        public int MinDamage
        {
            get{ return _minDamage; }
            set { _minDamage = value; }
        }
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }
        public int Durability
        {
            get{ return _durability; }
        }
        public int MaxDurability
        {
            get {return _maxDurability; }
        }
        public ISEquipmentSlot EquipmentSlot
        {
            get { return _equipSlot; }
        }
        public GameObject Prefab
        {
            get{ return _prefab; }    
        }
        public int Attack()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            _durability -= amount;
            if(_durability < 0)
            {
               Break();
            }
        }
        public void Repair()
        {
            _durability = _maxDurability;
        }
        public void Break()
        {
            _durability = 0;
        }
        public bool Equip()
        {
            throw new NotImplementedException();
        }
    }
}