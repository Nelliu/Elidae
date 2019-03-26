using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ToInvFromEquip : MonoBehaviour
{

    private GameObject[] InventorySlots = Inventory.InvSlots; // inventory slots (objects)
    public GameObject Icon;
    public GameObject ParentButton;


    private List<string> parents = new List<string>() { "Weapon", "Belt", "Accessory_1", "Accessory_2", "Gloves", "Legs", "Body", "Head" };
    private List<Sprite> sprites = new List<Sprite>() {};
    private List<string> originalSprites = new List<string>() { "weapon_133", "accessory_01", "accessory_41", "accessory_21", "glove_01", "boot_02", "armor_130", "helmet_06" };

    private Text itemIDcomponent;
    private Image image;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = Color.white;
        color.a = 0.3f;
        image = Icon.GetComponent<Image>();
        itemIDcomponent = gameObject.GetComponent<Text>();

        for (int i = 0; i < parents.Count; i++)
        {
            sprites.Add(SaveSystem.GetImage(originalSprites[i]));
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ItemAction()
    {
        if (Inventory.FilledSlots.Count != 28 && image.color.a == 255)
        {
            for (int i = 0; i < parents.Count; i++)
            {
                if (ParentButton.name.Contains(parents[i]))
                {
                    image.sprite = sprites[i];
                    image.color = color;
                    Inventory.AddItem(int.Parse(itemIDcomponent.text));
                    itemIDcomponent.text = "-888";
                    
                    break;
                }
            }
        }
        else print("inventory full"); 
    }
    public static void ItemAction(int itemtype)
    {
        // switching places if something is already equipped
    }


}
