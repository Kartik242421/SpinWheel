using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import SceneManagement
using Unity.VisualScripting;

public class Form : MonoBehaviour
{
    public TMP_InputField Name, Email, number;
    public Button SubmitButton;
    private AuthHandler _authHandler;

    public bool osk;
    public KeyboardScript OSK;

   void Start()
    {
        GameModeDDOL.instance.playerName = null;
        GameModeDDOL.instance.email = null;
        GameModeDDOL.instance.number = null;
        GameModeDDOL.instance.score = 0;
        Name.text = ""; 
        Email.text = "";

        _authHandler = AuthHandler.instance;
        OSK.gameObject.SetActive(false);
    }

    public void OnValueChangeName()
    {
        if (Name.text.Length >= 3 && number.text.Length == 10)
        {
            SubmitButton.interactable = true;
        }
        else
        {
            SubmitButton.interactable = false;
        }
    }

    public void OnSubmitButton()
    {
        GameModeDDOL.instance.playerName = Name.text;
        GameModeDDOL.instance.email = Email.text;
        GameModeDDOL.instance.number = number.text;


      _authHandler.Login(Name.text,number.text);
        // Load the desired scene
        SceneManager.LoadScene("MOBIL"); // Replace "YourSceneName" with the actual scene name
    }

    public void onSelectedField(TMP_InputField inputField)
    {
        if (osk)
        {
            OSK.TextField = inputField;
            OSK.gameObject.SetActive(true);
        }
    }
}
