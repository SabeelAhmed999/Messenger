using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharaterSelection : MonoBehaviour
{
    public GameObject[] Angels;
    public Button nextButtonState;
    int activeAngel=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Angels[1].activeSelf==true||Angels[2].activeSelf==true)
        {
            nextButtonState.interactable = false;
            nextButtonState.transform.GetChild(0).GetComponent<TMP_Text>().text ="Lock";
        }
        else
        {
            nextButtonState.interactable = true;
            nextButtonState.transform.GetChild(0).GetComponent<TMP_Text>().text = "Next";
        }
    }

    public void NextCharacter()
    {
        Angels[activeAngel].SetActive(false);
        if (activeAngel<Angels.Length-1)
        {
            activeAngel += 1;
        }
        else
        {
            activeAngel = 0;
        }
        Angels[activeAngel].SetActive(true);
    }

    public void PreviousCharacter()
    {
        Angels[activeAngel].SetActive(false);
        if (activeAngel>0)
        {
            activeAngel -= 1;
        }
        else
        {
            activeAngel = Angels.Length-1;
        }
        Angels[activeAngel].SetActive(true);
    }
}
