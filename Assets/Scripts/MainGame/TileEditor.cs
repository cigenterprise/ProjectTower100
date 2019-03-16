using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TileEditor : MonoBehaviour
{
    ArrayList _tiles = new ArrayList();
    GameObject _selectedTile = null;

    void Awake()
    {
        ReadTilePreset( "hawi.txt" );
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateEditMode();
    }

    void ReadTilePreset( string filePath )
    {
        using ( FileStream file = new FileStream( filePath, FileMode.Open, FileAccess.Read ) )
        {
            byte[] buffer = new byte[ 4 ];

            file.Read( buffer, 0, sizeof( int ) );
            int index = System.BitConverter.ToInt32( buffer, 0 );

            for ( int idx = 0; idx < index; ++idx )
            {
                GameObject tileObject = new GameObject();
                Tile tile = tileObject.AddComponent<Tile>();

                file.Read( buffer, 0, sizeof( float ) );
                float x = System.BitConverter.ToSingle( buffer, 0 );

                file.Read( buffer, 0, sizeof( float ) );
                float y = System.BitConverter.ToSingle( buffer, 0 );

                tile.transform.position = new Vector3( x, y );
                _tiles.Add( tileObject );
            }
        }

        for ( int idx = 0; idx < _tiles.Count; ++idx )
        {
            GameObject tileObj = _tiles[ idx ] as GameObject;
            tileObj.name = $"Tile{idx}";
            tileObj.transform.SetParent( transform );
        }
    }

    // Edit mode 관련
    void WriteTilePreset( string filePath )
    {
        byte[] buffer = new byte[ 4 ];
        buffer = System.BitConverter.GetBytes( _tiles.Count );

        using ( FileStream file = new FileStream( filePath, FileMode.Create, FileAccess.Write ) )
        {
            file.Write( buffer, 0, sizeof( int ) );
            foreach ( Tile tile in _tiles )
            {
                buffer = System.BitConverter.GetBytes( tile.transform.position.x );
                file.Write( buffer, 0, sizeof( float ) );

                buffer = System.BitConverter.GetBytes( tile.transform.position.y );
                file.Write( buffer, 0, sizeof( float ) );
            }
        }
    }

    public void ToggleEditMode( bool on )
    {
        if ( on )
        {
            foreach ( GameObject tileObj in _tiles )
            {
                tileObj.AddComponent<BoxCollider>();
            }
        }
        else
        {
            foreach ( GameObject tileObj in _tiles )
            {
                Destroy( tileObj.GetComponent<BoxCollider>() );
            }
        }
    }

    private bool MouseHitTest()
    {
        if ( _selectedTile )
        {
            _selectedTile = null;
            return true;
        }

        RaycastHit hitInfo;
        Ray ray = SceneControl_MainGame._mainCamera.ScreenPointToRay( Input.mousePosition );
        if ( Physics.Raycast( ray.origin, ray.direction * 10, out hitInfo ) )
        {
            foreach ( GameObject tileObj in _tiles )
            {
                if ( hitInfo.transform == tileObj.transform )
                {
                    _selectedTile = hitInfo.transform.gameObject;
                    return true;
                }
            }
        }

        return false;
    }

    void UpdateEditMode()
    {
        if ( SceneControl_MainGame._editMode )
        {
            if ( Input.GetMouseButtonUp( 0 ) ) MouseHitTest();

            if ( _selectedTile )
            {
                Vector3 mousePos = SceneControl_MainGame._mainCamera.ScreenToWorldPoint( Input.mousePosition );
                _selectedTile.transform.position = new Vector3( Mathf.Round( mousePos.x ), Mathf.Round( mousePos.y ), 0 );

                if ( Input.mouseScrollDelta.y > 0 )
                {
                    Tile tile = _selectedTile.GetComponent<Tile>();
                    ++tile;
                    Debug.Log( tile._type.ToString() );
                }
                else if ( Input.mouseScrollDelta.y < 0 )
                {
                    Tile tile = _selectedTile.GetComponent<Tile>();
                    --tile;
                    Debug.Log( tile._type.ToString() );
                }
            }

        }
    }
}
