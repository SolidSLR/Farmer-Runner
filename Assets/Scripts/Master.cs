using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{

    private Stack pivotePool;

    private ArrayList pivoteFifoPool;

    public enum PoolManagementMode {FIFO, LIFO};

    public PoolManagementMode managementMode;

    public GameObject prefabPivote;

    private Vector3 pivoteSpawn;

    public bool gameOver;
    // Start is called before the first frame update
    void Start(){

        if(managementMode == PoolManagementMode.LIFO){

            pivotePool = new Stack();

        }else {

            pivoteFifoPool = new ArrayList();

        }

        gameOver = false;

        pivoteSpawn = new Vector3(40,0,0);

        Instantiate(prefabPivote, pivoteSpawn, Quaternion.identity);

        StartCoroutine("pivoteSpawnCorut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator pivoteSpawnCorut(){

        float time;

        while(!gameOver){

            time = 1.0f + Random.Range(0.0f, 3.0f);

            yield return new WaitForSeconds(time);

            GameObject pivote = GetFromPull();

            if(pivote != null){

                Debug.Log("El spawn funciona");

                Instantiate(prefabPivote, pivoteSpawn, Quaternion.identity);

            } else if (pivotePool.Count>0){

                //GameObject pivote = (GameObject)pivotePool.Pop();

                pivote.transform.position = pivoteSpawn;
                pivote.transform.rotation = Quaternion.identity;
                pivote.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pivote.GetComponent<Rigidbody>().velocity = Vector3.zero;

                pivote.SetActive(true);
            }
        }
    }

    private GameObject GetFromPull(){
        GameObject pivote = null;

        // To Do: Buscar pivote

        if(managementMode == PoolManagementMode.LIFO){

            if(pivotePool.Count>0){

                pivote = (GameObject)pivotePool.Pop();

            }
        } else {

            if(pivoteFifoPool.Count > 0){

                pivote = (GameObject)pivoteFifoPool[0];

                pivoteFifoPool.RemoveAt(0);

            }
        }

        return pivote;
    }

    public void AddToPool(GameObject pivote){
        if(managementMode == PoolManagementMode.LIFO){
            pivotePool.Push(pivote);
        }else {
            pivoteFifoPool.Add(pivote);
        }
    }
}
