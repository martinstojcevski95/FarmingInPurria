using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageContract : MonoBehaviour
{

    public AllContracts Contracts;
    public List<SingleContractForManaging> ContractsForManaging = new List<SingleContractForManaging>();

    public static ManageContract Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;

    }


    /// <summary>
    /// Retreiving data when ManageContracts is oppened in STANDARDUSER
    /// </summary>
    public void RetreiveDataForSelectedConract()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID)
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              Contracts = new AllContracts();
              string res = snapshot.GetRawJsonValue();
              Contracts = JsonUtility.FromJson<AllContracts>(res);
    
              if (Contracts != null)
              {
                  //MasterUserManager.Instance.MasterContractID = 0;
                  //PlayerPrefs.SetInt("mstrcontractcounter", MasterUserManager.Instance.MasterContractID);
                  //MasterUserManager.Instance.MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterUserManager.Instance.MasterContractID);
                  if (Contracts.GAMESPACE.CONTRACT0 != null)
                  {

                      ContractsForManaging[0].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT0.ContractDescription;
                      ContractsForManaging[0].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT0.ContractID;
                      ContractsForManaging[0].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT0.isContractStarted;

                  }
                  if (Contracts.GAMESPACE.CONTRACT1 != null)

                  {

                      ContractsForManaging[1].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT1.ContractDescription;
                      ContractsForManaging[1].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT1.ContractID;
                      ContractsForManaging[1].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT1.isContractStarted;

                  }
                  if (Contracts.GAMESPACE.CONTRACT2 != null)
                  {

                      ContractsForManaging[2].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT2.ContractDescription;
                      ContractsForManaging[2].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT2.ContractID;
                      ContractsForManaging[2].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT2.isContractStarted;

                  }
                  if (Contracts.GAMESPACE.CONTRACT3 != null)
                  {

                      ContractsForManaging[3].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT3.ContractDescription;
                      ContractsForManaging[3].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT3.ContractID;
                      ContractsForManaging[3].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT3.isContractStarted;

                  }

              }
              else
              {
                  ContractsForManaging[0].SingleContract.ContractDescription = "";
                  ContractsForManaging[0].SingleContract.ContractID = 0;
                  ContractsForManaging[0].SingleContract.isContractStarted = false;


                  ContractsForManaging[1].SingleContract.ContractDescription = "";
                  ContractsForManaging[1].SingleContract.ContractID = 0;
                  ContractsForManaging[1].SingleContract.isContractStarted = false;


                  ContractsForManaging[2].SingleContract.ContractDescription = "";
                  ContractsForManaging[2].SingleContract.ContractID = 0;
                  ContractsForManaging[2].SingleContract.isContractStarted = false;


                  ContractsForManaging[3].SingleContract.ContractDescription = "";
                  ContractsForManaging[3].SingleContract.ContractID = 0;
                  ContractsForManaging[3].SingleContract.isContractStarted = false;


              }
          }

      });
    }


    /// <summary>
    /// When Clicking on each contract in the Manage Contracts in StandardUser, this will populate data to each of them from the DB
    /// </summary>
    /// <param name="ManagingContractButtonIndexNumber"></param>
    //public void PopulateContractsWithDataFromDB(int ManagingContractButtonIndexNumber)
    //{
    //    if (ManagingContractButtonIndexNumber == 0)
    //    {
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT1.ContractDescription;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT1.ContractID;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT1.isContractStarted;

    //    }
    //    else if (ManagingContractButtonIndexNumber == 1)
    //    {
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT2.ContractDescription;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT2.ContractID;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT2.isContractStarted;

    //    }
    //    else if (ManagingContractButtonIndexNumber == 2)
    //    {
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT3.ContractDescription;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT3.ContractID;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT3.isContractStarted;
    //    }
    //    else if (ManagingContractButtonIndexNumber == 3)
    //    {
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractDescription = Contracts.GAMESPACE.CONTRACT4.ContractDescription;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.ContractID = Contracts.GAMESPACE.CONTRACT4.ContractID;
    //        ContractsForManaging[ManagingContractButtonIndexNumber].SingleContract.isContractStarted = Contracts.GAMESPACE.CONTRACT4.isContractStarted;
    //    }

  //  }

    [Serializable]
    public class CONTRACT0
    {
        public string ContractDescription;
        public int ContractID;
        public bool isContractStarted;

    }

    [Serializable]
    public class CONTRACT1
    {
        public string ContractDescription;
        public int ContractID;
        public bool isContractStarted;

    }

    [Serializable]
    public class CONTRACT2
    {
        public string ContractDescription;
        public int ContractID;
        public bool isContractStarted;
    }

    [Serializable]
    public class CONTRACT3
    {
        public string ContractDescription;
        public int ContractID;
        public bool isContractStarted;
    }

    [Serializable]
    public class GAMESPACE
    {
        public CONTRACT0 CONTRACT0;
        public CONTRACT1 CONTRACT1;
        public CONTRACT2 CONTRACT2;
        public CONTRACT3 CONTRACT3;
    }

    [Serializable]
    public class AllContracts
    {
        public GAMESPACE GAMESPACE;
    }



    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";
}
