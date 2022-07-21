using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public shootSphere knopka;
    public GameObject sphereInside;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Pushka")
        {
            int newLayer = LayerMask.NameToLayer("mySphere");
            gameObject.layer = newLayer;

            if (collision.transform.parent.parent.GetComponent<Animator>().enabled == true)
                collision.transform.parent.parent.GetComponent<Animator>().Play("Animation");
            else
                sphereInside.SetActive(true);


            knopka.isCharged = true;
            gameObject.SetActive(false);
        }
        else
        {
            int newLayer = LayerMask.NameToLayer("Default");
            gameObject.layer = newLayer;
        }
    }
}
