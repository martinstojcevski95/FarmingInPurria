using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleField : MonoBehaviour
{
    // Start is called before the first frame update
    //  public bool isDroneAssigned;
    // public bool isPlantAssigned;
    // public bool isFieldInContract;
    // public int FieldID;

    public int GrowthDays;

    public Toggle AssignDroneToggle;
    public SinglePlant singlePlant;
    public Text ContractIDAssignment;

    public int increment;
    public bool canGrow;
    private void Awake()
    {

        //PlayerPrefs.DeleteKey("daytimer");
      //  OneDay = PlayerPrefs.GetFloat("daytimer");
    }


    void Start()
    {
        //  PlayerPrefs.DeleteKey("GrowthDays");
        Debug.Log("GROWTH DAYS AT START " + GrowthDays);


        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }


    private void Update()
    {
        if (canGrow)
        {
            GrowthDays = PlayerPrefs.GetInt("GrowthDays", GrowthDays);
        }



        //if (singlePlant.isItClickable)
        //{
        //    ContractIDAssignment.text = "Tap to plant ";
        //    gameObject.GetComponent<Button>().interactable = true;
        //}

        //else if (singlePlant.isPlantPlanted)
        //{
        //    ContractIDAssignment.text = "Planted for ContractID " + singlePlant.ContractID;
        //}
        //else
        //{
        //    ContractIDAssignment.text = "Tap to plant ";
        //    gameObject.GetComponent<Button>().interactable = false;

        //}
        //if(singlePlant.isPlantPlanted)
        //{
        //    transform.GetComponent<Button>().interactable = false;
        //}


        //if (!singlePlant.isPlantPlanted && !singlePlant.isPlantInContract)
        //{

        //    ContractIDAssignment.text = "Plant is not assigned to contract";

        //}
        //else
        //{
        //    ContractIDAssignment.text = "Planted for ContractID " + singlePlant.ContractID;
        //}


        if (singlePlant.isPlantInContract)
        {
            ContractIDAssignment.text = "Tap to plant the plant";
        }

        if(singlePlant.isPlantPlanted)
        {
            transform.GetComponent<Button>().interactable = false;
            ContractIDAssignment.text = "Planted for ContractID " + singlePlant.ContractID;
        }
        else
        {
            ContractIDAssignment.text = "Assign it to contract";
            transform.GetComponent<Button>().interactable = true;
        }
       
    }

    /// <summary>
    /// assiging drone to the plant so the service can start
    /// </summary>
    public void AssignDroneToServicePlant(Toggle toggle)
    {
       if(toggle.isOn)
        {
            //toggle.GetComponent<DronesManager>().singleDrone.DroneID = singlePlant.FieldID;
            //toggle.GetComponent<DronesManager>().singleDrone.DroneContractIDAssingment=  singlePlant.ContractID;
            //Debug.Log("drone contract id " + toggle.GetComponent<DronesManager>().singleDrone.DroneContractIDAssingment);
            //Debug.Log("drone id " + toggle.GetComponent<DronesManager>().singleDrone.DroneID);
        }
    }

    // vo drone page da assignam drone na kontraktot, posle toj drone preku public method da mu napraam na single plant growth days +1;


    /// <summary>
    /// Clicking on plants to plant. This plants alreayd belong to some of the 4 contracts, or they don't belong to any of them
    /// </summary>
    public void PlantTheNodeAndAssignItToContract(Button Plant)
    {
        if(Plant.GetComponent<SingleField>().singlePlant.isPlantInContract)
        {
            StartCoroutine(SavePlantToDB(Plant));
            Debug.Log("you can plant");
        }
        else
        {
            StartCoroutine(CanNotPlant());
        }
     
    }




    IEnumerator SavePlantToDB(Button plantButton)
    {

        SinglePlant plant = new SinglePlant();
        if(!singlePlant.isItClickable)
        {
            plant.FieldID = singlePlant.FieldID;
            plant.ContractID = singlePlant.ContractID;
            singlePlant.isPlantInContract = true;
            singlePlant.isPlantPlanted = true;
            singlePlant.isItClickable = true;
            plant.isItClickable = singlePlant.isItClickable;
            plant.isPlantPlanted = singlePlant.isPlantPlanted;
            plant.isPlantInContract = singlePlant.isPlantInContract;
            plant.isDroneAssigned = true;
            string ToJson = JsonUtility.ToJson(plant);
            reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + plant.ContractID).Child("PLANTS").Child("PLANT" + plant.FieldID).SetRawJsonValueAsync(ToJson);
            MasterUserManager.Instance.CREATEDPLANTPOPUP.enabled = true;
            MasterUserManager.Instance.CREATEDPLANTPOPUP.transform.GetChild(0).GetComponentInChildren<Text>().text = "Plant with id " + plant.FieldID + " and contract id " + plant.ContractID + " is now created";

            yield return new WaitForSeconds(1f);
            MasterUserManager.Instance.CREATEDPLANTPOPUP.enabled = false;
        }
        else
        {
            MasterUserManager.Instance.CREATEDPLANTPOPUP.enabled = true;
            MasterUserManager.Instance.CREATEDPLANTPOPUP.transform.GetChild(0).GetComponentInChildren<Text>().text = "This plant is not assigned to any contract";

            yield return new WaitForSeconds(1f);
            MasterUserManager.Instance.CREATEDPLANTPOPUP.enabled = false;
        }
       
    }

    IEnumerator CanNotPlant()
    {
        MasterUserManager.Instance.CREATEDPLANTPOPUP.enabled = true;
        MasterUserManager.Instance.CREATEDPLANTPOPUP.transform.GetChild(0).GetComponentInChildren<Text>().text = "This plant is not in any contract";

        yield return new WaitForSeconds(1f);
        MasterUserManager.Instance.CREATEDPLANTPOPUP.enabled = false;
    }

    [Serializable]
    public class SinglePlant
    {
        public bool isDroneAssigned;
        public bool isPlantPlanted;
        public bool isPlantInContract;
        public int FieldID;
        public int ContractID;
        public bool isItClickable;
        public int GrowthDays;
    }

    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";
}
