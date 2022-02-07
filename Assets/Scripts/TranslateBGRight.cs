using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateBGRight : MonoBehaviour
{

    private float translation;

    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {

        initialPosition = transform.position;

        GameObject bg = GameObject.Find("Background");
        
        translation = bg.GetComponent<BoxCollider>().size.x/2;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < initialPosition.x - translation){

            transform.position = initialPosition;

        }

    }
}
