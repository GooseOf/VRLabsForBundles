using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphere : MonoBehaviour
{
    public shootSphere knopka;
    public GameObject sphereInside;
    public tipsManager _tipsManager;
    public tableFiller _tableFiller;

    public LineRenderer lineRenderer;
    public Canvas canvas;
    public Text distanceTxt;

    public bool shooted;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Pushka")
        {
            shooted = false;
            lineRenderer.positionCount = 0;
            canvas.gameObject.SetActive(false);

            int newLayer = LayerMask.NameToLayer("mySphere");
            gameObject.layer = newLayer;

            if (collision.transform.parent.parent.GetComponent<Animator>().enabled == true)
            {
                collision.transform.parent.parent.GetComponent<Animator>().Play("Animation");
                collision.transform.parent.parent.GetComponent<AudioSource>().Play();
            }
            else
                sphereInside.SetActive(true);


            knopka.isCharged = true;
            gameObject.SetActive(false);

            if (_tipsManager.currentTip == 1)
                _tipsManager.nextTip();

        }
        else if(shooted)
        {
            int newLayer = LayerMask.NameToLayer("Default");
            gameObject.layer = newLayer;

            Vector3 startPos = sphereInside.transform.position;
            Vector3 endPos = transform.position;
            startPos.y = endPos.y;

            Vector3 canvasPos = Vector3.Lerp(startPos, endPos, 0.5f);
            canvas.transform.position = canvasPos;
            canvas.gameObject.SetActive(true);

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);

            float distance = Vector3.Distance(startPos, endPos);
            distanceTxt.text = distance.ToString("F2");
            _tableFiller.setDistance(distance);

            shooted = false;
        }
    }
}
