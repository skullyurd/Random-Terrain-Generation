using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScape : Landscape
{
    private Terrain t;

    private void Start()
    {
        t = GetComponent<Terrain>();

        if(t == null)
        {
            Debug.LogError(message: "Please put the terrainscape script on a terrain");
        }
        init();
    }

    public override void generate()
    {
        Debug.Log(message: "Adding Heights");
        t.terrainData.heightmapResolution = procedulManager.instance.terrain.Size;
        t.terrainData.SetHeights(0,0,procedulManager.instance.terrain.heights);

    }
}
