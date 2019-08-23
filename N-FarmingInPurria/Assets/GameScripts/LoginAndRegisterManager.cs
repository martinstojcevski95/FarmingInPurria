using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginAndRegisterManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool isLoggedIn;
    public string USERID;
    public InputField RegistrationEmail, RegistrationPassword, LogInEmail, LogInPassword;
    FirebaseAuth auth;

    public string CustomMasterUserID;
    public static LoginAndRegisterManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        DissableAllButtonsAtStart();
    }

    // Update is called once per frame
    void Update()
    {

    }



    //TODO --> SAVE USERNAME AND SURNAME IN DB 

    void DissableAllButtonsAtStart()
    {

        foreach (var item in MasterUI.Instance.STANDARDUSERINGAMEUI)
        {
            item.interactable = false;
        }
    }

    void EnableAllButtonsOnLogIn()
    {
        MasterUI.Instance.REGISTRATIONUI.enabled = false;
        MasterUI.Instance.LOGINUI.enabled = false;
        MasterUI.Instance.FULLLOGINANDREGISTRATIONUI.enabled = false;
        MasterUI.Instance.STANDARDUSERUICANVAS.enabled = true;
        foreach (var item in MasterUI.Instance.STANDARDUSERINGAMEUI)
        {
            item.interactable = true;
        }

    }

    public void Registration()
    {
        auth.CreateUserWithEmailAndPasswordAsync(RegistrationEmail.text, RegistrationPassword.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;


            MasterUserManager.Instance.MasterContractID = 0;
            MasterUserManager.Instance.MasterContractID = PlayerPrefs.GetInt("mstrcontractcounter", MasterUserManager.Instance.MasterContractID);
            Debug.Log("resetting masterContractID on new user");
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }


    public void LogIn(GameObject Loader)
    {
        Loader.SetActive(true);
        StartCoroutine(GetAllDataAfterLogIn(Loader));
    }


    IEnumerator GetAllDataAfterLogIn(GameObject Loader)
    {
        ManageFieldsManager.Instance.RetreiveDataForFieldPlants();
        yield return new WaitForSeconds(2f);
        if (ManageFieldsManager.Instance.isThereAnyData)
        {

                auth.SignInWithEmailAndPasswordAsync(LogInEmail.text, LogInPassword.text).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    isLoggedIn = true;
                    USERID = newUser.UserId;
                    AddPrefixToEachUser(newUser.UserId);
                    Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
                    ManageFieldsManager.Instance.RetreiveDataForFieldPlants();
                    //MasterUserManager.Instance.startDailyTimer = PlayerPrefs.GetInt("dailytimer");
                    // LOADER HERE TO GET DATA FIRST TO CHECK WHAT IS GOING ON WITH THE PLANTS AND CONTRACRS!!!


                    MasterUserManager.Instance.startDailyTimer = 1;
                });

                StartCoroutine(AfterLogIn(isLoggedIn));
                Debug.Log("there is data");
                Loader.SetActive(false);
    
        }
        else
        {
         
            {
                Debug.Log("no data");
                auth.SignInWithEmailAndPasswordAsync(LogInEmail.text, LogInPassword.text).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    isLoggedIn = true;
                    USERID = newUser.UserId;
                    AddPrefixToEachUser(newUser.UserId);
                    Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
                    ManageFieldsManager.Instance.RetreiveDataForFieldPlants();
                    //MasterUserManager.Instance.startDailyTimer = PlayerPrefs.GetInt("dailytimer");
                    // LOADER HERE TO GET DATA FIRST TO CHECK WHAT IS GOING ON WITH THE PLANTS AND CONTRACRS!!!


                    MasterUserManager.Instance.startDailyTimer = 0;
                });

                StartCoroutine(AfterLogIn(isLoggedIn));
                Loader.SetActive(false);
            }
    
    }

}


    void AddPrefixToEachUser(string userid)
    {
        CustomMasterUserID = "PURRIA" + userid; 
    }

    IEnumerator AfterLogIn(bool isTrue)
    {
        yield return new WaitUntil(() => isLoggedIn);
        EnableAllButtonsOnLogIn();
    }
}


