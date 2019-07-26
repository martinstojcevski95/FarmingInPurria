using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MasterUserManager : MonoBehaviour
{
    public static MasterUserManager Instance;
    public Text WhichFieldsAreInContractInfo;

    public List<SingleField> FirstRowPlants = new List<SingleField>();
    public List<SingleField> SecondRowPlants = new List<SingleField>();
    public List<SingleField> ThirdowPlants = new List<SingleField>();
    public List<SingleField> FourthRowPlants = new List<SingleField>();

    public Canvas CREATEDCONTRACTPOPUP;
    public Canvas CREATEDPLANTPOPUP;
    public Text PlantGrowthDaysCounterText;
    [Header("GAMESPACE")]
    public List<Button> FIRSTROWFIELDS = new List<Button>();
    public List<Button> SECONDROWFIELDS = new List<Button>();
    public List<Button> THIRDROWFIELDS = new List<Button>();
    public List<Button> FOURTHROWFIELDS = new List<Button>();
    public List<SingleField> ALLFIELDS = new List<SingleField>();

    [Header("CONTRACT COLOR BUTTONS")]
    public Button RedContract, BlueContract, GreenContract;


    [Header("CONTRACT INPUT FIELDS")]
    public InputField HowManuFields, RemoveContract;

    [Header("CONTRACT REMOVE/CREATE BUTTONS")]
    public Button CreateContractButton, RemoveContractButton;

    [Header("MASTERUSER GROWTH MENU")]
    public Text WaitAfterIncreasingTheGrowthText;

    public AllWeatherStats allWeatherStats;

    public Button AddGrowthButtonFromMasterUser;
    string currentUTCTime;

    int incrementerForPlantID;

    int GrowthDaysHolder;
    int increaseGrowthDays;

    int OneDayCounter;
    int passedDaysSinceDroneStartedWorkng;


    public float OneDay;

    bool StartDailyTimer;
    public int startDailyTimer;

    public bool forTest;
    private void Awake()
    {
        Instance = this;
        var utcnow = DateTime.UtcNow;
        string currentUTCTime = utcnow.ToShortTimeString();
        PlayerPrefs.SetString("currTime", currentUTCTime);
        PlayerPrefs.DeleteKey("oneDay");
        GrowthDaysHolder = PlayerPrefs.GetInt("growthdays");
        Debug.Log(GrowthDaysHolder);
        OneDay = PlayerPrefs.GetFloat("oneDay");
        startDailyTimer = 0;
    }




    // Start is called before the first frame update
    void Start()
    {



        currentUTCTime = PlayerPrefs.GetString("currTime");
        // od koga ke postavam dron da zacuvam koga sum postavil vremenski i data
        // vo update da proveruvam na sekoj saat ili nonstop dali od vremeto koga sum postavil do momentalnoto dali ima pominato 24 casa
        // ako ima pominato pravam + 1 growth i go resetiram vremeto na momentalnoto vreme i pak proveruvam isto 

        DateTime date = Convert.ToDateTime(currentUTCTime);

        Debug.Log(date.ToShortTimeString());


        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        //PlayerPrefs.DeleteKey("mstrcontractcounter");
        //PlayerPrefs.DeleteKey("ACTIVECONTRACTS");
        //PlayerPrefs.DeleteKey("FR");
        // PlayerPrefs.DeleteKey("SR");

        MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterContractID);
        Debug.Log("mastercotract ID AT START  " + MasterContractID);
        //  MasterActiveContracts = PlayerPrefs.GetInt("ACTIVECONTRACTS", MasterActiveContracts); 

        FIRSTROW = PlayerPrefs.GetInt("FR");
        SECONDROW = PlayerPrefs.GetInt("SR");

    }



    public void GetWeatherEveryDay()
    {
        StartCoroutine(GetRequest("https://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=511efb82bba4378564f71de9d47f6fae"));
    }

    IEnumerator PlantGrowth()
    {
        ManageFieldsManager.Instance.RetreiveDataForFieldPlants();
        yield return new WaitForSeconds(3f);
        OneDay = PlayerPrefs.GetFloat("oneDay");

        // some logic for loading, first load the weather than get the data and increment the growth based on the data


        // first check if there is data to update if not, wait for data


        if (ManageFieldsManager.Instance.isThereAnyData)
        {
            if (ManageFieldsManager.Instance.allContractsAndPlants != null)
            {
                startDailyTimer = 1;
                PlayerPrefs.SetInt("dailytimer", 1);
                //   StartDailyTimer = true;
                AddGrowthButtonFromMasterUser.interactable = false;
                GetWeatherEveryDay();

                for (int i = 0; i < FirstRowPlants.Count; i++)
                {

                    if (FirstRowPlants[i].singlePlant.isDroneAssigned)
                    {
                        int growthDayIncrementer = FirstRowPlants[0].singlePlant.GrowthDays;

                        Dictionary<string, object> lParameters = new Dictionary<string, object>();

                        Plant plant = new Plant();

                        lParameters.Add("GrowthDays", plant.GrowthDays = growthDayIncrementer += 1);
                        //    PlayerPrefs.SetInt("frPlants", plant.GrowthDays);
                        reference.Child("USERS").Child("PURRIAT13d1NlamrYPFHFKouRPtruKUjh1").Child("GAMESPACE").Child("CONTRACT" + 0).Child("PLANTS").Child("PLANT" + i).UpdateChildrenAsync(lParameters);
                    }

                    if (SecondRowPlants[i].singlePlant.isDroneAssigned)
                    {
                        int growthDayIncrementer = SecondRowPlants[0].singlePlant.GrowthDays;
                        Dictionary<string, object> lParameters = new Dictionary<string, object>();

                        Plant plant = new Plant();
                        lParameters.Add("GrowthDays", plant.GrowthDays = growthDayIncrementer += 1);

                        reference.Child("USERS").Child("PURRIAT13d1NlamrYPFHFKouRPtruKUjh1").Child("GAMESPACE").Child("CONTRACT" + 1).Child("PLANTS").Child("PLANT" + i).UpdateChildrenAsync(lParameters);
                    }
                    if (ThirdowPlants[i].singlePlant.isDroneAssigned)
                    {
                        int growthDayIncrementer = ThirdowPlants[0].singlePlant.GrowthDays;
                        Dictionary<string, object> lParameters = new Dictionary<string, object>();

                        Plant plant = new Plant();
                        lParameters.Add("GrowthDays", plant.GrowthDays = growthDayIncrementer += 1);

                        reference.Child("USERS").Child("PURRIAT13d1NlamrYPFHFKouRPtruKUjh1").Child("GAMESPACE").Child("CONTRACT" + 1).Child("PLANTS").Child("PLANT" + i).UpdateChildrenAsync(lParameters);
                    }
                    if (FourthRowPlants[i].singlePlant.isDroneAssigned)
                    {
                        int growthDayIncrementer = FourthRowPlants[0].singlePlant.GrowthDays;
                        Dictionary<string, object> lParameters = new Dictionary<string, object>();

                        Plant plant = new Plant();
                        lParameters.Add("GrowthDays", plant.GrowthDays = growthDayIncrementer += 1);

                        reference.Child("USERS").Child("PURRIAT13d1NlamrYPFHFKouRPtruKUjh1").Child("GAMESPACE").Child("CONTRACT" + 1).Child("PLANTS").Child("PLANT" + i).UpdateChildrenAsync(lParameters);
                    }
                }
            }

            ManageFieldsManager.Instance.RetreiveDataForFieldPlants();
        }
        else
        {
            WaitAfterIncreasingTheGrowthText.text = "There aren't any active contracts";
        }
    }

    public void AddPlantGrowth()
    {
        StartCoroutine(PlantGrowth());
        //for (int i = 0; i < ALLFIELDS.Count; i++)
        //{
        //    if (ALLFIELDS[i].singlePlant.isDroneAssigned)
        //    {

        //        ALLFIELDS[i].GrowthDays = GrowthDaysHolder;
        //        PlayerPrefs.SetInt("GrowthDays", ALLFIELDS[i].GrowthDays);
        //        PlantGrowthDaysCounterText.text = "The plants that are in contract with id " + ALLFIELDS[i].singlePlant.ContractID + " has their daily growth value at " + ALLFIELDS[i].GrowthDays;
        //        PlayerPrefs.SetInt("growthdays", GrowthDaysHolder);
        //    }
        //}
        //Debug.Log("adding GROWTH ");

    }
    public void DeleteContract(InputField ContractID)
    {
        MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterContractID);
        int id = int.Parse(ContractID.text);

        FirebaseDatabase.DefaultInstance
   .GetReference("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + id)
   .GetValueAsync().ContinueWith(task =>
   {
       if (task.IsFaulted)
       {
           // Handle the error...
       }
       else if (task.IsCompleted)
       {
           DataSnapshot snapshot = task.Result;
           string ContractSnapShot = snapshot.GetRawJsonValue();
           ContractProperties contractProperties = new ContractProperties();
           contractProperties = JsonUtility.FromJson<ContractProperties>(ContractSnapShot);
           if (contractProperties != null)
           {

               if (id == 0)
               {
                   Debug.Log("CONTRACT ID " + contractProperties.ContractID);
                   //reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + contractProperties.ContractID).RemoveValueAsync();
                   reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + id).RemoveValueAsync();

                   MasterContractID = 0;
                   PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
               }
               if (id == 1)
               {
                   Debug.Log("CONTRACT ID " + contractProperties.ContractID);
                   //reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + contractProperties.ContractID).RemoveValueAsync();
                   reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + id).RemoveValueAsync();

                   MasterContractID = 1;
                   PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
               }
               if (id == 2)
               {
                   Debug.Log("CONTRACT ID " + contractProperties.ContractID);
                   //reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + contractProperties.ContractID).RemoveValueAsync();
                   reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + id).RemoveValueAsync();

                   MasterContractID = 2;
                   PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
               }
               if (id == 3)
               {
                   Debug.Log("CONTRACT ID " + contractProperties.ContractID);
                   //reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + contractProperties.ContractID).RemoveValueAsync();
                   reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + id).RemoveValueAsync();

                   MasterContractID = 3;
                   PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
               }


           }
           //else 
           //{
           //    MasterContractID = 0;
           //    PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
           //    Debug.Log("no more contracts");
           //}
           ManageContract.Instance.RetreiveDataForSelectedConract();

       }

   });

    }


    public void GetMasterContractIDCounter()
    {
        MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterContractID);
        Debug.Log("MSTRCounterID " + MasterContractID);
    }

    public void DemoContract(InputField ContractID)
    {
        int InsredtedContractIDInTextField = int.Parse(ContractID.text);
        //MasterContractID = 2;
        //Debug.Log("mastercontract id " + MasterContractID);
        if (MasterContractID < 4)
        {
            //GetDataBeforeCreatingContract(InsredtedContractIDInTextField, MasterContractID);
            MasterContractID += 1;
            Debug.Log("VNESENO ID ZA KREIRANJE  " + InsredtedContractIDInTextField + " mastercontract id e " + MasterContractID);
            PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
        }



    }



    /// <summary>
    /// Creating the contract. Max contracts 4. each onctract has his own id
    /// </summary>
    /// <param name="ContractDescription"></param>
    public void GetDataBeforeCreatingContract(InputField ContractDescription)
    {
        //int howmuchnodes = int.Parse(HowMuchNodes.text);
        MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterContractID);



        if (MasterContractID < 4)
        {
            if (MasterContractID == 0)
            {
                ContractProperties contractProperties = new ContractProperties();
                contractProperties.ContractDescription = ContractDescription.text;
                contractProperties.ContractID = 0;
                contractProperties.isContractStarted = true;
                string ToJson = JsonUtility.ToJson(contractProperties);
                reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + MasterContractID).SetRawJsonValueAsync(ToJson);
                MasterContractID = 1;
                PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);



                for (int i = 0; i < FirstRowPlants.Count; i++) // say here that they are only for the first row, first contrat for the first row
                {

                    FirstRowPlants[i].singlePlant.ContractID = 0;
                    FirstRowPlants[i].singlePlant.isPlantInContract = true;
                    FirstRowPlants[i].singlePlant.FieldID = i;
                }

                ContractIsCreatedPopUp("First Row");
            }

            else if (MasterContractID == 1)
            {
                ContractProperties contractProperties = new ContractProperties();
                contractProperties.ContractDescription = ContractDescription.text;
                contractProperties.ContractID = 1;
                contractProperties.isContractStarted = true;

                string ToJson = JsonUtility.ToJson(contractProperties);
                reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + MasterContractID).SetRawJsonValueAsync(ToJson);
                MasterContractID = 2;
                PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
                for (int i = 0; i < SecondRowPlants.Count; i++)
                {
                    SecondRowPlants[i].singlePlant.ContractID = 1;
                    SecondRowPlants[i].singlePlant.isPlantInContract = true;
                    SecondRowPlants[i].singlePlant.FieldID = i;
                }
                ContractIsCreatedPopUp("Second Row");
            }

            else if (MasterContractID == 2)
            {
                ContractProperties contractProperties = new ContractProperties();
                contractProperties.ContractDescription = ContractDescription.text;
                contractProperties.ContractID = 2;
                contractProperties.isContractStarted = true;

                string ToJson = JsonUtility.ToJson(contractProperties);
                reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + MasterContractID).SetRawJsonValueAsync(ToJson);
                MasterContractID = 3;
                PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
                for (int i = 0; i < ThirdowPlants.Count; i++)
                {
                    ThirdowPlants[i].singlePlant.ContractID = 2;
                    ThirdowPlants[i].singlePlant.isPlantInContract = true;
                    ThirdowPlants[i].singlePlant.FieldID = i;
                }
                ContractIsCreatedPopUp("Third Row");
            }
            else if (MasterContractID == 3)
            {
                ContractProperties contractProperties = new ContractProperties();
                contractProperties.ContractDescription = ContractDescription.text;
                contractProperties.ContractID = 3;
                contractProperties.isContractStarted = true;

                string ToJson = JsonUtility.ToJson(contractProperties);
                reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + MasterContractID).SetRawJsonValueAsync(ToJson);
                MasterContractID = 0;//3;
                PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
                for (int i = 0; i < FourthRowPlants.Count; i++)
                {
                    FourthRowPlants[i].singlePlant.ContractID = 3;
                    FourthRowPlants[i].singlePlant.isPlantInContract = true;
                    FourthRowPlants[i].singlePlant.FieldID = i;
                }

                ContractIsCreatedPopUp("Fourth Row");
            }

        }

        //else
        //{
        //    MasterContractID = 0;
        //    PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
        //}
    }


    public void ContractIsCreatedPopUp(string PlantRowNumber)
    {
        CREATEDCONTRACTPOPUP.enabled = true;
        CREATEDCONTRACTPOPUP.transform.GetChild(1).GetComponentInChildren<Text>().text = "Contract is now created for the " + PlantRowNumber + " row plants. To finish the contract creation go to the Standard User, and click on the New Game Button. After that there you will have to plant the 4 plants for that contract";
    }


    public void CreateTheContract(InputField HowMuchNodes)
    {
        MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterContractID);
        int howMuchNodes = int.Parse(HowMuchNodes.text);

        if (MasterContractID < 4)
        {

            //new object properties
            ContractProperties contractProperties = new ContractProperties();
            contractProperties.ContractDescription = "this is just a demo description";
            contractProperties.ContractID = MasterContractID;//randomNewContractID;
            contractProperties.isContractStarted = true;
            string ToJson = JsonUtility.ToJson(contractProperties);
            MasterContractID += 1;
            PlayerPrefs.SetInt("mstrcontractcounter", MasterContractID);
            reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + MasterContractID).SetRawJsonValueAsync(ToJson);
        }
        else
        {
            Debug.Log("can not create more than 4 contracts");
        }

    }

    [Serializable]
    public class Plant
    {
        public bool isDroneAssigned;
        public bool isPlantPlanted;
        public bool isPlantInContract;
        public int FieldID;
        public int ContractID;
        public int GrowthDays;
    }


    [Serializable]
    public class ContractProperties
    {
        public string ContractDescription;
        public int ContractID;
        public bool isContractStarted;
        public bool isDroneAssigned;
    }


    void RetreiveContractData()
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
             Debug.Log("CREATED CONTRACTS " + snapshot.GetRawJsonValue());
             // Do something with snapshot...
         }

     });
    }

    //void DailyTimer()
    //{
    //    for (int i = 0; i < ALLFIELDS.Count; i++)
    //    {
    //        if (ALLFIELDS[i].singlePlant.isDroneAssigned)
    //        {

    //            OneDay += Time.deltaTime;
    //            if (OneDay >= 20)
    //            {

    //                increment += 1;
    //                ALLFIELDS[i].GrowthDays += 1;
    //                Debug.Log("one day has passed increment the growth  +  " + ALLFIELDS[i].GrowthDays);
    //                PlayerPrefs.SetInt("growthdays", GrowthDaysHolder);
    //                OneDay = 0;



    //            }


    //        }
    //    }


    //}


    // Update is called once per frame


    public void DailyGrowthButton()
    {

    }

    void Update()
    {
        //   if (StartDailyTimer)
        if (startDailyTimer == 1)
        {
            AddGrowthButtonFromMasterUser.interactable = false;
            OneDay += Time.deltaTime;

            if (OneDay >= 86400)
            {
                startDailyTimer = 0;
                PlayerPrefs.SetInt("dailytimer", 0);
                // StartDailyTimer = false;
                WaitAfterIncreasingTheGrowthText.text = "";
                AddGrowthButtonFromMasterUser.interactable = true;
                AddPlantGrowth();
                OneDay = 0;
                PlayerPrefs.SetFloat("oneDay", OneDay);
            }
            else
            {
                WaitAfterIncreasingTheGrowthText.text = "The growth was increased, you need to wait for the drone to work on the plants for another 24 hours so you can increase the growth again";
            }
        }


    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("oneDay", OneDay);
    }



    public void SetColorToTheContract(Button color)
    {
        if (color.tag == "Red")
        {
            Red = true;
            Green = false;
            Blue = false;
        }
        else if (color.tag == "Blue")
        {
            Blue = true;
            Green = false;
            Red = false;
        }
        else if (color.tag == "Green")
        {
            Green = true;
            Blue = false;
            Red = false;
        }
    }



    void GenerateContracts()
    {
        int randomNewContractID = UnityEngine.Random.Range(0, 123456789);
        if (MasterContractID <= 3)
        {
            MasterContractID += 1;
            MasterActiveContracts += MasterContractID;
            PlayerPrefs.SetInt("ACTIVECONTRACTS", MasterActiveContracts);
            PlayerPrefs.SetInt("MASTERCONTRACTS", MasterContractID);
            reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACTID" + MasterContractID).SetRawJsonValueAsync(randomNewContractID.ToString());
            Debug.Log("mastercontract id " + MasterContractID);
        }
        else
        {
            StartCoroutine(MaxContractsWarning());
        }
    }


    //public void CreateContract()
    //{

    //    string fields = HowManuFields.text;
    //    int fieldsInt = int.Parse(fields);



    //    if (fieldsInt.Equals(1))
    //    {
    //        for (int i = 0; i < FIRSTROWFIELDS.Count; i++)
    //        {
    //            if (FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
    //            {
    //                FIRSTROW = 1;
    //                PlayerPrefs.SetInt("FR", FIRSTROW);
    //                GenerateContracts();
    //            }
    //            else
    //            {
    //                StartCoroutine(MaxContractsWarning());
    //            }

    //            CreateContractWithFirstRowFields();
    //            StandardUserManager.Instance.ActivateContractForManaging(1, "Contract started for the first row of tulips");
    //            WhichFieldsAreInContractInfo.text = "";

    //        }



    //    }
    //    else if (fieldsInt.Equals(2))
    //    {
    //        for (int i = 0; i < SECONDROWFIELDS.Count; i++)
    //        {
    //            if (SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
    //            {
    //                SECONDROW = 1;
    //                PlayerPrefs.SetInt("SR", SECONDROW);
    //                GenerateContracts();
    //            }
    //            else
    //            {

    //                StartCoroutine(MaxContractsWarning());
    //            }
    //            CreateContractWithSecondRowFields();
    //            StandardUserManager.Instance.ActivateContractForManaging(2, "Contract started for the second row of tulips");
    //            //    reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACTID" + //MasterContractID).Child("").SetRawJsonValueAsync();
    //            WhichFieldsAreInContractInfo.text = "";
    //        }

    //    }
    //    else if (fieldsInt.Equals(3))
    //    {

    //        CreateContractWithThirdRowFields();
    //        WhichFieldsAreInContractInfo.text = "";


    //    }
    //    else if (fieldsInt.Equals(4))
    //    {
    //        CreateContractWithFourthRowFields();
    //        WhichFieldsAreInContractInfo.text = "";

    //    }
    //    else if (fieldsInt > 4)
    //    {
    //        StartCoroutine(MaxFieldsSizeWarning());
    //    }
    //}


    IEnumerator MaxFieldsSizeWarning()
    {
        WhichFieldsAreInContractInfo.text = "There are only 4 rows of fields, please choose between them";
        yield return new WaitForSeconds(1.5f);
        WhichFieldsAreInContractInfo.text = "";
    }

    IEnumerator MaxContractsWarning()
    {
        WhichFieldsAreInContractInfo.text = "You can not create more contracts. 4 contracts is the limit";
        yield return new WaitForSeconds(1.5f);
        WhichFieldsAreInContractInfo.text = "";

    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            string json = uwr.downloadHandler.text;
            allWeatherStats = JsonUtility.FromJson<AllWeatherStats>(json);
        }
    }
    //void CreateContractWithFirstRowFields()
    //{
    //    for (int i = 0; i < FIRSTROWFIELDS.Count; i++)
    //    {
    //        if (FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
    //        {
    //            FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
    //            if (Red)
    //            {
    //                FIRSTROWFIELDS[i].GetComponent<Image>().color = RedColor;
    //            }
    //            else if (Blue)
    //            {
    //                FIRSTROWFIELDS[i].GetComponent<Image>().color = BlueColor;

    //            }
    //            else if (Green)
    //            {
    //                FIRSTROWFIELDS[i].GetComponent<Image>().color = GreenColor;

    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("you have already created this contract");
    //        }

    //    }
    //}


    //void CreateContractWithSecondRowFields()
    //{
    //    for (int i = 0; i < SECONDROWFIELDS.Count; i++)
    //    {
    //        if (SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
    //        {
    //            SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
    //            if (Red)
    //            {
    //                SECONDROWFIELDS[i].GetComponent<Image>().color = RedColor;
    //            }
    //            else if (Blue)
    //            {
    //                SECONDROWFIELDS[i].GetComponent<Image>().color = BlueColor;

    //            }
    //            else if (Green)
    //            {
    //                SECONDROWFIELDS[i].GetComponent<Image>().color = GreenColor;

    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("you have already created this contract");
    //        }

    //    }
    //}


    //void CreateContractWithThirdRowFields()
    //{
    //    for (int i = 0; i < THIRDROWFIELDS.Count; i++)
    //    {
    //        THIRDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
    //        if (Red)
    //        {
    //            THIRDROWFIELDS[i].GetComponent<Image>().color = RedColor;
    //        }
    //        else if (Blue)
    //        {
    //            THIRDROWFIELDS[i].GetComponent<Image>().color = BlueColor;

    //        }
    //        else if (Green)
    //        {
    //            THIRDROWFIELDS[i].GetComponent<Image>().color = GreenColor;

    //        }
    //    }
    //}


    //void CreateContractWithFourthRowFields()
    //{
    //    for (int i = 0; i < FOURTHROWFIELDS.Count; i++)
    //    {
    //        FOURTHROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
    //        if (Red)
    //        {
    //            FOURTHROWFIELDS[i].GetComponent<Image>().color = RedColor;
    //        }
    //        else if (Blue)
    //        {
    //            FOURTHROWFIELDS[i].GetComponent<Image>().color = BlueColor;

    //        }
    //        else if (Green)
    //        {
    //            FOURTHROWFIELDS[i].GetComponent<Image>().color = GreenColor;

    //        }
    //    }
    //}

    bool Red, Green, Blue;
    public Color RedColor, GreenColor, BlueColor;


    int MasterGameSpaceID;
    public int MasterContractID;
    int MasterActiveContracts;
    bool canCreateContract;
    int CANCREATECONTRACT; //0 false  1 true
    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";


    int FIRSTROW, SECONDROW, THIRDROW, FOURTHROW;




    //Weather classes 

    [Serializable]
    public class Coord
    {
        public double lon;
        public double lat;
    }
    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }
    [Serializable]
    public class Main
    {
        public double temp;
        public int pressure;
        public int humidity;
        public double temp_min;
        public double temp_max;
    }
    [Serializable]
    public class Wind
    {
        public double speed;
        public int deg;
    }
    [Serializable]
    public class Rain
    {
        public double __invalid_name__1h;
    }
    [Serializable]
    public class Clouds
    {
        public int all;
    }
    [Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public double message;
        public string country;
        public int sunrise;
        public int sunset;
    }
    [Serializable]
    public class AllWeatherStats
    {
        public Coord coord;
        public List<Weather> weather;
        public string @base;
        public Main main;
        public int visibility;
        public Wind wind;
        public Rain rain;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int timezone;
        public int id;
        public string name;
        public int cod;
    }

}
