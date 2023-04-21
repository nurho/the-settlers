using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Finds and positions all the intersection objects for settlement/city placement.
/// </summary>
public class IntersectionManager : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    private int num_intersections = 54;
    public List<GameObject> intersections;
    float[,] tile_positions;
    static float hexw = 0.8660254f;

    List<GameObject> edges;

    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Resets then confirms all intersection validities.
    /// </summary>
    public void refresh_validity() {
        // Reset all intersections to invalid for all
        foreach (GameObject intersection in intersections) {
            intersection.GetComponent<IntersectionController>().invalid_all();
        }

        // Check intersections with adjacent roads and enable valid for that player if not blocked
        foreach (GameObject intersection in intersections) {
            IntersectionController controller = intersection.GetComponent<IntersectionController>();
            List<int> player_nums = new List<int>();

            if (!controller.has_settlement) {
                bool has_neighbour = false;
                foreach (GameObject neighbour in controller.adjacent_intersections) {
                    if (neighbour.GetComponent<IntersectionController>().has_settlement) {
                        has_neighbour = true;
                    }
                }

                if (!has_neighbour) {
                    foreach (GameObject edge in controller.adjacent_edges) {
                        if (edge.GetComponent<EdgeController>().has_road) {
                            controller.valid_player(edge.GetComponent<EdgeController>().road_player);
                        }
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tile_positions = BoardData.tile_positions;
        intersections = new List<GameObject>();
        edges = GameObject.Find("Edges").GetComponent<EdgeManager>().edges;

        // Find intersections
        for (int i = 1; i <= num_intersections; i++) {
            intersections.Add(GameObject.Find("Intersection_" + i.ToString("D2")));   
        }
            
        // Place intersections
        // Row 1
        intersections[0].transform.position = new Vector2(tile_positions[0, 0] - (hexw / 2), tile_positions[0, 1] + 0.25f);
        intersections[1].transform.position = new Vector2(tile_positions[0, 0], tile_positions[0, 1] + 0.5f);
        intersections[2].transform.position = new Vector2(tile_positions[1, 0] - (hexw / 2), tile_positions[1, 1] + 0.25f);
        intersections[3].transform.position = new Vector2(tile_positions[1, 0], tile_positions[1, 1] + 0.5f);
        intersections[4].transform.position = new Vector2(tile_positions[2, 0] - (hexw / 2), tile_positions[2, 1] + 0.25f);
        intersections[5].transform.position = new Vector2(tile_positions[2, 0], tile_positions[2, 1] + 0.5f);
        intersections[6].transform.position = new Vector2(tile_positions[2, 0] + (hexw / 2), tile_positions[2, 1] + 0.25f);

        // Row 2
        intersections[7].transform.position = new Vector2(tile_positions[3, 0] - (hexw / 2), tile_positions[3, 1] + 0.25f);
        intersections[8].transform.position = new Vector2(tile_positions[3, 0], tile_positions[3, 1] + 0.5f);
        intersections[9].transform.position = new Vector2(tile_positions[4, 0] - (hexw / 2), tile_positions[4, 1] + 0.25f);
        intersections[10].transform.position = new Vector2(tile_positions[4, 0], tile_positions[4, 1] + 0.5f);
        intersections[11].transform.position = new Vector2(tile_positions[5, 0] - (hexw / 2), tile_positions[5, 1] + 0.25f);
        intersections[12].transform.position = new Vector2(tile_positions[5, 0], tile_positions[5, 1] + 0.5f);
        intersections[13].transform.position = new Vector2(tile_positions[6, 0] - (hexw / 2), tile_positions[6, 1] + 0.25f);
        intersections[14].transform.position = new Vector2(tile_positions[6, 0], tile_positions[6, 1] + 0.5f);
        intersections[15].transform.position = new Vector2(tile_positions[6, 0] + (hexw / 2), tile_positions[6, 1] + 0.25f);

        // Row 3
        intersections[16].transform.position = new Vector2(tile_positions[7, 0] - (hexw / 2), tile_positions[7, 1] + 0.25f);
        intersections[17].transform.position = new Vector2(tile_positions[7, 0], tile_positions[7, 1] + 0.5f);
        intersections[18].transform.position = new Vector2(tile_positions[8, 0] - (hexw / 2), tile_positions[8, 1] + 0.25f);
        intersections[19].transform.position = new Vector2(tile_positions[8, 0], tile_positions[8, 1] + 0.5f);
        intersections[20].transform.position = new Vector2(tile_positions[9, 0] - (hexw / 2), tile_positions[9, 1] + 0.25f);
        intersections[21].transform.position = new Vector2(tile_positions[9, 0], tile_positions[9, 1] + 0.5f);
        intersections[22].transform.position = new Vector2(tile_positions[10, 0] - (hexw / 2), tile_positions[10, 1] + 0.25f);
        intersections[23].transform.position = new Vector2(tile_positions[10, 0], tile_positions[10, 1] + 0.5f);
        intersections[24].transform.position = new Vector2(tile_positions[11, 0] - (hexw / 2), tile_positions[11, 1] + 0.25f);
        intersections[25].transform.position = new Vector2(tile_positions[11, 0], tile_positions[11, 1] + 0.5f);
        intersections[26].transform.position = new Vector2(tile_positions[11, 0] + (hexw / 2), tile_positions[11, 1] + 0.25f);

        // Row 4
        intersections[27].transform.position = new Vector2(tile_positions[7, 0] - (hexw / 2), tile_positions[7, 1] - 0.25f);
        intersections[28].transform.position = new Vector2(tile_positions[12, 0] - (hexw / 2), tile_positions[12, 1] + 0.25f);
        intersections[29].transform.position = new Vector2(tile_positions[12, 0], tile_positions[12, 1] + 0.5f);
        intersections[30].transform.position = new Vector2(tile_positions[13, 0] - (hexw / 2), tile_positions[13, 1] + 0.25f);
        intersections[31].transform.position = new Vector2(tile_positions[13, 0], tile_positions[13, 1] + 0.5f);
        intersections[32].transform.position = new Vector2(tile_positions[14, 0] - (hexw / 2), tile_positions[14, 1] + 0.25f);
        intersections[33].transform.position = new Vector2(tile_positions[14, 0], tile_positions[14, 1] + 0.5f);
        intersections[34].transform.position = new Vector2(tile_positions[15, 0] - (hexw / 2), tile_positions[15, 1] + 0.25f);
        intersections[35].transform.position = new Vector2(tile_positions[15, 0], tile_positions[15, 1] + 0.5f);
        intersections[36].transform.position = new Vector2(tile_positions[15, 0] + (hexw / 2), tile_positions[15, 1] + 0.25f);
        intersections[37].transform.position = new Vector2(tile_positions[11, 0] + (hexw / 2), tile_positions[11, 1] - 0.25f);

        // Row 5
        intersections[38].transform.position = new Vector2(tile_positions[12, 0] - (hexw / 2), tile_positions[12, 1] - 0.25f);
        intersections[39].transform.position = new Vector2(tile_positions[16, 0] - (hexw / 2), tile_positions[16, 1] + 0.25f);
        intersections[40].transform.position = new Vector2(tile_positions[16, 0], tile_positions[16, 1] + 0.5f);
        intersections[41].transform.position = new Vector2(tile_positions[17, 0] - (hexw / 2), tile_positions[17, 1] + 0.25f);
        intersections[42].transform.position = new Vector2(tile_positions[17, 0], tile_positions[17, 1] + 0.5f);
        intersections[43].transform.position = new Vector2(tile_positions[18, 0] - (hexw / 2), tile_positions[18, 1] + 0.25f);
        intersections[44].transform.position = new Vector2(tile_positions[18, 0], tile_positions[18, 1] + 0.5f);
        intersections[45].transform.position = new Vector2(tile_positions[18, 0] + (hexw / 2), tile_positions[18, 1] + 0.25f);
        intersections[46].transform.position = new Vector2(tile_positions[15, 0] + (hexw / 2), tile_positions[15, 1] - 0.25f);

        // Row 6
        intersections[47].transform.position = new Vector2(tile_positions[16, 0] - (hexw / 2), tile_positions[16, 1] - 0.25f);
        intersections[48].transform.position = new Vector2(tile_positions[16, 0], tile_positions[16, 1] - 0.5f);
        intersections[49].transform.position = new Vector2(tile_positions[17, 0] - (hexw / 2), tile_positions[17, 1] - 0.25f);
        intersections[50].transform.position = new Vector2(tile_positions[17, 0], tile_positions[17, 1] - 0.5f);
        intersections[51].transform.position = new Vector2(tile_positions[18, 0] - (hexw / 2), tile_positions[18, 1] - 0.25f);
        intersections[52].transform.position = new Vector2(tile_positions[18, 0], tile_positions[18, 1] - 0.5f);
        intersections[53].transform.position = new Vector2(tile_positions[18, 0] + (hexw / 2), tile_positions[18, 1] - 0.25f);


        // Set adjacent intersections
        // Row 1
        intersections[0].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[1], intersections[8] });
        intersections[1].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[0], intersections[2] });
        intersections[2].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[1], intersections[3], intersections[10] });
        intersections[3].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[2], intersections[4] });
        intersections[4].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[3], intersections[5], intersections[12] });
        intersections[5].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[4], intersections[6] });
        intersections[6].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[5], intersections[14] });

        // Row 2
        intersections[7].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[8], intersections[17] });
        intersections[8].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[7], intersections[9], intersections[0] });
        intersections[9].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[8], intersections[10], intersections[19] });
        intersections[10].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[9], intersections[11], intersections[2] });
        intersections[11].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[10], intersections[12], intersections[21] });
        intersections[12].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[11], intersections[13], intersections[4] });
        intersections[13].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[12], intersections[14], intersections[23] });
        intersections[14].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[13], intersections[15], intersections[6] });
        intersections[15].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[14], intersections[25] });

        // Row 3
        intersections[16].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[17], intersections[27] });
        intersections[17].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[16], intersections[18], intersections[7] });
        intersections[18].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[17], intersections[19], intersections[29] });
        intersections[19].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[18], intersections[20], intersections[9] });
        intersections[20].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[19], intersections[21], intersections[31] });
        intersections[21].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[20], intersections[22], intersections[11] });
        intersections[22].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[21], intersections[23], intersections[33] });
        intersections[23].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[22], intersections[24], intersections[13] });
        intersections[24].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[23], intersections[25], intersections[35] });
        intersections[25].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[24], intersections[26], intersections[15] });
        intersections[26].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[25], intersections[37] });

        // Row 4
        intersections[27].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[28], intersections[16] });
        intersections[28].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[27], intersections[29], intersections[38] });
        intersections[29].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[28], intersections[30], intersections[18] });
        intersections[30].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[29], intersections[31], intersections[40] });
        intersections[31].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[30], intersections[32], intersections[20] });
        intersections[32].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[31], intersections[33], intersections[42] });
        intersections[33].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[32], intersections[34], intersections[22] });
        intersections[34].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[33], intersections[35], intersections[44] });
        intersections[35].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[34], intersections[36], intersections[24] });
        intersections[36].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[35], intersections[37], intersections[46] });
        intersections[37].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[36], intersections[26] });

        // Row 5
        intersections[38].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[39], intersections[28] });
        intersections[39].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[38], intersections[40], intersections[47] });
        intersections[40].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[39], intersections[41], intersections[30] });
        intersections[41].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[40], intersections[42], intersections[49] });
        intersections[42].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[41], intersections[43], intersections[32] });
        intersections[43].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[42], intersections[44], intersections[51] });
        intersections[44].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[43], intersections[45], intersections[34] });
        intersections[45].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[44], intersections[46], intersections[53] });
        intersections[46].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[45], intersections[36] });

        // Row 6
        intersections[47].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[48], intersections[39] });
        intersections[48].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[47], intersections[49] });
        intersections[49].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[48], intersections[50], intersections[41] });
        intersections[50].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[49], intersections[51] });
        intersections[51].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[50], intersections[52], intersections[43] });
        intersections[52].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[51], intersections[53] });
        intersections[53].GetComponent<IntersectionController>().add_adjacent_intersections(new List<GameObject>() { intersections[52], intersections[45] });


        // Add adjacent edges
        intersections[0].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[0], edges[6] });
        intersections[1].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[0], edges[1] });
        intersections[2].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[1], edges[2], edges[7] });
        intersections[3].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[2], edges[3] });
        intersections[4].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[3], edges[4], edges[8] });
        intersections[5].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[4], edges[5] });
        intersections[6].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[5], edges[9] });

        intersections[7].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[10], edges[18] });
        intersections[8].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[6], edges[10], edges[11] });
        intersections[9].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[11], edges[12], edges[19] });
        intersections[10].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[7], edges[12], edges[13] });
        intersections[11].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[13], edges[14], edges[20] });
        intersections[12].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[8], edges[14], edges[15] });
        intersections[13].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[15], edges[16], edges[21] });
        intersections[14].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[9], edges[16], edges[17] });
        intersections[15].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[17], edges[22] });

        intersections[16].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[23], edges[33] });
        intersections[17].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[18], edges[23], edges[24] });
        intersections[18].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[24], edges[25], edges[34] });
        intersections[19].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[19], edges[25], edges[26] });
        intersections[20].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[26], edges[27], edges[35] });
        intersections[21].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[20], edges[27], edges[28] });
        intersections[22].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[28], edges[29], edges[36] });
        intersections[23].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[21], edges[29], edges[30] });
        intersections[24].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[30], edges[31], edges[37] });
        intersections[25].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[22], edges[31], edges[32] });
        intersections[26].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[32], edges[38] });

        intersections[27].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[33], edges[39] });
        intersections[28].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[39], edges[40], edges[49] });
        intersections[29].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[34], edges[40], edges[41] });
        intersections[30].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[41], edges[42], edges[50] });
        intersections[31].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[35], edges[42], edges[43] });
        intersections[32].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[43], edges[44], edges[51] });
        intersections[33].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[36], edges[44], edges[45] });
        intersections[34].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[45], edges[46], edges[52] });
        intersections[35].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[37], edges[46], edges[47] });
        intersections[36].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[47], edges[48], edges[53] });
        intersections[37].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[38], edges[48] });

        intersections[38].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[49], edges[54] });
        intersections[39].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[54], edges[55], edges[62] });
        intersections[40].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[50], edges[55], edges[56] });
        intersections[41].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[56], edges[57], edges[63] });
        intersections[42].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[51], edges[57], edges[58] });
        intersections[43].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[58], edges[59], edges[64] });
        intersections[44].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[52], edges[59], edges[60] });
        intersections[45].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[60], edges[61], edges[65] });
        intersections[46].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[53], edges[61] });

        intersections[47].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[62], edges[66] });
        intersections[48].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[66], edges[67] });
        intersections[49].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[63], edges[67], edges[68] });
        intersections[50].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[68], edges[69] });
        intersections[51].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[64], edges[69], edges[70] });
        intersections[52].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[70], edges[71] });
        intersections[53].GetComponent<IntersectionController>().add_adjacent_edges(new List<GameObject>() { edges[65], edges[71] });

        // Set adjacent intersections for edges
        foreach (GameObject intersection in intersections) {
            IntersectionController controller = intersection.GetComponent<IntersectionController>();
            foreach (GameObject edge in controller.adjacent_edges) {
                edge.GetComponent<EdgeController>().add_adjacent_intersection(intersection);
            }
        }

        // Once intersections are setup, start resource setup
        GameObject.Find("Game").GetComponent<ResourceManager>().setup_resources();

        Debug.Log(Time.realtimeSinceStartup);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
