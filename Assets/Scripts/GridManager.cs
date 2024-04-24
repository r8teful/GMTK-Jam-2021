using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class GridManager : MonoBehaviour {
    private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    private void Start() {
        _width = 18;
        _height = 10;
        GenerateGrid();
    }

    void GenerateGrid() {
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x-8.5f, y-4.5f,10), Quaternion.identity);
                spawnedTile.name = $"Tile{x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }

    }
}
