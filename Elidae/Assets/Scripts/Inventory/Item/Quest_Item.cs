using Assets.Scripts.Inventory.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Inventory.Item
{
    [System.Serializable]
    public class Quest_Item : AItem
    {
        public GameObject GetFrom { get; set; }
        public GameObject GiveTo { get; set; }
       
        public string ItemDescription { get; set; }
    }
}
