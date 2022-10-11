using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] public Tilemap _generatedTilemap;
    [SerializeField] public Tile _tileGround;
    [SerializeField] public int _mapWidth;
    [SerializeField] public int _mapHeight;
    [SerializeField] public int _factorSmooth;
    [SerializeField][Range(0, 100)] public int _randomFillPercent;

    const int CountWall = 4; 
    
    public void Generate()
    {
        var map = new int[_mapWidth, _mapHeight];

        RandomFiilLevel(map);

        for(var i = 0; i < _factorSmooth; ++i) {
            SmoothMap(map);
        }

        DrawTiles(map);
    }

    public void Clear()
    {
        if(!_generatedTilemap)
            return; 

        _generatedTilemap.ClearAllTiles();
    }

    void RandomFiilLevel(int[,] map)
    {
        var psevdoRandom = new System.Random(Time.time.ToString().GetHashCode());
        for(var x = 0; x < _mapWidth; ++x)
        {
            for(var y = 0; y < _mapHeight; ++y)
            {
                if(x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1) {
                    map[x,y] = 1;
                }
                else {
                    map[x,y] = psevdoRandom.Next(0, 100) < _randomFillPercent ? 1 : 0;
                }
            }
        }
    }
    void SmoothMap(int[,] map)
    {
        for(var x = 0; x < _mapWidth; ++x)
        {
            for(var y = 0; y < _mapHeight; ++y)
            {
                var neigborWallTiles = GetNeigborWall(map, x, y);
                if(neigborWallTiles > CountWall)
                    map[x,y] = 1;
                else 
                    map[x,y] = 0;
            }
        }
    }

    int GetNeigborWall(int[,] map, int x, int y)
    {
        int wallCount = 0;

        for(var nx = x - 1; nx <= x + 1; ++nx)
        {
            for(var ny = y - 1; ny <= y + 1; ++ny)
            {
                if(nx >= 0 && nx < _mapWidth && ny >= 0 && ny < _mapHeight)
                {
                    if(nx != x || ny != y)
                        wallCount += map[nx, ny];
                }
                else {
                    ++wallCount;
                }
            }
        }

        return wallCount;
    }

    void DrawTiles(int[,] map)
    {
        if(!_generatedTilemap)
            return;

        for(var x = 0; x < _mapWidth; ++x)
        {
            for(var y = 0; y < _mapHeight; ++y)
            {
                var pos = new Vector3Int(x - _mapWidth / 2, y - _mapHeight / 2, 0);
                if(map[x,y] == 1)
                    _generatedTilemap.SetTile(pos, _tileGround);
            }
        }
    }
}
