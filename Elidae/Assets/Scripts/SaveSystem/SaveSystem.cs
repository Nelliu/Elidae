using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Inventory.ItemTypes;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/items.dat";
    private static List<AItem> Items = new List<AItem>();
    private static List<string> FolderResources = new List<string>() { "boot", "accessory", "armor", "drops", "food", "glove","helmet", "material", "pill", "potion", "quest", "ring", "shield", "skill", "weapon"};

    // Static class for saving, loading functions, additional checks
    

    public static void SaveItem(AItem item)
    {
        List<AItem> items = new List<AItem>();
        BinaryFormatter formatter = new BinaryFormatter();
        if (!File.Exists(path))
        {
            
            items.Add(item);
            
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, items);
            stream.Close();
            Debug.Log("Saved1");
        }
        else
        {
            items = LoadItems();
            items.Add(item);

            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, items);
            stream.Close();
            Debug.Log("Saved");
        }


    }

    public static List<AItem> LoadItems() // load data from save file
    {
       

        BinaryFormatter formatter = new BinaryFormatter();
        if (File.Exists(path))
        {
            List<AItem> data = new List<AItem>();

       
            FileStream stream = File.Open(path, FileMode.Open);
            data = (List<AItem>)formatter.Deserialize(stream);
            stream.Close();
           // Debug.Log("Data loaded");
           // Debug.Log(Application.persistentDataPath + "/items.dat");
            return data;

        }
        else
        {
            List<AItem> data = new List<AItem>();


            FileStream stream = File.Open(path, FileMode.Create);
            data = (List<AItem>)formatter.Deserialize(stream);
            stream.Close();
            // Debug.Log("Data loaded");
            // Debug.Log(Application.persistentDataPath + "/items.dat");
          
            return data;
        }


    }
    public static bool FileExists()
    {
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static int GetNewID()
    {
        List<AItem> items = SaveSystem.LoadItems();
        if (items == null)
        {
            return 0;
        }
        else
        {
            return items.Count;
        }
        
    }

    public static AItem GetItem(int id)
    {
        Items = LoadItems();
        AItem item = null;


        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ItemID == id)
            {
                item = Items[i];
            }
        }
        if(item != null)
        {
            return item;
        }
        else
        {
            return null;
        }


    }

    public static Sprite GetImage(string imagename)
    {
        Sprite IconReturn = null;
        for (int i = 0; i < FolderResources.Count; i++)
        {
            //Debug.Log(imagename);
            //Debug.Log(FolderResources[0]);
            if (imagename.Contains(FolderResources[i]))
            {
                Sprite[] sprites;
                sprites = Resources.LoadAll<Sprite>("Icons/" + FolderResources[i]);
                //Debug.Log(sprites.Length + "LENGTH");
                for (int a = 0; a < sprites.Length; a++)
                {
                    if (sprites[a].name == imagename)
                    {
                        IconReturn = sprites[a];
                        //Debug.Log(IconReturn.name + "YO");
                        break; 
                    }
                }
                

                i = FolderResources.Count;
            
            }
        }
        if (IconReturn != null)
        {
            
            return IconReturn;
        }
        else
        {
            Debug.Log("Something is wrong");
            return null;
        }
            
    }

}
