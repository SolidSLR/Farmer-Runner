using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotePool : MonoBehaviour
{

    private Master master;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("Master").GetComponent<Master>();
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.x < -100){
           //master.pivotePool.Push(gameObject);
           master.AddToPool(gameObject);
           gameObject.SetActive(false);
           Debug.Log("Se ha cargado un pivote en el Stack");
       }
    }
}