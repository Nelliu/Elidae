using Assets.Scripts.Inventory.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts.Inventory.Item
{
    [System.Serializable]
    public class Boots : AItem
    {
        public int Speed { get; set; }
     
    }
}
