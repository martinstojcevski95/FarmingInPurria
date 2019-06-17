using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;
    // Start is called before the first frame update



    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        MasterContractID = PlayerPrefs.GetInt("MASTERCONTRACTID");

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        RetreiveData();

    }


    void RetreiveData()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("USERS")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              Debug.Log(snapshot.GetRawJsonValue());
              // Do something with snapshot...
          }
      });
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GenerateRandomNewGameID()
    {
        int randomNewContractID = UnityEngine.Random.Range(0, 123456789);
        MasterContractID += 1;
        if(MasterContractID  <=4)
        PlayerPrefs.SetInt("MASTERCONTRACTID", MasterContractID);
        reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACTID" + MasterContractID).SetRawJsonValueAsync(randomNewContractID.ToString());
        Debug.Log(randomNewContractID);

    }


    // PRIVATE VARIABLES
    int MasterGameSpaceID;
    int MasterContractID;
    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";
}
