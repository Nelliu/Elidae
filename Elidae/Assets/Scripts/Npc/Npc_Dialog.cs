using Assets.Scripts.Npc;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Npc_Dialog : MonoBehaviour
{
    [TextArea]
    public string[] NpcDialog;

    [TextArea]
    public string[] PlayerDialog;

    // Npc actions ˇˇ 
    public string NpcName;
    private string SpeakingTo;

    private GameObject dialog;
    private GameObject DialogWindowUI;
    private GameObject DialogUI;
    public GameObject NpcNameMesh;

    public int GiveItemID = -1;


    // Dialog UI actions ˇˇ
    private GameObject dialogText;
    private GameObject dialogName;

    private DialogTurn Turn = new DialogTurn();

    private bool dialogActive;




    // Start is called before the first frame update
    void Start()
    {

        SpeakingTo = "Player";

        dialog = GameObject.FindGameObjectWithTag("Dialog");
        DialogWindowUI = dialog.transform.Find("DialogWindow").gameObject;
        DialogUI = DialogWindowUI.transform.Find("Dialog").gameObject;

        Turn.NpcDialogLenght = NpcDialog.Length;
        Turn.PlayerDialogLenght = PlayerDialog.Length;
        Turn.PlayerTurn = false;
       
        dialogText = DialogUI.transform.Find("DialogText").gameObject;
        dialogName = DialogUI.transform.Find("DialogCharName").gameObject;

        Turn.DialogName = dialogName.GetComponent<TextMeshProUGUI>();
        NpcNameMesh.GetComponent<TextMeshProUGUI>().text = NpcName;
        Turn.Dialog = dialogText.GetComponent<TextMeshProUGUI>();


    }

    // Update is called once per frame
    void Update()
    {
       
       if (dialogActive == true)
       {
            if (Turn.FirstToTalk == true)
            {
                Turn.Dialog.text = NpcDialog[0];
                Turn.DialogName.text = NpcName;
                Turn.FirstToTalk = false;
                Turn.PlayerTurn = true;
                Turn.NTurn++;
            }



            if (Input.GetKeyDown(KeyCode.Return) == true)
            {
                
               if (Turn.PlayerTurn == true && Turn.PTurn < Turn.PlayerDialogLenght)
               {
                    Turn.DialogName.text = SpeakingTo;
                    Turn.Dialog.text = PlayerDialog[Turn.PTurn];
                    Turn.PlayerTurn = false;
                    Turn.PTurn++;
                    //Debug.Log(Turn.PTurn + " " + Turn.PlayerDialogLenght);
               }
               else if (Turn.PlayerTurn == false && Turn.NTurn < Turn.NpcDialogLenght)
               {
                   // Debug.Log("it gets here");
                    Turn.DialogName.text = NpcName;
                    Turn.Dialog.text = NpcDialog[Turn.NTurn];
                    Turn.NTurn++;
                    Turn.PlayerTurn = true;
                  //  Debug.Log(Turn.NTurn + Turn.NpcDialogLenght);
                    
               }
               else if (Turn.NTurn == Turn.NpcDialogLenght && Turn.PTurn == Turn.PlayerDialogLenght)
               {
                    if (GiveItemID != -1)
                    {
                        Inventory.AddItem(GiveItemID);
                    }
                     
                    Turn.Default();
                    Movement.MovementDisabled = false;
                    DialogWindowUI.SetActive(false);

                    dialogActive = false;

               }



            }

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKeyDown(KeyCode.R) == true && collision.tag == "Player")
        {
            
            Movement.MovementDisabled = true;
            DialogWindowUI.SetActive(true);
            dialogActive = true;
        }

        
    }
}
