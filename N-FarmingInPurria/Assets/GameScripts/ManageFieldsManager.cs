using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFieldsManager : MonoBehaviour
{
    // public AllPlants allPlants;
    public static ManageFieldsManager Instance;
    public AllContractsAndPlants allContractsAndPlants;
    // Start is called before the first frame update
    public bool isThereAnyData;
    public bool CheckerForDataForContracts;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        CheckerForDataForContracts = true;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void RetreiveDataForFieldPlants()
    {
        FirebaseDatabase.DefaultInstance
              .GetReference("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID)
              .GetValueAsync().ContinueWith(task =>
              //.GetReference("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT0")
              //.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.GetRawJsonValue());
                allContractsAndPlants = new AllContractsAndPlants();
                //  allPlants = new AllPlants();
                string res = snapshot.GetRawJsonValue();
   
                allContractsAndPlants = JsonUtility.FromJson<AllContractsAndPlants>(res);
                // allPlants = JsonUtility.FromJson<AllPlants>(res);

                if (allContractsAndPlants != null)
                {
                    isThereAnyData = true;
                    if (allContractsAndPlants.GAMESPACE.CONTRACT0 != null)
                    {
                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT0.isPlantInContract;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT1.isPlantInContract;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT2.isPlantInContract;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT3.isPlantInContract;

                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT0.isPlantPlanted;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT1.isPlantPlanted;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT2.isPlantPlanted;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT3.isPlantPlanted;

                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT0.ContractID;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT1.ContractID;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT2.ContractID;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT3.ContractID;


                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT0.GrowthDays;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT1.GrowthDays;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT2.GrowthDays;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT0.PLANTS.PLANT3.GrowthDays;

                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isDroneAssigned = true;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isDroneAssigned = true;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isDroneAssigned = true;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isDroneAssigned = true;

                        MasterUserManager.Instance.FirstRowPlants[0].canGrow = true;
                        MasterUserManager.Instance.FirstRowPlants[1].canGrow = true;
                        MasterUserManager.Instance.FirstRowPlants[2].canGrow = true;
                        MasterUserManager.Instance.FirstRowPlants[3].canGrow = true;

                
                    }
           
          

                    if (allContractsAndPlants.GAMESPACE.CONTRACT1 != null)
                    {
                        MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT0.isPlantInContract;
                        MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT1.isPlantInContract;
                        MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT2.isPlantInContract;
                        MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT3.isPlantInContract;

                        MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT0.isPlantPlanted;
                        MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT1.isPlantPlanted;
                        MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT2.isPlantPlanted;
                        MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT3.isPlantPlanted;

                        MasterUserManager.Instance.SecondRowPlants[0].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT0.ContractID;
                        MasterUserManager.Instance.SecondRowPlants[1].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT1.ContractID;
                        MasterUserManager.Instance.SecondRowPlants[2].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT2.ContractID;
                        MasterUserManager.Instance.SecondRowPlants[3].singlePlant.ContractID = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT3.ContractID;

                        MasterUserManager.Instance.SecondRowPlants[0].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT0.GrowthDays;
                        MasterUserManager.Instance.SecondRowPlants[1].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT1.GrowthDays;
                        MasterUserManager.Instance.SecondRowPlants[2].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT2.GrowthDays;
                        MasterUserManager.Instance.SecondRowPlants[3].singlePlant.GrowthDays = allContractsAndPlants.GAMESPACE.CONTRACT1.PLANTS.PLANT3.GrowthDays;


                        MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isDroneAssigned = true;
                        MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isDroneAssigned = true;
                        MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isDroneAssigned = true;
                        MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isDroneAssigned = true;

                        MasterUserManager.Instance.SecondRowPlants[0].canGrow = true;
                        MasterUserManager.Instance.SecondRowPlants[1].canGrow = true;
                        MasterUserManager.Instance.SecondRowPlants[2].canGrow = true;
                        MasterUserManager.Instance.SecondRowPlants[3].canGrow = true;
                    }
                  
                    //else
                    //{
                    //    MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isItClickable = false;                        MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isItClickable = false;                        MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isItClickable = false;                       MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isItClickable = false;

                    //}

                    if (allContractsAndPlants.GAMESPACE.CONTRACT2 != null)
                    {
                        MasterUserManager.Instance.ThirdowPlants[0].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT0.isPlantPlanted;
                        MasterUserManager.Instance.ThirdowPlants[1].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT1.isPlantPlanted;
                        MasterUserManager.Instance.ThirdowPlants[2].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT2.isPlantPlanted;
                        MasterUserManager.Instance.ThirdowPlants[3].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT3.isPlantPlanted;

                        MasterUserManager.Instance.ThirdowPlants[0].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT0.isPlantInContract;
                        MasterUserManager.Instance.ThirdowPlants[1].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT1.isPlantInContract;
                        MasterUserManager.Instance.ThirdowPlants[2].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT2.isPlantInContract;
                        MasterUserManager.Instance.ThirdowPlants[3].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT2.PLANTS.PLANT3.isPlantInContract;

                        MasterUserManager.Instance.ThirdowPlants[0].canGrow = true;
                        MasterUserManager.Instance.ThirdowPlants[1].canGrow = true;
                        MasterUserManager.Instance.ThirdowPlants[2].canGrow = true;
                        MasterUserManager.Instance.ThirdowPlants[3].canGrow = true;

                    }

                    if (allContractsAndPlants.GAMESPACE.CONTRACT3 != null)
                    {
                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT0.isPlantPlanted;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT1.isPlantPlanted;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT2.isPlantPlanted;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isPlantPlanted = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT3.isPlantPlanted;

                        MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT0.isPlantInContract;
                        MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT1.isPlantInContract;
                        MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT2.isPlantInContract;
                        MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isPlantInContract = allContractsAndPlants.GAMESPACE.CONTRACT3.PLANTS.PLANT3.isPlantInContract;

                        MasterUserManager.Instance.FourthRowPlants[0].canGrow = true;
                        MasterUserManager.Instance.FourthRowPlants[1].canGrow = true;
                        MasterUserManager.Instance.FourthRowPlants[2].canGrow = true;
                        MasterUserManager.Instance.ThirdowPlants[3].canGrow = true;

                    }
                }
              else
                {
                    isThereAnyData = false;
                    CheckerForDataForContracts = false;
                    Debug.Log("null, no data ");
                    MasterUserManager.Instance.MasterContractID = 0;
                    PlayerPrefs.SetInt("mstrcontractcounter", MasterUserManager.Instance.MasterContractID);
                    MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isItClickable = false; MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isItClickable = false; MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isItClickable = false; MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isItClickable = false;

                    MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isPlantPlanted = false;

                    MasterUserManager.Instance.FirstRowPlants[0].singlePlant.isPlantInContract = false; MasterUserManager.Instance.FirstRowPlants[1].singlePlant.isPlantInContract = false; MasterUserManager.Instance.FirstRowPlants[2].singlePlant.isPlantInContract = false; MasterUserManager.Instance.FirstRowPlants[3].singlePlant.isPlantInContract = false;



                    MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isItClickable = false; MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isItClickable = false; MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isItClickable = false; MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isItClickable = false;

                    MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isPlantPlanted = false;

                    MasterUserManager.Instance.SecondRowPlants[0].singlePlant.isPlantInContract = false; MasterUserManager.Instance.SecondRowPlants[1].singlePlant.isPlantInContract = false; MasterUserManager.Instance.SecondRowPlants[2].singlePlant.isPlantInContract = false; MasterUserManager.Instance.SecondRowPlants[3].singlePlant.isPlantInContract = false;

                    MasterUserManager.Instance.ThirdowPlants[0].singlePlant.isItClickable = false; MasterUserManager.Instance.ThirdowPlants[1].singlePlant.isItClickable = false; MasterUserManager.Instance.ThirdowPlants[2].singlePlant.isItClickable = false; MasterUserManager.Instance.ThirdowPlants[3].singlePlant.isItClickable = false;

                    MasterUserManager.Instance.ThirdowPlants[0].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.ThirdowPlants[1].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.ThirdowPlants[2].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.ThirdowPlants[3].singlePlant.isPlantPlanted = false;

                    MasterUserManager.Instance.ThirdowPlants[0].singlePlant.isPlantInContract = false; MasterUserManager.Instance.ThirdowPlants[1].singlePlant.isPlantInContract = false; MasterUserManager.Instance.ThirdowPlants[2].singlePlant.isPlantInContract = false; MasterUserManager.Instance.ThirdowPlants[3].singlePlant.isPlantInContract = false;

                    MasterUserManager.Instance.FourthRowPlants[0].singlePlant.isItClickable = false; MasterUserManager.Instance.FourthRowPlants[1].singlePlant.isItClickable = false; MasterUserManager.Instance.FourthRowPlants[2].singlePlant.isItClickable = false; MasterUserManager.Instance.FourthRowPlants[3].singlePlant.isItClickable = false;

                    MasterUserManager.Instance.FourthRowPlants[0].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.FourthRowPlants[1].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.FourthRowPlants[2].singlePlant.isPlantPlanted = false; MasterUserManager.Instance.FourthRowPlants[3].singlePlant.isPlantPlanted = false;

                    MasterUserManager.Instance.FourthRowPlants[0].singlePlant.isPlantInContract = false; MasterUserManager.Instance.FourthRowPlants[1].singlePlant.isPlantInContract = false; MasterUserManager.Instance.FourthRowPlants[2].singlePlant.isPlantInContract = false; MasterUserManager.Instance.FourthRowPlants[3].singlePlant.isPlantInContract = false;

      
                }

            }
        });
    }

    [Serializable]
    public class PLANT0
    {
        public int ContractID;
        public int FieldID;
        public bool isDroneAssigned;
        public bool isPlantInContract;
        public bool isPlantPlanted;
        public bool isItClickable;
        public int GrowthDays;
    }

    [Serializable]
    public class PLANT1
    {
        public int ContractID;
        public int FieldID;
        public bool isDroneAssigned;
        public bool isPlantInContract;
        public bool isPlantPlanted;
        public bool isItClickable;
        public int GrowthDays;
    }

    [Serializable]
    public class PLANT2
    {
        public int ContractID;
        public int FieldID;
        public bool isDroneAssigned;
        public bool isPlantInContract;
        public bool isPlantPlanted;
        public bool isItClickable;
        public int GrowthDays;
    }

    [Serializable]
    public class PLANT3
    {
        public int ContractID;
        public int FieldID;
        public bool isDroneAssigned;
        public bool isPlantInContract;
        public bool isPlantPlanted;
        public bool isItClickable;
        public int GrowthDays;
    }

    [Serializable]
    public class PLANTS
    {
        public PLANT0 PLANT0;
        public PLANT1 PLANT1;
        public PLANT2 PLANT2;
        public PLANT3 PLANT3;
        public bool isItClickable;
    }

    [Serializable]
    public class CONTRACT0
    {
        // public string ContractDescription;
        // public int ContractID;
        // public int HowMuchNodesArePlanted;
        public PLANTS PLANTS;
        // public bool isContractStarted;
    }

    [Serializable]
    public class CONTRACT1
    {
        // public string ContractDescription;
        //  public int ContractID;
        // public int HowMuchNodesArePlanted;
        public PLANTS PLANTS;
        //  public bool isContractStarted;
    }

    [Serializable]
    public class CONTRACT2
    {
        // public string ContractDescription;
        // public int ContractID;
        // public int HowMuchNodesArePlanted;
        public PLANTS PLANTS;
        // public bool isContractStarted;
    }

    [Serializable]
    public class CONTRACT3
    {
        // public string ContractDescription;
        //  public int ContractID;
        // public int HowMuchNodesArePlanted;
        public PLANTS PLANTS;
        // public bool isContractStarted;
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
    public class AllContractsAndPlants
    {
        public GAMESPACE GAMESPACE;
    }

    //[Serializable]
    //public class PLANT0 
    //{
    //    public bool isDroneAssigned;
    //    public bool isPlantPlanted;
    //    public bool isPlantInContract;
    //    public int FieldID;
    //    public int ContractID;
    //}

    //[Serializable]
    //public class PLANT1
    //{
    //    public bool isDroneAssigned;
    //    public bool isPlantPlanted;
    //    public bool isPlantInContract;
    //    public int FieldID;
    //    public int ContractID;
    //}

    //[Serializable]
    //public class PLANT2
    //{
    //    public bool isDroneAssigned;
    //    public bool isPlantPlanted;
    //    public bool isPlantInContract;
    //    public int FieldID;
    //    public int ContractID;
    //}

    //[Serializable]
    //public class PLANT3
    //{
    //    public bool isDroneAssigned;
    //    public bool isPlantPlanted;
    //    public bool isPlantInContract;
    //    public int FieldID;
    //    public int ContractID;
    //}

    //[Serializable]
    //public class PLANTS
    //{
    //    public PLANT0 PLANT0;
    //    public PLANT1 PLANT1;
    //    public PLANT2 PLANT2;
    //    public PLANT3 PLANT3;
    //}
    //[Serializable]
    //public class AllPlants
    //{
    //    public PLANTS PLANTS;
    //}

    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";
}

