using Assets.Scripts.Inventory.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Inventory.Item
{
    [System.Serializable]
    public class Staff : AItem, IBattle
    {
        public int StaffType { get; set; }  // for example 1 for fire staff 
        public int Damage { get; set; }
        public void DealDamage()
        {
            // deal damage logic for staff 
        }
    }
}
