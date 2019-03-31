using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUser : UI
{

    public User user = null;

    new void Awake()
    {
        base.Awake();

        gameObject.name = "UIUser";

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
        
    }

    public void SetUser(User user)
    {
        this.user = user;
    }

}
