using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Inventory.ItemTypes;
using System.Collections.Generic;

public static class SaveSystem 
{
    private static string path = Application.persistentDataPath + "/items.dat   ";
    private static List<AItem> Items = new List<AItem>();
    
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

       
            FileStream stream = File.Open(Application.persistentDataPath + "/items.dat", FileMode.Open);
            data = (List<AItem>)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("Data loaded");
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
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


}
