using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUserManager : MonoBehaviour
{

    public Text WhichFieldsAreInContractInfo;

    [Header("GAMESPACE")]
    public List<Button> FIRSTROWFIELDS = new List<Button>();
    public List<Button> SECONDROWFIELDS = new List<Button>();
    public List<Button> THIRDROWFIELDS = new List<Button>();
    public List<Button> FOURTHROWFIELDS = new List<Button>();
    public List<Button> ALLFIELDS = new List<Button>();

    [Header("CONTRACT COLOR BUTTONS")]
    public Button RedContract, BlueContract, GreenContract;


    [Header("CONTRACT INPUT FIELDS")]
    public InputField HowManuFields, RemoveContract;

    [Header("CONTRACT REMOVE/CREATE BUTTONS")]
    public Button CreateContractButton, RemoveContractButton;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASEURL);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
     //   PlayerPrefs.DeleteKey("MASTERCONTRACTS");
       //PlayerPrefs.DeleteKey("ACTIVECONTRACTS");
        //PlayerPrefs.DeleteKey("FR");
       // PlayerPrefs.DeleteKey("SR");

        MasterContractID = PlayerPrefs.GetInt("MASTERCONTRACTS", MasterContractID); // MAX 4 MASTERCONTRACTIDS, THISIS DONE SO THE FIREBASE CAN STACK MORE CONTRACT NOT JUST ONE
        Debug.Log("mastercotract ID AT START  " + MasterContractID);
        MasterActiveContracts = PlayerPrefs.GetInt("ACTIVECONTRACTS", MasterActiveContracts); // MASTERACTIVECONTRACTS, THIS IS VARIABLE FOR LATER CHACKING HOW MANY CONTRACTS ARE ACTIVE

        FIRSTROW = PlayerPrefs.GetInt("FR");
        SECONDROW = PlayerPrefs.GetInt("SR");

    }


    // Update is called once per frame
    void Update()
    {
        if (FIRSTROW == 1)
        {
            for (int i = 0; i < FIRSTROWFIELDS.Count; i++)
            {
                FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
            }
        }
        if(SECONDROW == 1)
        {
            for (int i = 0; i < SECONDROWFIELDS.Count; i++)
            {
                SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
            }
        }

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


    public void CreateContract()
    {

        string fields = HowManuFields.text;
        int fieldsInt = int.Parse(fields);



        if (fieldsInt.Equals(1))
        {
            for (int i = 0; i < FIRSTROWFIELDS.Count; i++)
            {
                if (FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
                {
                    FIRSTROW = 1;
                    PlayerPrefs.SetInt("FR", FIRSTROW);
                    GenerateContracts();
                }
                else
                {
                    StartCoroutine(MaxContractsWarning());
                }

                CreateContractWithFirstRowFields();
                WhichFieldsAreInContractInfo.text = "";
            }

           

        }
        else if (fieldsInt.Equals(2))
        {
            for (int i = 0; i < SECONDROWFIELDS.Count; i++)
            {
                if (SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
                {
                    SECONDROW = 1;
                    PlayerPrefs.SetInt("SR", SECONDROW);
                    GenerateContracts();
                }
                else
                {

                    StartCoroutine(MaxContractsWarning());
                }
                CreateContractWithSecondRowFields();
                WhichFieldsAreInContractInfo.text = "";
            }
    
        }
        else if (fieldsInt.Equals(3))
        {

            CreateContractWithThirdRowFields();
            WhichFieldsAreInContractInfo.text = "";


        }
        else if (fieldsInt.Equals(4))
        {
            CreateContractWithFourthRowFields();
            WhichFieldsAreInContractInfo.text = "";

        }
        else if (fieldsInt > 4)
        {
            StartCoroutine(MaxFieldsSizeWarning());
        }
    }


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


    void CreateContractWithFirstRowFields()
    {
        for (int i = 0; i < FIRSTROWFIELDS.Count; i++)
        {
            if (FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
            {
                FIRSTROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
                if (Red)
                {
                    FIRSTROWFIELDS[i].GetComponent<Image>().color = RedColor;
                }
                else if (Blue)
                {
                    FIRSTROWFIELDS[i].GetComponent<Image>().color = BlueColor;

                }
                else if (Green)
                {
                    FIRSTROWFIELDS[i].GetComponent<Image>().color = GreenColor;

                }
            }
            else
            {
               Debug.Log("you have already created this contract");
            }

        }
    }


    void CreateContractWithSecondRowFields()
    {
        for (int i = 0; i < SECONDROWFIELDS.Count; i++)
        {
            if (SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract == false)
            {
                SECONDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
                if (Red)
                {
                    SECONDROWFIELDS[i].GetComponent<Image>().color = RedColor;
                }
                else if (Blue)
                {
                    SECONDROWFIELDS[i].GetComponent<Image>().color = BlueColor;

                }
                else if (Green)
                {
                    SECONDROWFIELDS[i].GetComponent<Image>().color = GreenColor;

                }
            }
            else
            {
                Debug.Log("you have already created this contract");
            }
   
        }
    }


    void CreateContractWithThirdRowFields()
    {
        for (int i = 0; i < THIRDROWFIELDS.Count; i++)
        {
            THIRDROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
            if (Red)
            {
                THIRDROWFIELDS[i].GetComponent<Image>().color = RedColor;
            }
            else if (Blue)
            {
                THIRDROWFIELDS[i].GetComponent<Image>().color = BlueColor;

            }
            else if (Green)
            {
                THIRDROWFIELDS[i].GetComponent<Image>().color = GreenColor;

            }
        }
    }


    void CreateContractWithFourthRowFields()
    {
        for (int i = 0; i < FOURTHROWFIELDS.Count; i++)
        {
            FOURTHROWFIELDS[i].GetComponent<SingleField>().isFieldInContract = true;
            if (Red)
            {
                FOURTHROWFIELDS[i].GetComponent<Image>().color = RedColor;
            }
            else if (Blue)
            {
                FOURTHROWFIELDS[i].GetComponent<Image>().color = BlueColor;

            }
            else if (Green)
            {
                FOURTHROWFIELDS[i].GetComponent<Image>().color = GreenColor;

            }
        }
    }

    bool Red, Green, Blue;
    public Color RedColor, GreenColor, BlueColor;


    int MasterGameSpaceID;
    int MasterContractID;
    int MasterActiveContracts;
    bool canCreateContract;
    int CANCREATECONTRACT; //0 false  1 true
    DatabaseReference reference;
    string DATABASEURL = "https://mydatabase-236d4.firebaseio.com/";


    int FIRSTROW, SECONDROW, THIRDROW, FOURTHROW;
}
