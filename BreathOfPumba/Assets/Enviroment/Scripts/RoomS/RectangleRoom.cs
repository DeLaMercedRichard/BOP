using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRoom : Room
{
    
    [Header("Sub-Properties")]
    [SerializeField]
    private List<Vector3Int> corners = new List<Vector3Int>();

    int radiusX, radiusY;

    // Start is called before the first frame update
    public override void Start()
    {
      
        base.Start();
        //Caching Variables
       
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //DrawRoom();
    }

 
    public override void DrawRoom()
    {
        CacheVariables();

        //Draw Floor
        DrawFloor();
        
        //Draw Walls
        DrawWalls();

      
    }

    protected override void DrawFloor()
    {
        //BoxFill(position, tile, start x, start y, end x , end y


        //Draws Floor by cycling through all 
        floor.BoxFill(position, //origin position
            floorTileAsset[Mathf.RoundToInt(Random.Range(0, floorTileAsset.Length))], //tile type
            (corners[0].x), //start X
            (corners[0].y), //start Y
            (corners[2].x), //end X
            (corners[2].y) //end Y
            );
    }

    protected override void DrawWalls()
    {

      
        
        //North Wall
        walls.BoxFill(corners[3], //origin position
         wallTileAsset[Mathf.RoundToInt(Random.Range(0, wallTileAsset.Length))], //tile type
         (corners[3].x), //start X
         (corners[3].y), //start Y
         (corners[2].x), //end X
         (corners[2].y) //end Y
         );
        //East
        walls.BoxFill(corners[0], //origin position
         wallTileAsset[Mathf.RoundToInt(Random.Range(0, wallTileAsset.Length))], //tile type
         (corners[0].x), //start X
         (corners[0].y), //start Y
         (corners[3].x), //end X
         (corners[3].y) //end Y
         );
        //South
        walls.BoxFill(corners[0]+new Vector3Int(1,0,0), //origin position
          wallTileAsset[Mathf.RoundToInt(Random.Range(0, wallTileAsset.Length))], //tile type
          (corners[0].x+1), //start X
          (corners[0].y), //start Y
          (corners[1].x-1), //end X
          (corners[1].y) //end Y
          );
        //West Wall Side
        walls.BoxFill(corners[1], //origin position
           wallTileAsset[Mathf.RoundToInt(Random.Range(0, wallTileAsset.Length))], //tile type
           (corners[1].x), //start X
           (corners[1].y), //start Y
           (corners[2].x), //end X
           (corners[2].y) //end Y
           );

     
    }

    protected override void CacheVariables()
    {

        radiusX = (int) (defaultSizeX * scaleX/ 2);
        radiusY = (int) (defaultSizeY * scaleY/ 2);

        Vector3Int temp;

        corners.Clear();
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

    public override void CreateEntrances(bool top, bool bot, bool left, bool right)
    {
        Debug.Log("Room: " + position.x + " , " + position.y );
        Debug.Log("The Corners of The Room: " + corners[0].x + " , " + corners[0].y);
        Debug.Log("The Corners of The Room: " + corners[1].x + " , " + corners[1].y);
        Debug.Log("The Corners of The Room: " + corners[2].x + " , " + corners[2].y);
        Debug.Log("The Corners of The Room: " + corners[3].x + " , " + corners[3].y);
        if (top)
        {
            //Remove Top Wall mid Section
            walls.SetTile(new Vector3Int(-1, corners[3].y, 0), null);
            walls.SetTile(new Vector3Int(0, corners[3].y, 0), null);
            walls.SetTile(new Vector3Int(1, corners[3].y, 0), null);
        }
        if (bot)
        {
            //Remove Bot Wall mid Section
            walls.SetTile(new Vector3Int(-1, corners[0].y, 0), null);
            walls.SetTile(new Vector3Int(0, corners[0].y, 0), null);
            walls.SetTile(new Vector3Int(1, corners[0].y, 0), null);
        }
        if (left)
        {
            //Remove Left Wall mid Section
            walls.SetTile(new Vector3Int(corners[0].x, 1,  0), null);
            walls.SetTile(new Vector3Int(corners[0].x, 0, 0), null);
            walls.SetTile(new Vector3Int(corners[0].x, -1, 0), null);
        }
        if (right)
        {
            //Remove Right Wall mid Section
            walls.SetTile(new Vector3Int(corners[1].x, 1, 0), null);
            walls.SetTile(new Vector3Int(corners[1].x, 0, 0), null);
            walls.SetTile(new Vector3Int(corners[1].x, -1, 0), null);
        }
    }
    

}
