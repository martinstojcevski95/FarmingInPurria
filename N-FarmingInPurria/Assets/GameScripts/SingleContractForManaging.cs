using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleContractForManaging : MonoBehaviour
{
    public Contract SingleContract;
    public Text contractDescription;
    public Text ActiveContract;
    public Text ContractIDText;
 [HideInInspector]   public bool isContractActiveForClicking;

    // Start is called before the first frame update
    void Start()
    {
      
        
    }


    //TODO --> When clicking on contract in StandardUser, a popup will onen, showing the contract description, and which plants are under that contract
    // this will be made in the future like an upgrade. Right now we have the core functionality to create and delete contracts in the DB

    private void Update()
    {
        if (SingleContract.isContractStarted)
        {
            ActiveContract.text = "ACTIVE CONTRACT";
            ContractIDText.text = "Contract ID " + SingleContract.ContractID.ToString();
            contractDescription.text = SingleContract.ContractDescription;

        }
        else
        {
            ActiveContract.text = "INACTIVE CONTRACT";
            contractDescription.text = "";
            ContractIDText.text = "";
        }
    }

  

    [Serializable]
    public class Contract
    {
        public string ContractDescription;
        public int ContractID;
        public bool isContractStarted;

    }
}
