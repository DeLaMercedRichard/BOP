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
    public TileBase[] floorTileAsset;
    [SerializeField]
    public TileBase[] wallTileAsset;
    [SerializeField]
    public TileBase[] hazardTileAsset;
    [SerializeField]
    public TileBase[] objectTileAsset;
    [SerializeField]
    public RoomPopulator populator;

    [Header("Room Properties")]
    [SerializeField]
    public int defaultSizeX;
    [SerializeField]
    public int defaultSizeY;
    [SerializeField]
    public Vector3Int position = new Vector3Int(0, 0, 0);
    [SerializeField]
    public int scaleX;
    [SerializeField]
    public int scaleY;


    [SerializeField]
    public bool topConnected, bottomConnected, rightConnected, leftConnected;
    [SerializeField]
    public int numberOfEntrances;

    [SerializeField]
    public Vector2Int gridPosition;



    // Start is called before the first frame update
    public virtual void Start()
    {
        //Set default variable for room if no room found
        if (floor == null)
        {
            floor = gameObject.GetComponent<Tilemap>();
        }
        
        if (defaultSizeX == 0)
            defaultSizeX = 20;
        if (defaultSizeY == 0)
            defaultSizeY = 20;

       
        //for Debugging (draws a  tile at centre)
        //SetTile(position, floorTileAsset);

    }

    // Update is called once per frame
    public virtual void Update()
    {
       
    }
    //PrefabSetters
    /*
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
         */
    public void SetFloorTileMap(Tilemap floorTileMap)
    {
        floor = floorTileMap;
    }
    public void SetWallTileMap(Tilemap wallTileMap)
    {
        walls = wallTileMap;
    }
    public void SetHazardTileMap(Tilemap hazardsTileMap)
    {
        hazards = hazardsTileMap;
    }
    public void SetObstaclesTileMap(Tilemap objectsTileMap)
    {
        obstacles = objectsTileMap;
    }
    public void SetFloorTileAsset(TileBase[] floorTiles)
    {
        floorTileAsset = floorTiles; 
    }
    public void SetWallTileAsset(TileBase[] wallTiles)
    {
        wallTileAsset = wallTiles;
    }
    public void SetHazardTileAsset(TileBase[] hazardTiles)
    {
        hazardTileAsset = hazardTiles;
    }
    public void SetObjectTileAsset(TileBase[] objectTiles)
    {
        objectTileAsset = objectTiles;
    }

    //Property Setters
    public void SetSize(int x, int y)
    {
        defaultSizeX = x;
        defaultSizeY = y;
    }
    public void SetPosition(Vector3Int position_)
    {
        position = position_;
    }
    public void SetEntranceLocations(bool top, bool bot, bool left, bool right)
    {
        topConnected = top;
        bottomConnected = bot;
        leftConnected = left;
        rightConnected = right;
    }
    public void SetNumberOfEntrances(int number_)
    {
        numberOfEntrances = number_;
    }
    public void SetScale(int x, int y)
    {
        scaleX = x;
        scaleY = y;
    }
    //Main Methods
    public abstract void DrawRoom();
    protected abstract void CacheVariables();

    //Walls
    public abstract void CreateEntrances(bool top, bool bot, bool left, bool right);
    protected abstract void DrawWalls();
    
    //Floors
    protected abstract void DrawFloor();

    public abstract void PopulateRoom(GameObject gameObject, Vector2Int position, int amount);
   
  
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
