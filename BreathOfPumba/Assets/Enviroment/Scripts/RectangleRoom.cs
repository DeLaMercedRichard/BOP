using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRoom : Room
{

    [Space(10)]
    [Header("Sub-Properties")]
    [SerializeField]
    private List<Vector3Int> corners;

    int radiusX, radiusY;

    // Start is called before the first frame update
    public override void Start()
    {
      
        base.Start();
        //Caching Variables
        CacheVariables();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //DrawRoom();
    }

   

    protected override void DrawRoom()
    {
        
        //Draw Floor
        DrawFloor();
        //Decide On Entrances 

        //Draw Walls
        DrawWalls();

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
        //North Wall
        walls.BoxFill(position, //origin position
         wallTileAsset, //tile type
         (corners[3].x), //start X
         (corners[3].y), //start Y
         (corners[2].x), //end X
         (corners[2].y) //end Y
         );
        //East
        walls.BoxFill(position, //origin position
         wallTileAsset, //tile type
         (corners[1].x), //start X
         (corners[1].y), //start Y
         (corners[2].x), //end X
         (corners[2].y) //end Y
         );
        //South
       walls.BoxFill(position, //origin position
          wallTileAsset, //tile type
          (corners[0].x), //start X
          (corners[0].y), //start Y
          (corners[1].x), //end X
          (corners[1].y) //end Y
          );
        //West Wall Side
        walls.BoxFill(position, //origin position
           wallTileAsset, //tile type
           (corners[0].x), //start X
           (corners[0].y), //start Y
           (corners[3].x), //end X
           (corners[3].y) //end Y
           );
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
}
