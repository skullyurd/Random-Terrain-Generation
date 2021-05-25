using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class procedulManager : MonoBehaviour
{
    private int seed;
    private float perlinSeed;

    public static procedulManager instance;
    public ProceduralTerrain terrain;
    public UnityEvent Regenerate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Regenerate = new UnityEvent();
        terrain.init();
    }

    private void OnValidate()
    {
        if (instance != null)
        {
            Regenerate.Invoke();
        }
    }

    public void setSeed(int seed)
    {
        this.seed = seed;
        Random.InitState(seed);
        perlinSeed = Random.Range(-100000, 100000);
    }

    public float GetPerlinSeed()
    {
        return perlinSeed;
    }
}
