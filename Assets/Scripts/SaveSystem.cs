using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string path;
    public static SaveSystem instance;
  

    private void Awake()
    {
        path = Application.persistentDataPath + "/data.txt";
    }

    void Start()
    {
        //Singelom Pattern...
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

    public void Save(List<UserData> data)
    {
        StreamWriter sw = new StreamWriter(path);
        sw.AutoFlush = true;

        foreach (UserData userData in data)
        {
            sw.WriteLine($"{userData.name},{userData.score},{userData.phoneNumber}");
        }
        sw.Close();
    }

    public List<UserData> GetData()
    {
       List<UserData> users= new List<UserData>();
        if (!File.Exists(path))
        {
            print("File Doesnt Exists");
            return users;
        }
            string[] text=  File.ReadAllLines(path);
        foreach (string line in text)
        {
            string[] data = line.Split(",");
            users.Add(new UserData { name = data[0], score = data[1], phoneNumber = data[2] }) ;
        }
        return users;
    }
}
