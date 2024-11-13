using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Transform _content;
    public GameObject _entryPrefab;
    public Button logoutBtn;

    private void Start()
    {
        logoutBtn.onClick.AddListener(() => AuthHandler.instance.Logout());
    }

    private void OnDisable()
    {
        logoutBtn.onClick.RemoveAllListeners();
    }
    private void OnEnable()
    {
        foreach(UserData user in AuthHandler.instance.users)
        {
          GameObject go=  Instantiate(_entryPrefab, _content);
        Entries entry=    go.GetComponent<Entries>();
            entry._name.text = user.name;
            entry.score.text= user.score;
        }
    }
}
