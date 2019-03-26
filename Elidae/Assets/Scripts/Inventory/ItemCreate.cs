using Assets.Scripts.Inventory.Item;
using Assets.Scripts.Inventory.ItemTypes;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemCreate : EditorWindow
{

    string Name;
    Texture2D Icon;
    int selected = 0;
    int DamageInput;
    int WorthInput;
    string Description;

    [MenuItem("Window/ItemCreate")]
    public static void ShowWindow()
    {
        GetWindow<ItemCreate>("ItemsCreate");
    }
    void OnGUI()
    {
        Name = EditorGUILayout.TextField("Name", Name);
        Icon = (Texture2D)EditorGUILayout.ObjectField("Image", Icon, typeof(Texture2D), false);
        Description = EditorGUILayout.TextField("Description", Description);


        string[] options = new string[]
        {
        "Weapon", "Boots", "Quest (not working)", "Accessory (not working)"
        };
        selected = EditorGUILayout.Popup("Type", selected, options);
        if (selected == 0)
        {
            DamageInput = EditorGUILayout.IntField("Damage:", DamageInput);
        }
        else if (selected == 1)
        {
            DamageInput = EditorGUILayout.IntField("Speed:", DamageInput);
        }
        else
        {
            DamageInput = 0;
        }

        WorthInput = EditorGUILayout.IntField("Worth in gold:", WorthInput);


    


        if (GUILayout.Button("Save item"))
        {
            SaveSystem.SaveItem(ItemCreateFunction());  
            //Debug.Log(Application.persistentDataPath + "/items.dat");
        }
  
    }


    private AItem ItemCreateFunction()
    {
        //List<AITSaveSystem.LoadItems(); // need to id changee to newest + disable it, yet still see it
        if (selected == 0)
        {
            Staff staff = new Staff();
            staff.Icon = Icon.name;
            staff.ItemID = SaveSystem.GetNewID();
            staff.Name = Name;
            staff.Price = WorthInput;
            staff.StaffType = 1;
            staff.ItemType = selected;
            staff.Damage = DamageInput;
            staff.Description = Description;
    
           
            return staff;
        }
        else if (selected == 1)
        {
            Boots boots = new Boots();
            boots.Name = Name;
            boots.Icon = Icon.name;
            boots.ItemID = SaveSystem.GetNewID();
            boots.Speed = DamageInput;
            boots.Price = WorthInput;
            boots.ItemType = selected;
            boots.Description = Description;
            return boots;
        }
        else if (selected == 2)
        {
            Quest_Item quest = new Quest_Item();
            return quest;
        }
        else
        {
            // do stuff here
            return null;
        }

    }
    

}
