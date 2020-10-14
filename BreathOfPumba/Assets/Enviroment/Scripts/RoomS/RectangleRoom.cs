using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRoom : Room
{

    [Space(10)]
    [Header("Sub-Properties")]
    [SerializeField]
    private List<Vector3Int> corners = new List<Vector3Int>();

    int radiusX, radiusY;

    // Start is called before the first frame update
    public override void Start()
    {
      
        base.Start();
        //Caching Variables
        CacheVariables();
        DrawRoom();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //DrawRoom();
    }

   

    public override void DrawRoom()
    {

        //Draw Floor
        DrawFloor();
        
        //Draw Walls
        DrawWalls();

        //Decide On Entrances 
        CreateEntrances();

    }

    protected override void DrawFloor()
    {
        //BoxFill(position, tile, start x, start y, end x , end y
        floor.ClearAllTiles();
        //***********SetBoundaries***********//
        //Top Left
        floor.SetTile(corners[3], floorTileAsset);
        //Bottom Right
        floor.SetTile(corners[1], floorTileAsset);


        //Draws Floor
        floor.BoxFill(position, //origin position
            floorTileAsset, //tile type
            (corners[0].x), //start X
            (corners[0].y), //start Y
            (corners[2].x), //end X
            (corners[2].y) //end Y
            );
    }

    protected override void DrawWalls()
    {

        walls.ClearAllTiles();
        //***********SetBufferBoundaries***********//
        //Top Left
        walls.SetTile(corners[3] + new Vector3Int(-1, 1, 0), wallTileAsset);
        //Bottom Right
        walls.SetTile(corners[1] + new Vector3Int(1, -1, 0), wallTileAsset);
        
        //North Wall
        walls.BoxFill(corners[3], //origin position
         wallTileAsset, //tile type
         (corners[3].x), //start X
         (corners[3].y), //start Y
         (corners[2].x), //end X
         (corners[2].y) //end Y
         );
        //East
        walls.BoxFill(corners[0], //origin position
         wallTileAsset, //tile type
         (corners[0].x), //start X
         (corners[0].y), //start Y
         (corners[3].x), //end X
         (corners[3].y) //end Y
         );
        //South
       walls.BoxFill(corners[0]+new Vector3Int(1,0,0), //origin position
          wallTileAsset, //tile type
          (corners[0].x+1), //start X
          (corners[0].y), //start Y
          (corners[1].x-1), //end X
          (corners[1].y) //end Y
          );
        //West Wall Side
        walls.BoxFill(corners[1], //origin position
           wallTileAsset, //tile type
           (corners[1].x), //start X
           (corners[1].y), //start Y
           (corners[2].x), //end X
           (corners[2].y) //end Y
           );

        //Remove Wall Buffers
        //Top Left
        walls.SetTile(corners[3] + new Vector3Int(-1, 1, 0), null);
        //Bottom Right
        walls.SetTile(corners[1] + new Vector3Int(1, -1, 0), null);
    }

    private void CacheVariables()
    {
        radiusX = (int) (sizeX / 2);
        radiusY = (int) (sizeY / 2);

        Vector3Int temp;

        //Bottom Left Corner
        temp = position;
        temp.x = temp.x - radiusX;
        temp.y = temp.y - radiusY;
        corners.Add(temp);

        //Bottom Right
        temp = position;
        temp.x = temp.x + radiusX;
        temp.y = temp.y - radiusY;
        corners.Add(temp);

        //Top Right
        temp = position;
        temp.x = temp.x + radiusX;
        temp.y = temp.y + radiusY;
        corners.Add(temp);

        //Top Left
        temp = position;
        temp.x = temp.x - radiusX;
        temp.y = temp.y + radiusY;
        corners.Add(temp);
    }

    void CreateEntrances()
    {

    }
    

}
