using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleField : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDroneAssigned;
    public bool isPlantAssigned;
    public bool isFieldInContract;
    public int FieldID;
    public Toggle AssignDroneToggle;


    void Start()
    {

        GetComponentInChildren<Text>().text = FieldID.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
