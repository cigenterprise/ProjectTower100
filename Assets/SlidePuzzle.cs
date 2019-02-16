using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePuzzle : MonoBehaviour {

    private void Awake()
    {
        this.gameObject.AddComponent<Canvas>();

        GameObject gameObject = new GameObject();
        RawImage rawImage = gameObject.AddComponent<RawImage>();
        gameObject.transform.SetParent(this.gameObject.transform);
        rawImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 15);
        rawImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 8);

        GameObject resource = Resources.Load("Prefab") as GameObject;
        Instantiate(resource).transform.SetParent(this.gameObject.transform);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) OnMouseDown();
	}

    private void OnMouseDown()
    {
        Debug.Log("MouseButtonDown..");
    }

}
