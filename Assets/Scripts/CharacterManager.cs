using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public CharacterDatabase characterDB;
    public Image artworkSprite;
    public TMP_Text nameText;

    public int selectedOption = 0;

void Awake(){
    instance = this;
}

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("selectedOption")){
            selectedOption = 0;
        }

    else{
        Load();
    }

        UpdateCharacter(selectedOption);
    }

    public void NextOption(){
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount){
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption(){

        selectedOption--;
        if(selectedOption < 0){
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save(){
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID){
        SceneManager.LoadScene(sceneID);
    }

}
