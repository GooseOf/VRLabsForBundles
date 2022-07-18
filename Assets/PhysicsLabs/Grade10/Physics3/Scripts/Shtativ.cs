using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shtativ : MonoBehaviour
{
    //[SerializeField] private Transform lapka;
    //[SerializeField] private Transform lapkaSocket;
    public Lapka LapkaGO { get; set; }

    public bool AcceptLapka { get; set; }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(LapkaGO == null && AcceptLapka)
        {
            if(other.TryGetComponent<Lapka>(out Lapka lapka))
            {
                LapkaEntered(lapka);
            }
        }
    }
    private void LapkaEntered(Lapka lapka)
    {
        //lapka.position = lapkaSocket.position;
        //lapka.rotation = lapkaSocket.rotation;
    }

}
