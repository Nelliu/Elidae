using Assets.Scripts.Inventory.ItemTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject InventoryUI;

    public List<AItem> InventoryList = new List<AItem>();
    public string ItemToAdd;
    public GameObject[] InventorySlots;
    public Component[] Images;

    // Start is called before the first frame update
    void Start()
    {
        InventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            Images[i] = InventorySlots[i].GetComponent<Image>
        }


    }

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
    }

    public bool AddItem(string ItemToAdd)
    {

    }



}
