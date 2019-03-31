using Assets.Scripts.Inventory.ItemTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject InventoryUI;
    public GameObject EquipmentUI;

   

    public string ItemToAdd;
    public GameObject[] InventorySlots;

    public static GameObject[] InvSlots;

    private static List<Image> Images = new List<Image>();

    public static List<int> FilledSlots = new List<int>();

    public static List<Text> Ids = new List<Text>();



   
        
    // Start is called before the first frame update
    void Start()
    { 
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            Images.Add(InventorySlots[i].transform.Find("Icon").GetComponent<Image>());
            Ids.Add(InventorySlots[i].transform.Find("Id").GetComponent<Text>());
          

            if (i != 0)
            {
                InventorySlots[i].transform.Find("Id").GetComponent<ToEquipFromInv>().FieldID = i;
            }
            
            


        }

        InvSlots = InventorySlots; // so other scripts can access and change it easily
  
    //    Debug.Log(Images.Count + " count");
    }

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;



    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.active != true)
            {
                InventoryUI.SetActive(true);
            }
            else
            {
                InventoryUI.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            AddItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                Debug.Log("Double CLick:");

            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (EquipmentUI.active == true)
            {
                EquipmentUI.SetActive(false);

            }
            else EquipmentUI.SetActive(true);
        }
       


        
                
    }
        
    
    

    public static void AddItem(int ItemToAdd)
    {
        AItem adding = SaveSystem.GetItem(ItemToAdd);
        //Debug.Log(adding.Icon);
        //Debug.Log(adding.ItemID);
        // Debug.Log(SaveSystem.GetImage(adding.Icon).name);
        
        for (int i = 0; i < Images.Count; i++)
        {
            if (Images[i].IsActive() == false && !FilledSlots.Contains(i))
            {  
                FilledSlots.Add(i);
            
                Images[i].enabled = true;
                Color color = Color.white;
                color.a = 255;
                Images[i].color = color;
                Images[i].sprite = SaveSystem.GetImage(adding.Icon); 
                

                
                Ids[i].text = (adding.ItemID).ToString();
 

                break;
            }
            else
            {
                //Debug.Log("Inventory full"); // --> only if this happens 28x tho, it actually means that slot is full
            }
        }

       
    }



}
