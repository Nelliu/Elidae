using Assets.Scripts.Inventory.ItemTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToEquipFromInv : MonoBehaviour
{

    private Text itemIDComponent;
    private int itemID; // this will be filled with real number if it gets one
    public GameObject imageComponent;
    public int FieldID;

    public GameObject[] EquipObjects; // should be in same order as item types are, means weapon 0, boots 1 etc. - viz Item folder, would be decent to go same as list in "ToInvFromEquip.cs"

    private List<GameObject> buttons = new List<GameObject>();
    private List<int> itemTypes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
    private Image ObjectImage;
    private Text equipItemID;
    private bool parsed;
    private Color color = Color.white;
    private int itemControl;
    private AItem loadItem;

    // Start is called before the first frame update
    void Start()
    {
    



        color.a = 255;
        itemIDComponent = gameObject.GetComponent<Text>();
        
        if (itemIDComponent.text != string.Empty)
        {
            bool parse = int.TryParse(itemIDComponent.text, out itemControl);
            if (itemControl == -888)
            {
                itemID = -1;
            }
            else
            {
                itemID = itemControl;
            }
        }
        

       

    }

    // Update is called once per frame
    void Update()
    {
        if (itemIDComponent.text != "" && parsed == false)
        {
            bool parse = int.TryParse(itemIDComponent.text, out itemControl);
            parsed = true;
            if (itemControl == -888)
            {
                itemID = -1;
            }
            else
            {
                itemID = itemControl;
            }


        }
    }

    private void RemoveFromInventoryList() // removes item from inventory
    {
        imageComponent.GetComponent<Image>().enabled = false;
        itemIDComponent.text = "";

        for (int i = 0; i < Inventory.FilledSlots.Count; i++)
        {
            if (Inventory.FilledSlots[i] == FieldID)
            {
                Inventory.FilledSlots.Remove(i);
                Inventory.EquippedItems.Add(loadItem.ItemID);
            }

        }
    }


    public void ItemAction()
    {
        parsed = false;
        
        if(SaveSystem.FileExists())
        {
         
            if (itemID != -1)
            {
          
                loadItem = SaveSystem.GetItem(itemID);
                for (int i = 0; i < itemTypes.Count; i++)
                {
                    if (itemTypes[i] == loadItem.ItemType)
                    {
                        ObjectImage = EquipObjects[i].transform.Find("Icon").GetComponent<Image>();
                        equipItemID = EquipObjects[i].transform.Find("Id").GetComponent<Text>();
                        if (ObjectImage.color.a != 255) // fill image in equip for weapon == equipped
                        {
                            ObjectImage.color = color;
                            equipItemID.text = (loadItem.ItemID).ToString();
                            ObjectImage.sprite = SaveSystem.GetImage(loadItem.Icon);

                            RemoveFromInventoryList();
                            break;
                        }
                        else
                        {
                            // something is here
                            
                           /* ObjectImage.color = color;
                            equipItemID.text = (loadItem.ItemID).ToString();
                            ObjectImage.sprite = SaveSystem.GetImage(loadItem.Icon);

                            RemoveFromInventoryList();
                            ToInvFromEquip.ItemAction(loadItem.ItemType);
                            break;*/
                        }
                    }
                }
               

            }
            
            
            
            
        }
        else
        {
            Debug.Log("?");
        }
    }
}
