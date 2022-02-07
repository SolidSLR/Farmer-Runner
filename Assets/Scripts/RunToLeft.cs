using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToLeft : MonoBehaviour
{

    public float speed;

    private Master master;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("Master").GetComponent<Master>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!master.gameOver){
        transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
    }
}
