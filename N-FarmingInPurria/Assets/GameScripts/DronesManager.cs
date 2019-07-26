using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DronesManager : MonoBehaviour
{

    public static DronesManager Instance;
    public Drone singleDrone;
    public List<Drone> drones = new List<Drone>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

 

    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";
}
