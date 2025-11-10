using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    private Animator anim;
    public float VidaMax = 5f;
    public float VidaNow = 5f;

    // Start is called before the first frame update
    void Start()
    {
        VidaNow = VidaMax;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (VidaNow <= 0) 
        {
            anim.SetBool("isDead", true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Danger"))
        {
            VidaNow--; 
        }
    }

    public void Dead()
    {  
        Destroy(gameObject); 
    }
}
