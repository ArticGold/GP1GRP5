using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    //A variable to decide how large the grid will be, width being it's with and height being it's height.
 
    [SerializeField] private TileScript _tilePrefab;
 
    [SerializeField] private Transform _cam;
 
    private Dictionary<Vector2, TileScript> _tiles;
 
    void Start() 
    {
        GenerateGrid();
    }
 
    void GenerateGrid() 
    {
        _tiles = new Dictionary<Vector2, TileScript>();
        for (int x = 0; x < _width; x++) 
        {
            for (int y = 0; y < _height; y++) 
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
 
                var isOffset = (x + y) % 2 == 1;

                spawnedTile.Init(isOffset);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
 
        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height / 2 - 0.5f,-10);
    }
 
    public TileScript GetTileAtPosition(Vector2 pos) 
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
