using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TYPE
    {
        DEFAULT,
        A,
        B,
        NUM_TYPE
    }
    public TYPE _type = TYPE.DEFAULT;

    public static Tile operator ++( Tile right )
    {
        right._type++;
        if ( right._type == TYPE.NUM_TYPE ) right._type = TYPE.DEFAULT;
        right.SetSprite( right._type );
        return right;
    }

    public static Tile operator --( Tile right )
    {
        right._type--;
        if ( right._type < TYPE.DEFAULT ) right._type = TYPE.NUM_TYPE - 1;
        right.SetSprite( right._type );
        return right;
    }

    SpriteRenderer _spriteRenderer = null;

    void Awake()
    {
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        _spriteRenderer.sprite = Resources.Load<Sprite>( "Tiles/Textures/Brown Stony Light" );
        _spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        _spriteRenderer.size = Vector2.one;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition( float x, float y, float z = 0 )
    {
        transform.position = new Vector3( x, y, z );
    }

    public void SetSprite( TYPE type )
    {
        switch ( type )
        {
            case TYPE.DEFAULT:
                _spriteRenderer.sprite = Resources.Load<Sprite>( "Tiles/Textures/Brown Stony Light" );
                break;
            case TYPE.A:
                _spriteRenderer.sprite = Resources.Load<Sprite>( "Tiles/Textures/Grass" );
                break;
            case TYPE.B:
                _spriteRenderer.sprite = Resources.Load<Sprite>( "Tiles/Textures/Grey Stones" );
                break;
        }
    }

}
