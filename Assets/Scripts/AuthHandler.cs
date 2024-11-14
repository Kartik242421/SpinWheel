using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthHandler : MonoBehaviour
{
    public static AuthHandler instance;
    public UserData currentUser;
    public List<UserData> users=new();
    private SaveSystem _saveSystem;

    void Start()
    {
        _saveSystem=GetComponent<SaveSystem>();
        users= _saveSystem.GetData();

        //Singelton Pattern...
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
    }


    public void Login(string _name,string _phoneNumber,string _workshop) {
        PlayerPrefs.SetString("uid", _phoneNumber);
        PlayerPrefs.Save();
        print(_workshop);
        currentUser = new UserData { name =_name, phoneNumber = _phoneNumber, score = "NA",workshop= _workshop };
    }

    public void CheckPersistLogin()
    {
        string uid =  PlayerPrefs.GetString("uid");
        print(uid);
        if (uid != null && uid != "")
        {
            UserData user = users.Find(user => user.phoneNumber == uid);
            if (user!.phoneNumber != null)
            {
                currentUser = user;
                SceneManager.LoadScene("MOBIL");
            }
            else
            {
                print("User Not Found");
            }
        }


    }

    public void Logout() {
        PlayerPrefs.DeleteKey("uid");
        //Setting current user to none...
        currentUser = new UserData { name="",phoneNumber="",score="NA",workshop="NA"};
        SceneManager.LoadScene("Login");
    }

    public void SaveScore(string _score)
    {
        currentUser.score = _score;
        users.Add(currentUser);
        _saveSystem.Save(users);
    }

}
