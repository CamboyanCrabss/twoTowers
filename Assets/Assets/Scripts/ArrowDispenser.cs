using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{
    public GameObject arrow;
    public float reload = 1f;
    private bool canShoot = false;


    void Start()
    {
        StartCoroutine(CorrutinaDisparo());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canShoot = true;
        }
    }


    private IEnumerator CorrutinaDisparo()
    {
        while (true)
        {
            yield return new WaitForSeconds(reload);
            if (canShoot)
            {
                Instantiate(arrow, transform.position, transform.rotation);
            }
        }
    }

}
