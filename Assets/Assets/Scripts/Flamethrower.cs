using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public int flammenDuration;
    private float flammenTimer;
    private bool isFlammen;
    public float miniDuration;
    private float miniTimer;
    public GameObject fogo;

    // Start is called before the first frame update
    void Start()
    {
        flammenTimer = flammenDuration;
        miniTimer = miniDuration;
        isFlammen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlammen == true)
        {
            flammenTimer -= Time.deltaTime;

            if (flammenTimer <= 0)
            {
                fogo.SetActive(false);
                flammenTimer = flammenDuration;
                isFlammen = false;
            }
        }

        else if (isFlammen == false)
        {
            flammenTimer -= Time.deltaTime;

            if (flammenTimer <= 0)
            {
                fogo.SetActive(true);
                flammenTimer = flammenDuration;
                isFlammen = true;
            }
        }
    }
}
