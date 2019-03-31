using Assets.Scripts.Inventory.Item;
using Assets.Scripts.Inventory.ItemTypes;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject InfoTable;
    public GameObject InventoryPlace;
    public GameObject EquipPlace;
    public GameObject QuestPlace;



    private Image Image;
    private AItem item;
    private int itemID;
    private GameObject IdObject;
    private List<string> EquipNames = new List<string>() { "Head_Button", "Legs_Button", "Gloves_Button", "Accessory_1_Button", "Accessory_2_Button", "Weapon_Button" };
    



    
   


    // Start is called before the first frame update
    void Start()
    {
        Image = transform.Find("Icon").GetComponent<Image>();
        IdObject = transform.Find("Id").gameObject;
        

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void OnPointerEnter(PointerEventData eventData)
    {

        if (Image.enabled == true && Image.color.a == 255 )
        {

            item = SaveSystem.GetItem(int.Parse(IdObject.GetComponent<Text>().text));

            string stats = "";
            if (item.ItemType == 0)
            {
                Staff staff = (Staff)item;
                stats = "Damage +" + staff.Damage;
            }
            else if (item.ItemType == 1)
            {
                Boots boots = (Boots)item;
                stats = "Speed +" + boots.Speed;
            }

            InfoTable.SetActive(true);


            InfoTable.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.Name;
            InfoTable.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = item.Description;
            InfoTable.transform.Find("Stats").GetComponent<TextMeshProUGUI>().text = stats;
            InfoTable.transform.Find("Icon").GetComponent<Image>().sprite = SaveSystem.GetImage(item.Icon);
            InfoTable.transform.Find("Worth").GetComponent<TextMeshProUGUI>().text = (item.Price).ToString();

            Vector2 infotablePosition = eventData.position;
            infotablePosition.x = infotablePosition.x + 1;

            InfoTable.transform.position = infotablePosition;

        }
      
          

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InfoTable.SetActive(false);
    }

 
}
