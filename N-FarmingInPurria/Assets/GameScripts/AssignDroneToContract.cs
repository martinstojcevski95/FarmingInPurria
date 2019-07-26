using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignDroneToContract : MonoBehaviour
{

    public Drone singleDrone;
    public Text DroneAssignText;

    private void Start()
    {

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }



    //CHANGE THIS IN THE FUTURE, ASSIGN DRONE WITH UPDATECHILD WHEN ASSIGNING PLANT IN THE NEW GAME FIELD
    public void AssignDroneToWork(int contractid)
    {

        if (contractid == 0)
        {
            singleDrone = new Drone();
            singleDrone.DroneID = 0;
            singleDrone.DroneID = contractid;
            singleDrone.DroneContractIDAssined = 0;
            singleDrone.isDroneAssigned = true;
            singleDrone.isDroneWorking = true;

            string json = JsonUtility.ToJson(singleDrone);
            reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + 0).Child("DRONE" + singleDrone.DroneID).SetRawJsonValueAsync(json);
            DroneAssignText.text = "Drone with id " + singleDrone.DroneID  + "  has beed assign the work on the first row of the plants in contract with id 0";
            Debug.Log("drone added to contract");
        }


        if (contractid == 1)
        {
            singleDrone = new Drone();
            singleDrone.DroneID = 1;
            singleDrone.DroneID = contractid;
            singleDrone.DroneContractIDAssined = 1;
            singleDrone.isDroneAssigned = true;
            singleDrone.isDroneWorking = true;

            string json = JsonUtility.ToJson(singleDrone);
            reference.Child("USERS").Child(LoginAndRegisterManager.Instance.CustomMasterUserID).Child("GAMESPACE").Child("CONTRACT" + 1).Child("DRONE" + singleDrone.DroneID).SetRawJsonValueAsync(json);
            DroneAssignText.text = "Drone with id " + singleDrone.DroneID + "  has beed assign the work on the first row of the plants in contract with id 1";
            Debug.Log("drone added to contract");
        }
    }

    private void Update()
    {
        if(singleDrone.DroneContractIDAssined == 0)
        {

        }
    }


    [Serializable]
    public class Drone
    {
        public int DroneID;
        public int DroneContractIDAssined;
        public bool isDroneAssigned;
        public bool isDroneWorking;
    }



    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";
}