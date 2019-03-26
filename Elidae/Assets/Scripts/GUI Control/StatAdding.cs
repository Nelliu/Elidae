using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatAdding : MonoBehaviour
{

    public GameObject ObjectWithTextMesh;
    private TextMeshProUGUI textM;
    private int containingText;



    // Start is called before the first frame update
    void Start()
    {
        textM = ObjectWithTextMesh.GetComponent<TextMeshProUGUI>();
        bool Parsing = int.TryParse(textM.text, out containingText);
       // Debug.Log(containingText);

    }

    public void AddStat()
    {
        
        containingText = containingText + 1;
        textM.text = containingText.ToString();
    }

}
