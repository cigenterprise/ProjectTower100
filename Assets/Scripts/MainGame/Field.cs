using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Field : MonoBehaviour
{
    GameObject fieldObj = null;
    int currentField = 0;

    void Awake()
    {
        gameObject.name = "Field";

        LoadNextFloor();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextFloor()
    {
        if ( fieldObj ) Destroy( fieldObj );
        GameObject prefab = Resources.Load( "Map/PF_Field" + currentField.ToString() ) as GameObject;
        fieldObj = Instantiate( prefab );
        ++currentField;

        if ( Control_MainGame.m_user ) Control_MainGame.m_user.ClearDirObj();
    }

}
