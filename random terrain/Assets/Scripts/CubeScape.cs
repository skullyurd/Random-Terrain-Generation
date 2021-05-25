using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScape : Landscape
{
    public GameObject prefab;
    public override void clean()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public override void generate()
    {
        clean();
        for (int x = 0; x < procedulManager.instance.terrain.Size; x++)
        {
            for (int z = 0; z < procedulManager.instance.terrain.Size; z++)
            {
                float height = procedulManager.instance.terrain.heights[x, z];

                Vector3 posz = new Vector3(x, height, z);
                GameObject spawnCube =  Instantiate(prefab, transform.position + posz, Quaternion.identity, transform);

                //A test to see if I can spawn loose objects within the generation of the terrain
                //Test result: it worked.
                //The piece of code stays commented and not deleted for the sake of showing it works when it's needed again. But at the moment
                //I don't want the test object to spawn.

                /*height = -1 - spawnCube.transform.position.y / maxHeight;
                spawnCube.GetComponent<MeshRenderer>().material.color = new Color(height, height, height);*/
            }
        }
    }
}
