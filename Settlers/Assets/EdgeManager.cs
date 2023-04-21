using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Finds and positions all the edge objects for road placement.
/// </summary>
public class EdgeManager : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    private int num_edges = 72;
    public List<GameObject> edges;
    float[,] tile_positions;

    // Positional offset values
    static float hexw = 0.8660254f;
    static float angled_x_offset = hexw * 0.25f;
    static float angled_y_offset = 0.38f;
    static float vertical_x_offset = hexw * 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        tile_positions = BoardData.tile_positions;
        edges = new List<GameObject>();

        // Find edges
        for (int i = 1; i <= num_edges; i++) {
            edges.Add(GameObject.Find("Edge_" + i.ToString("D2")));
        }

        // Place edges

        edges[0].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[0, 0] - angled_x_offset, tile_positions[0, 1] + angled_y_offset), "left_down");
        edges[1].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[0, 0] + angled_x_offset, tile_positions[0, 1] + angled_y_offset), "left_up");
        edges[2].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[1, 0] - angled_x_offset, tile_positions[1, 1] + angled_y_offset), "left_down");
        edges[3].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[1, 0] + angled_x_offset, tile_positions[1, 1] + angled_y_offset), "left_up");
        edges[4].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[2, 0] - angled_x_offset, tile_positions[2, 1] + angled_y_offset), "left_down");
        edges[5].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[2, 0] + angled_x_offset, tile_positions[2, 1] + angled_y_offset), "left_up");

        edges[6].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[0, 0] - vertical_x_offset, tile_positions[0, 1]), "vertical");
        edges[7].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[0, 0] + vertical_x_offset, tile_positions[0, 1]), "vertical");
        edges[8].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[2, 0] - vertical_x_offset, tile_positions[2, 1]), "vertical");
        edges[9].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[2, 0] + vertical_x_offset, tile_positions[2, 1]), "vertical");


        edges[10].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[3, 0] - angled_x_offset, tile_positions[3, 1] + angled_y_offset), "left_down");
        edges[11].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[3, 0] + angled_x_offset, tile_positions[3, 1] + angled_y_offset), "left_up");
        edges[12].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[4, 0] - angled_x_offset, tile_positions[4, 1] + angled_y_offset), "left_down");
        edges[13].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[4, 0] + angled_x_offset, tile_positions[4, 1] + angled_y_offset), "left_up");
        edges[14].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[5, 0] - angled_x_offset, tile_positions[5, 1] + angled_y_offset), "left_down");
        edges[15].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[5, 0] + angled_x_offset, tile_positions[5, 1] + angled_y_offset), "left_up");
        edges[16].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[6, 0] - angled_x_offset, tile_positions[6, 1] + angled_y_offset), "left_down");
        edges[17].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[6, 0] + angled_x_offset, tile_positions[6, 1] + angled_y_offset), "left_up");

        edges[18].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[3, 0] - vertical_x_offset, tile_positions[3, 1]), "vertical");
        edges[19].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[3, 0] + vertical_x_offset, tile_positions[3, 1]), "vertical");
        edges[20].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[4, 0] + vertical_x_offset, tile_positions[4, 1]), "vertical");
        edges[21].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[5, 0] + vertical_x_offset, tile_positions[5, 1]), "vertical");
        edges[22].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[6, 0] + vertical_x_offset, tile_positions[6, 1]), "vertical");


        edges[23].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[7, 0] - angled_x_offset, tile_positions[7, 1] + angled_y_offset), "left_down");
        edges[24].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[7, 0] + angled_x_offset, tile_positions[7, 1] + angled_y_offset), "left_up");
        edges[25].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[8, 0] - angled_x_offset, tile_positions[8, 1] + angled_y_offset), "left_down");
        edges[26].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[8, 0] + angled_x_offset, tile_positions[8, 1] + angled_y_offset), "left_up");
        edges[27].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[9, 0] - angled_x_offset, tile_positions[9, 1] + angled_y_offset), "left_down");
        edges[28].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[9, 0] + angled_x_offset, tile_positions[9, 1] + angled_y_offset), "left_up");
        edges[29].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[10, 0] - angled_x_offset, tile_positions[10, 1] + angled_y_offset), "left_down");
        edges[30].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[10, 0] + angled_x_offset, tile_positions[10, 1] + angled_y_offset), "left_up");
        edges[31].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[11, 0] - angled_x_offset, tile_positions[11, 1] + angled_y_offset), "left_down");
        edges[32].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[11, 0] + angled_x_offset, tile_positions[11, 1] + angled_y_offset), "left_up");

        edges[33].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[7, 0] - vertical_x_offset, tile_positions[7, 1]), "vertical");
        edges[34].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[7, 0] + vertical_x_offset, tile_positions[7, 1]), "vertical");
        edges[35].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[8, 0] + vertical_x_offset, tile_positions[8, 1]), "vertical");
        edges[36].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[9, 0] + vertical_x_offset, tile_positions[9, 1]), "vertical");
        edges[37].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[10, 0] + vertical_x_offset, tile_positions[10, 1]), "vertical");
        edges[38].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[11, 0] + vertical_x_offset, tile_positions[11, 1]), "vertical");

        edges[39].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[7, 0] - angled_x_offset, tile_positions[7, 1] - angled_y_offset), "left_up");
        edges[40].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[7, 0] + angled_x_offset, tile_positions[7, 1] - angled_y_offset), "left_down");
        edges[41].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[8, 0] - angled_x_offset, tile_positions[8, 1] - angled_y_offset), "left_up");
        edges[42].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[8, 0] + angled_x_offset, tile_positions[8, 1] - angled_y_offset), "left_down");
        edges[43].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[9, 0] - angled_x_offset, tile_positions[9, 1] - angled_y_offset), "left_up");
        edges[44].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[9, 0] + angled_x_offset, tile_positions[9, 1] - angled_y_offset), "left_down");
        edges[45].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[10, 0] - angled_x_offset, tile_positions[10, 1] - angled_y_offset), "left_up");
        edges[46].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[10, 0] + angled_x_offset, tile_positions[10, 1] - angled_y_offset), "left_down");
        edges[47].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[11, 0] - angled_x_offset, tile_positions[11, 1] - angled_y_offset), "left_up");
        edges[48].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[11, 0] + angled_x_offset, tile_positions[11, 1] - angled_y_offset), "left_down");


        edges[49].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[12, 0] - vertical_x_offset, tile_positions[12, 1]), "vertical");
        edges[50].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[12, 0] + vertical_x_offset, tile_positions[12, 1]), "vertical");
        edges[51].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[13, 0] + vertical_x_offset, tile_positions[13, 1]), "vertical");
        edges[52].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[14, 0] + vertical_x_offset, tile_positions[14, 1]), "vertical");
        edges[53].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[15, 0] + vertical_x_offset, tile_positions[15, 1]), "vertical");

        edges[54].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[12, 0] - angled_x_offset, tile_positions[12, 1] - angled_y_offset), "left_up");
        edges[55].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[12, 0] + angled_x_offset, tile_positions[12, 1] - angled_y_offset), "left_down");
        edges[56].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[13, 0] - angled_x_offset, tile_positions[13, 1] - angled_y_offset), "left_up");
        edges[57].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[13, 0] + angled_x_offset, tile_positions[13, 1] - angled_y_offset), "left_down");
        edges[58].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[14, 0] - angled_x_offset, tile_positions[14, 1] - angled_y_offset), "left_up");
        edges[59].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[14, 0] + angled_x_offset, tile_positions[14, 1] - angled_y_offset), "left_down");
        edges[60].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[15, 0] - angled_x_offset, tile_positions[15, 1] - angled_y_offset), "left_up");
        edges[61].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[15, 0] + angled_x_offset, tile_positions[15, 1] - angled_y_offset), "left_down");


        edges[62].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[16, 0] - vertical_x_offset, tile_positions[16, 1]), "vertical");
        edges[63].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[16, 0] + vertical_x_offset, tile_positions[16, 1]), "vertical");
        edges[64].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[17, 0] + vertical_x_offset, tile_positions[17, 1]), "vertical");
        edges[65].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[18, 0] + vertical_x_offset, tile_positions[18, 1]), "vertical");

        edges[66].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[16, 0] - angled_x_offset, tile_positions[16, 1] - angled_y_offset), "left_up");
        edges[67].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[16, 0] + angled_x_offset, tile_positions[16, 1] - angled_y_offset), "left_down");
        edges[68].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[17, 0] - angled_x_offset, tile_positions[17, 1] - angled_y_offset), "left_up");
        edges[69].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[17, 0] + angled_x_offset, tile_positions[17, 1] - angled_y_offset), "left_down");
        edges[70].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[18, 0] - angled_x_offset, tile_positions[18, 1] - angled_y_offset), "left_up");
        edges[71].GetComponent<EdgeController>().setup_edge(new Vector2(tile_positions[18, 0] + angled_x_offset, tile_positions[18, 1] - angled_y_offset), "left_down");


        // Set adjacents

        edges[0].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[1], edges[6] });
        edges[1].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[0], edges[2], edges[7] });
        edges[2].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[1], edges[3], edges[7] });
        edges[3].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[2], edges[4], edges[8] });
        edges[4].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[3], edges[5], edges[8] });
        edges[5].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[4], edges[3], edges[9] });

        edges[6].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[0], edges[10], edges[11] });
        edges[7].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[1], edges[2], edges[12], edges[13] });
        edges[8].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[3], edges[4], edges[14], edges[15] });
        edges[9].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[5], edges[16], edges[17] });


        edges[10].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[6], edges[11], edges[18] });
        edges[11].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[6], edges[10], edges[12], edges[19] });
        edges[12].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[7], edges[11], edges[13], edges[19] });
        edges[13].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[7], edges[12], edges[14], edges[20] });
        edges[14].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[8], edges[13], edges[15], edges[20] });
        edges[15].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[8], edges[14], edges[16], edges[21] });
        edges[16].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[9], edges[15], edges[17], edges[21] });
        edges[17].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[9], edges[16], edges[22] });

        edges[18].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[10], edges[23], edges[24] });
        edges[19].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[11], edges[12], edges[25], edges[26] });
        edges[20].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[13], edges[14], edges[27], edges[28] });
        edges[21].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[15], edges[16], edges[29], edges[30] });
        edges[22].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[17], edges[31], edges[32] });


        edges[23].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[18], edges[24], edges[33] });
        edges[24].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[18], edges[23], edges[25], edges[34] });
        edges[25].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[19], edges[24], edges[26], edges[34] });
        edges[26].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[19], edges[25], edges[27], edges[35] });
        edges[27].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[20], edges[26], edges[28], edges[35] });
        edges[28].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[20], edges[27], edges[29], edges[36] });
        edges[29].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[21], edges[28], edges[30], edges[36] });
        edges[30].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[21], edges[29], edges[31], edges[37] });
        edges[31].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[22], edges[30], edges[32], edges[37] });
        edges[32].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[22], edges[31], edges[38] });

        edges[33].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[23], edges[39] });
        edges[34].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[24], edges[25], edges[40], edges[41] });
        edges[35].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[26], edges[27], edges[42], edges[43] });
        edges[36].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[28], edges[29], edges[44], edges[45] });
        edges[37].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[30], edges[31], edges[46], edges[47] });
        edges[38].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[32], edges[48] });

        edges[39].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[33], edges[40], edges[49] });
        edges[40].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[34], edges[39], edges[41], edges[49] });
        edges[41].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[34], edges[40], edges[42], edges[50] });
        edges[42].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[35], edges[41], edges[43], edges[50] });
        edges[43].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[35], edges[42], edges[44], edges[51] });
        edges[44].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[36], edges[43], edges[45], edges[51] });
        edges[45].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[36], edges[44], edges[46], edges[52] });
        edges[46].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[37], edges[45], edges[47], edges[52] });
        edges[47].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[37], edges[46], edges[48], edges[53] });
        edges[48].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[38], edges[47], edges[55] });


        edges[49].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[39], edges[40], edges[54] });
        edges[50].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[41], edges[42], edges[55], edges[56] });
        edges[51].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[43], edges[44], edges[57], edges[58] });
        edges[52].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[45], edges[46], edges[59], edges[60] });
        edges[53].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[47], edges[48], edges[61] });

        edges[54].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[49], edges[55], edges[62] });
        edges[55].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[50], edges[54], edges[56], edges[62] });
        edges[56].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[50], edges[55], edges[57], edges[63] });
        edges[57].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[51], edges[56], edges[58], edges[63] });
        edges[58].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[51], edges[57], edges[59], edges[64] });
        edges[59].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[52], edges[58], edges[60], edges[64] });
        edges[60].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[52], edges[59], edges[61], edges[65] });
        edges[61].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[53], edges[60], edges[65] });


        edges[62].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[54], edges[55], edges[66] });
        edges[63].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[56], edges[57], edges[67], edges[68] });
        edges[64].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[58], edges[59], edges[69], edges[70] });
        edges[65].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[60], edges[61], edges[71] });

        edges[66].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[62], edges[67] });
        edges[67].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[63], edges[66], edges[68] });
        edges[68].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[63], edges[67], edges[69] });
        edges[69].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[64], edges[68], edges[70] });
        edges[70].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[64], edges[69], edges[71] });
        edges[71].GetComponent<EdgeController>().add_adjacents(new List<GameObject> { edges[65], edges[70] });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
