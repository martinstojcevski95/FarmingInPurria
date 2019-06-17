using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUI : MonoBehaviour
{
    public static MasterUI Instance;
    [Header("STANDARD USER UI")]
    public List<Button> STANDARDUSERINGAMEUI;
    public Canvas STANDARDUSERUICANVAS;
    [Header("REGISTRATION AND LOGIN UI")]
    public Canvas FULLLOGINANDREGISTRATIONUI;
    public Canvas REGISTRATIONUI;
    public Canvas LOGINUI;
    [Header("MASTER USER UI")]
    public List<Button> MASTERDUSERINGAMEUI;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



  
}
