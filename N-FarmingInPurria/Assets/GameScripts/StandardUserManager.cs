using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardUserManager : MonoBehaviour
{

    public List<Button> ManageContractsButtons = new List<Button>();


    public static StandardUserManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateContractForManaging(int ContractID, string ContractRowDescription)
    {
        //for (int i = 0; i < ManageContractsButtons.Count; i++)
        //{

        //    if (ManageContractsButtons[ContractID].GetComponent<ManageContract>().isContractActive == 1)
        //    {
        //        Debug.Log("contract is now active");
        //        ManageContractsButtons[ContractID - 1].GetComponentInChildren<Text>().text = ContractRowDescription;
        //        ManageContractsButtons[ContractID - 1].GetComponent<ManageContract>().ContractDescription = ContractRowDescription;
        //        ManageContractsButtons[ContractID - 1].GetComponent<ManageContract>().isContractActive = 1;

        //    }
        //}

      //  ManageContractsButtons[ContractID - 1].GetComponent<ManageContract>().ContractID = 1000;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
