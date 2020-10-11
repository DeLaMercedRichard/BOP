using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Room : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    public Tilemap floor;
    [SerializeField]
    public Tilemap walls;
    [SerializeField]
    public Tilemap hazards;
    [SerializeField]
    public Tilemap obstacles;
    [SerializeField]
    public TileBase floorTileAsset;
    [SerializeField]
    public TileBase wallTileAsset;

    [Space(10)]

    [SerializeField]
    public Grid grid;

    [Space(10)]
    [Header("Properties")]
    [SerializeField]
    protected int sizeX;
    [SerializeField]
    protected int sizeY;
    [SerializeField]
    protected Vector3Int position = new Vector3Int(0, 0, 0);
    [SerializeField]
    protected bool topConnected, bottomConnected, rightConnected, leftConnected;
    [SerializeField]
    protected int numberOfEntrances;

    /*
    World: 
    position
    offset
     
    Relative:
    start
    end

    Boolean:
    isSpawn
    isGoal

    Collision:
    boundaries
     */
    // Start is called before the first frame update
    public virtual void Start()
    {
        //Set default variable for room if no room found
        if (floor == null)
        {
            floor = gameObject.GetComponent<Tilemap>();
        }
        
        if (sizeX == 0)
            sizeX = 20;
        if (sizeY == 0)
            sizeY = 20;

       
        //for Debugging (draws a  tile at centre)
        //room.SetTile(position, floorTileAsset);

    }

    // Update is called once per frame
    public virtual void Update()
    {
       
    }



    protected abstract void DrawRoom();
    protected abstract void DrawFloor();
    protected abstract void DrawWalls();
}
/*
   public class TestPaint : MonoBehaviour
    {
        public TileBase tileAsset;
        public Tilemap tilemap;
 
        public Grid grid;
        // Use this for initialization
 
        void Start () {
            AdvancedTileBrush brushInstance = ScriptableObject.CreateInstance<AdvancedTileBrush>();
 
            Vector4 v = new Vector4(1f, 0, 0, 0);
            Vector4 v2 = new Vector4(0, 1f, 0, 0);
            Vector4 v3 = new Vector4(0, 0, 1f, 0);
            Vector4 v4 = new Vector4(0, 0, 0, 1f);
 
            brushInstance.cells[0] = new GridBrush.BrushCell{tile = tileAsset, color = Color.white, matrix = new Matrix4x4(v,v2,v3,v4)};
            for (int i = 0; i < 10; i++)
            {
                brushInstance.Paint(grid, tilemap.gameObject ,new Vector3Int(i,i,0));
            }
        }
    }
 */
