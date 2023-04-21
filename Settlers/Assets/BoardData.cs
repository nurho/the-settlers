using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data about the board.
/// </summary>
public class BoardData : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Offsets for the hex positions.
    const float hexw = 0.8660254f;
    const float hexh = 0.75f;

    // Positions for the tiles and tokens.
    public static readonly float[,] tile_positions = new float[,] { { 0, (5 * hexh)}, { hexw, (5 * hexh) }, { (2 * hexw), (5 * hexh) },
                                            { (-0.5f * hexw), (4 * hexh) }, { (0.5f * hexw), (4 * hexh) }, { (1.5f * hexw), (4 * hexh) }, { (2.5f * hexw), (4 * hexh) },
                                            { (-1 * hexw), (3 * hexh) }, { 0, (3 * hexh) }, { hexw, (3 * hexh) }, { (2 * hexw), (3 * hexh) }, { (3 * hexw), (3 * hexh) },
                                            { (-0.5f * hexw), (2 * hexh) }, { (0.5f * hexw), (2 * hexh) }, { (1.5f * hexw), (2 * hexh) }, { (2.5f * hexw), (2 * hexh) },
                                            { 0, hexh }, { hexw, hexh }, { (2 * hexw), hexh } };
}