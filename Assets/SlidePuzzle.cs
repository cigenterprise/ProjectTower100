using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePuzzle : MonoBehaviour
{

    private GameObject _puzzles = null;

    private void Awake()
    {
        gameObject.AddComponent<Canvas>();

        RawImage rawImage = gameObject.AddComponent<RawImage>();
        rawImage.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 15 );
        rawImage.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 8 );

        GameObject resource = Resources.Load( "Prefab" ) as GameObject;
        resource.name = "PuzzlePrefab";
        _puzzles = Instantiate( resource );
        _puzzles.transform.SetParent( transform );
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) ) OnMouseDown();
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        Camera camera = SceneControl_MainGame._mainCamera;
        mousePos = camera.ScreenToWorldPoint( mousePos );

        for ( int idx = 0; idx < _puzzles.transform.childCount; ++idx )
        {
            bool hit = MouseHitTest( ref mousePos, new Rect( 0, 0, 2, 2 ) );//gameObject.transform.GetChild(idx);
            if ( hit ) Debug.Log( $"HIT {idx} {_puzzles.transform.childCount}" );
        }
    }

    private bool MouseHitTest( ref Vector3 mousePos, Rect rect )
    {
        if ( mousePos.x > rect.position.x - rect.width / 2.0f && mousePos.x < rect.position.x + rect.width / 2.0f ) return true;
        else return false;
    }

}
