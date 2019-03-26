using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Inventory.ItemTypes
{
    [System.Serializable]
    public abstract class AItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } 
        public string Icon { get; set; }
        public int ItemType { get; set; }
        public string Description { get; set; }

        public bool SellItem()
        {


            return true;
        }
        public bool DropItem()
        {

            return true;
        }


    }
}
