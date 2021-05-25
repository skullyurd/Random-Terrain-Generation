using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Landscape : MonoBehaviour
{
    private void Start()
    {
        init();
    }

    protected private void init()
    {
        procedulManager.instance.Regenerate.AddListener(generate);
        generate();
    }

    public virtual void clean()
    {


    }

    public virtual void generate()
    {
        Debug.Log("this should not display EVAH");
    }
}
