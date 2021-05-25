using System.Collections;
using System.Collections.Generic;                                        
using UnityEngine;                                                       
using System;

[Serializable]
public class ProceduralTerrain
{
    public enum genType
    {
        RandomBased,
        PerlinBased,
        sinBased,
        TEST1,
        TEST2,
        TEST3,
    };

    [SerializeField]
    private float maxHeight = 0f;
    [SerializeField]
    private float minimumHeight = 1f;
    [SerializeField]
    private int size = 10;
    [SerializeField]
    private float detail = 10f;
    [SerializeField]
    private int seed = 0;
    [SerializeField]
    private genType type;
    [SerializeField]
    public float[,] heights;

    //public float minHeight
    //{
    //    get { return minimumHeight; }
    //    set
    //    {
    //        minimumHeight = value;
    //        init();
    //    }
    //}

    //public float MaxHeight
    //{
    //    get { return maxHeight; }
    //    set
    //    {
    //        maxHeight = value;
    //        init();
    //    }
    //}

        public int Size
        {
            get { return size; }
            set
            {
                size = value;
                init();
            }
        }

    //public float Detail
    //{
    //    get { return detail; }
    //    set
    //    {
    //        detail = value;
    //        init();
    //    }
    //}

    //public int Seed
    //{
    //    get { return seed; }
    //    set
    //    {
    //        seed = value;
    //        init();
    //    }
    //}

    //public genType TypeGen
    //{
    //    get { return type; }
    //    set
    //    {
    //        type = value;
    //        init();
    //    }
    //}

    public ProceduralTerrain(float minHeight, float maxHeight, int size, float detail, int seed, genType type)
    {
        Debug.Log("Constructor of the world is called");

        this.minimumHeight = minHeight;
        this.maxHeight = maxHeight;
        this.size = size;
        this.detail = detail;
        this.seed = seed;
        this.type = type;
    }

    public void init()
    {
        procedulManager.instance.Regenerate.AddListener(Regenerate);
        Regenerate();
    }

    public void Regenerate()
    {
        heights = new float[size, size];
        procedulManager.instance.setSeed(seed);
        generate();
    }

    public void generate()
    {
        for (int x = 0; x < heights.GetLength(dimension: 0); x++)
        {
            for (int z = 0; z < heights.GetLength(dimension: 0); z++)
            {
                float height = 0;

                switch (type)
                {
                    case genType.RandomBased:
                        height = UnityEngine.Random.Range(minimumHeight, maxHeight);
                        break;

                    case genType.PerlinBased:
                        float perlinX = x / detail + procedulManager.instance.GetPerlinSeed();
                        float perlinY = z / detail + procedulManager.instance.GetPerlinSeed();

                        height = (Mathf.PerlinNoise(perlinX, perlinY) - minimumHeight) * maxHeight;
                        break;

                    case genType.sinBased:
                        height = UnityEngine.Mathf.Sin(Mathf.DeltaAngle(x,z) / detail);
                        //height = UnityEngine.Mathf.Sin(x);
                        break;

                        //Calculations that were made for fun. The test cases aren't made for serious purposes
                    case genType.TEST1:
                        height = UnityEngine.Mathf.Sin(maxHeight - z * detail / x);
                        break;

                    case genType.TEST2:
                        height = UnityEngine.Mathf.Sin(maxHeight - z * x);
                        break;
                    case genType.TEST3:
                        height = Mathf.DeltaAngle(detail / maxHeight, Mathf.DeltaAngle(z,x));
                        break;

                }

                heights[x, z] = height;

                /*Vector3 posz = new Vector3(x, Mathf.Floor(r), z) + transform.position;
                GameObject spawnCube = Instantiate(prefab, transform.position + posz, Quaternion.identity, transform);

                float height = 1 - spawnCube.transform.position.y / maxHeight;
                spawnCube.GetComponent<MeshRenderer>().material.color = new Color(height, height, height);*/
            }
        }
        Debug.Log("World Generated");
    }
}
