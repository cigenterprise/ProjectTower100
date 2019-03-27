using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Module_Parse : MonoBehaviour
{
    public class Parse_Dialog
    {
        string[] dlgArr;
        int dlgIdx = 0;
        public struct DlgStruct
        {
            public DlgStruct( string speaker, string script )
            {
                this.speaker = speaker;
                this.script = script;
            }
            public string speaker;
            public string script;
        }
        
        public void Open( string filePath )
        {
            dlgArr = File.ReadAllLines( filePath );
        }

        public bool Next()
        {
            ++dlgIdx;
            if ( dlgIdx == dlgArr.Length ) return false;
            else return true;
        }

        public DlgStruct? GetCurrent()
        {
            string[] split = dlgArr[ dlgIdx ].Split( ':' );
            if ( split.GetLength( 0 ) == 0 ) return null;
            return new DlgStruct( split[ 0 ], split[ 1 ] );
        }

        public void Clear()
        {
            dlgArr = null;
            dlgIdx = 0;
        }
    }
    public Parse_Dialog parseDialog = null;

    private void Awake()
    {
        parseDialog = new Parse_Dialog();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadFile(string filePath )
    {
        parseDialog.Open( filePath );
    }

}
