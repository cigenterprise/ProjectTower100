using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICook : UI
{
    new void Awake()
    {
        base.Awake();

        gameObject.name = "UICook";

        MakeComponents();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void MakeComponents()
    {
        GameObject bgObj = new GameObject();
        bgObj.transform.SetParent( transform );

        bgObj.AddComponent<RawImage>();
    }
}
