using Assets.Scripts.Inventory.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Assets.Scripts.Inventory
{
    public class ItemsList : EditorWindow
    {
        public List<AItem> Items;
        private List<string> Ids;
        public string Itemz;



        [MenuItem("Window/Items list")]
        public static void ShowWindow()
        {
            GetWindow<ItemsList>("Items list");
        }

        private void OnEnable()
        {
            if (SaveSystem.FileExists())
            {
                Items = SaveSystem.LoadItems();
                for (int i = 0; i < Items.Count; i++)
                {
                    Itemz = Itemz + Items[i].ItemID + " " + Items[i].Name + " " + Items[i].ItemType +"<- item type\n";
                }
            }
            else
            {
                Items = null;
            }
            
         
        }

        private void OnGUI()
        {




            EditorGUILayout.TextArea(Itemz);
         

        }




    }
}
