using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : MonoBehaviour
{
    protected Canvas _canvas = null;

    protected void Awake()
    {
        // 캔버스
        _canvas = gameObject.AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler canvasScaler = gameObject.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        float scaleX = _canvas.pixelRect.width / canvasScaler.referenceResolution.x;
        float scaleY = _canvas.pixelRect.height / canvasScaler.referenceResolution.y;
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        if ( scaleX > scaleY ) canvasScaler.matchWidthOrHeight = 1.0f;
        else canvasScaler.matchWidthOrHeight = 0.0f;

        gameObject.AddComponent<GraphicRaycaster>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected abstract void MakeComponents();
    public abstract void Refresh();

    public enum CUSTOM_ANCHOR
    {
        TOP_LEFT,
        BOTTOM,
        BOTTOM_LEFT,
    }
    protected void CustomAnchor( RectTransform rect, CUSTOM_ANCHOR anchor )
    {
        switch ( anchor )
        {
            case CUSTOM_ANCHOR.TOP_LEFT:
                rect.pivot = new Vector2( 0, 1 );
                rect.anchorMin = new Vector2( 0, 1 );
                rect.anchorMax = new Vector2( 0, 1 );
                break;
            case CUSTOM_ANCHOR.BOTTOM:
                rect.pivot = new Vector2( 0.5f, 0 );
                rect.anchorMin = new Vector2( 0.5f, 0 );
                rect.anchorMax = new Vector2( 0.5f, 0 );
                break;
            case CUSTOM_ANCHOR.BOTTOM_LEFT:
                rect.pivot = new Vector2( 0, 0 );
                rect.anchorMin = new Vector2( 0, 0 );
                rect.anchorMax = new Vector2( 0, 0 );
                break;
            default:
                break;
        }
    }

}
