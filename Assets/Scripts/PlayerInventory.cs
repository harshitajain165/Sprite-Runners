using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    void Start(){
        for(int i =0;i<gameObject.transform.childCount; i++){
            if(i == PlayerPrefs.GetInt("selectedOption"))
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            else
                gameObject.transform.GetChild(i).gameObject.SetActive(false);    
        }
    }  

    public int NumberOfRewards { get; private set;}

    public void RewardCollected(){
        NumberOfRewards++;
    }
}
