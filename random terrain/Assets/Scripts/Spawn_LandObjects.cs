using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_LandObjects : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Terrain t_terrain;
    [SerializeField] private float tresholder;

    private void Start()
    {
        DetailMapCutoff(t_terrain, tresholder);
    }

    // Set all pixels in a detail map below a certain threshold to zero.
    void DetailMapCutoff(Terrain t, float threshold)
    {
        // Get all of layer zero.
        var map = t.terrainData.GetDetailLayer(0, 0, t.terrainData.detailWidth, t.terrainData.detailHeight, 0);

        // For each pixel in the detail map...

        for (var y = 0; y < t.terrainData.detailHeight; y++)
        {
            for (var x = 0; x < t.terrainData.detailWidth; x++)
            {
                // If the pixel value is below the threshold then
                // set it to zero.
                if (map[x, y] < threshold)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(cube, new Vector3(Random.Range(0, t.terrainData.detailWidth), y, Random.Range(0, t.terrainData.detailHeight)), Quaternion.identity);
                    }
                    map[x, y] = 0;

                }
            }
        }

        // Assign the modified map back.
        t.terrainData.SetDetailLayer(0, 0, 0, map);
    }
}
