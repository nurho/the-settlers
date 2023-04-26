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

    public void set_adjacent_intersections() {
        List<GameObject> l = IntersectionManager.intersections;

        tiles[0].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[0], l[1], l[2], l[8], l[9], l[10] });
        tiles[1].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[2], l[3], l[4], l[10], l[11], l[12] });
        tiles[2].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[4], l[5], l[6], l[12], l[13], l[14] });

        tiles[3].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[7], l[8], l[9], l[17], l[18], l[19] });
        tiles[4].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[9], l[10], l[11], l[19], l[20], l[21] });
        tiles[5].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[11], l[12], l[13], l[21], l[22], l[23] });
        tiles[6].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[13], l[14], l[15], l[23], l[24], l[25] });

        tiles[7].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[16], l[17], l[18], l[27], l[28], l[29] });
        tiles[8].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[18], l[19], l[20], l[29], l[30], l[31] });
        tiles[9].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[20], l[21], l[22], l[31], l[32], l[33] });
        tiles[10].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[22], l[23], l[24], l[33], l[34], l[35] });
        tiles[11].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[24], l[25], l[26], l[35], l[36], l[37] });

        tiles[12].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[28], l[29], l[30], l[38], l[39], l[40] });
        tiles[13].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[30], l[31], l[32], l[40], l[41], l[42] });
        tiles[14].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[32], l[33], l[34], l[42], l[43], l[44] });
        tiles[15].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[34], l[35], l[36], l[44], l[45], l[46] });

        tiles[16].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[39], l[40], l[41], l[47], l[48], l[49] });
        tiles[17].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[41], l[42], l[43], l[49], l[50], l[51] });
        tiles[18].GetComponent<TileController>().add_adjacent_intersections(new List<GameObject>() { l[43], l[44], l[45], l[51], l[52], l[53] });
    }
}