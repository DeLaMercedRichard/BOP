using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRoom : Room
{
    [ReadOnly]
    List<Vector3Int> corners;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

   

    protected override void DrawRoom(int sizeX_, int sizeY_, Vector3Int position_)
    {
        //Caching Variables
        sizeX = sizeX_;
        sizeY = sizeY_;
        position = position_;
        //Draw Floor
        DrawFloor();
        //Decide On Entrances 

        //Draw Walls
        

    }

    protected override void DrawFloor()
    {
        int radiusX, radiusY;
        radiusX = sizeX / 2;
        radiusY = sizeY / 2;
        //BoxFill(position, tile, start x, start y, end x , end y
        //Draw Floor
        floor.BoxFill(position, //origin position
            wallTileAsset, //tile type
            (position.x - radiusX), //start X
            (position.y - radiusY), //start Y
            (position.x + radiusX), //end X
            (position.y + radiusY)); //end Y
    }

    protected override void DrawWalls()
    {
        //Caching Variables
        Vector3Int temp;
        temp = position;
        temp.x = temp.x + sizeX;
        //Bottom Left
        corners.Add(position);
        //Bottom Right
        corners.Add(temp);
        //Top Right
        temp.y = temp.y + sizeY;
        corners.Add(temp);
        //Top Left
        temp.x = temp.x - sizeX;
        corners.Add(temp);

        //TODO:
        //Box Fill each edge 

        //North
        //West
        //South
        //East
        throw new System.NotImplementedException();
    }
}
