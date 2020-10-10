using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [SerializeField]
    public Tilemap room;
    [SerializeField]
    public TileBase floorTileAsset;
    [SerializeField]
    public TileBase wallTileAsset;

    [SerializeField]
    public Grid grid;
    [SerializeField]
    private int sizeX, sizeY;
    [SerializeField]
    private Vector3Int position = new Vector3Int(0, 0, 0);
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
    void Start()
    {
        //Set default variable for room if no room found
        if (room == null)
        {
            room = gameObject.GetComponent<Tilemap>();
        }
        if (sizeX == 0)
            sizeX = 20;
        if (sizeY == 0)
            sizeY = 20;
        room.SetTile(position, floorTileAsset);
        DrawRectangleRoom(sizeX, sizeY, position);

    }

    // Update is called once per frame
    void Update()
    {

    }



    void DrawRectangleRoom(int sizeX_, int sizeY_, Vector3Int position_)
    {
        int radiusX, radiusY;
        radiusX = sizeX_ / 2;
        radiusY = sizeY_ / 2;
        //BoxFill(position, tile, start x, start y, end x , end y
        room.BoxFill(position_, //origin position
            wallTileAsset, //tile type
            (position.x - radiusX), //start X
            (position.y - radiusY), //start Y
            (position.x + radiusX), //end X
            (position.y + radiusY)); //end Y
        room.BoxFill(position_, //origin position
           floorTileAsset, //tile type
           (position.x - radiusX + 2), //start X
           (position.y - radiusY + 2), //start Y
           (position.x + radiusX - 2), //end X
           (position.y + radiusY - 2)); //end Y
    }

    void DrawCircleRoom(int sizeX_, int sizeY_, Vector3Int position_)
    {
        int radiusX, radiusY;
        radiusX = sizeX_ / 2;
        radiusY = sizeY_ / 2;
        //BoxFill(position, tile, start x, start y, end x , end y
        room.BoxFill(position_, //origin position
            floorTileAsset, //tile type
            (position.x - radiusX), //start X
            (position.y - radiusY), //start Y
            (position.x + radiusX), //end X
            (position.y + radiusY)); //end Y
    }
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
