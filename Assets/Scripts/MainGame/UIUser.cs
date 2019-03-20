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
        GameObject hpObj = new GameObject();
        hpObj.transform.SetParent(transform);
        hpObj.name = "Background";
        hpObj.transform.localPosition = //new Vector2(10, 0);
        SceneControl_MainGame._mainCamera.WorldToScreenPoint(new Vector3(10, 0, 0));
        RawImage dialogImg = hpObj.AddComponent<RawImage>();
        //CustomAnchor(dialogImg.rectTransform, CUSTOM_ANCHOR.BOTTOM);
        dialogImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
        dialogImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 10);
        //dialogImg.texture = Resources.Load("Sprites/Tap and Fly/Sprites/GUI/window_score", typeof(Texture)) as Texture;
        dialogImg.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
    }

    public void SetUser(User user)
    {
        this.user = user;
    }

}
