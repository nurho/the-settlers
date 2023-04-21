using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the tiles that make up the game board.
/// </summary>
public class TileManager : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Declare containers for the tile objects.
    List<GameObject> hillTiles;
    List<GameObject> forestTiles;
    List<GameObject> mountainTiles;
    List<GameObject> fieldTiles;
    List<GameObject> pastureTiles;
    GameObject desertTile;

    public static GameObject[] tiles;

    // Positions of the tiles on the board.
    float[,] positions = BoardData.tile_positions;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Finds and assigns the tile objects.
    /// </summary>
    public void setup_tiles() {
        hillTiles = new List<GameObject> { GameObject.Find("TileHill1"), GameObject.Find("TileHill2"), GameObject.Find("TileHill3") };
        forestTiles = new List<GameObject> { GameObject.Find("TileForest1"), GameObject.Find("TileForest2"), GameObject.Find("TileForest3"), GameObject.Find("TileForest4") };
        mountainTiles = new List<GameObject> { GameObject.Find("TileMountain1"), GameObject.Find("TileMountain2"), GameObject.Find("TileMountain3") };
        fieldTiles = new List<GameObject> { GameObject.Find("TileField1"), GameObject.Find("TileField2"), GameObject.Find("TileField3"), GameObject.Find("TileField4") };
        pastureTiles = new List<GameObject> { GameObject.Find("TilePasture1"), GameObject.Find("TilePasture2"), GameObject.Find("TilePasture3"), GameObject.Find("TilePasture4") };
        desertTile = GameObject.Find("TileDesert");

        tiles = new GameObject[19];
    }

    /// <summary>
    /// Place the tiles that make up the board in the specified layout.
    /// </summary>
    /// <param name="layout">A list of strings providing the layout of the tiles.</param>
    public void place_tiles(List<string> layout) {
        // TODO Perhaps refactor this stuff
        // Loop through the layout and place the tiles in the corresponding position
        int i = 0;
        foreach (string s in layout) {
            switch (s) {
                case "hill":
                    hillTiles[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    tiles[i] = hillTiles[0];
                    hillTiles.RemoveAt(0);
                    break;
                case "forest":
                    forestTiles[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    tiles[i] = forestTiles[0];
                    forestTiles.RemoveAt(0);
                    break;
                case "mountain":
                    mountainTiles[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    tiles[i] = mountainTiles[0];
                    mountainTiles.RemoveAt(0);
                    break;
                case "field":
                    fieldTiles[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    tiles[i] = fieldTiles[0];
                    fieldTiles.RemoveAt(0);
                    break;
                case "pasture":
                    pastureTiles[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    tiles[i] = pastureTiles[0];
                    pastureTiles.RemoveAt(0);
                    break;
                case "desert":
                    desertTile.transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    tiles[i] = desertTile;
                    break;
                default:
                    break;
            }
            i++;
        }
    }
}