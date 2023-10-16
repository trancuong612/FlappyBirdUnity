using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerpipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHoler;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawner(){
        yield return new WaitForSeconds(1); //time cho
        UnityEngine.Vector3 temp = pipeHoler.transform.position; // lay vi tri cua ong
        temp.y = UnityEngine.Random.Range(-2.75f,2.25f);
        Instantiate(pipeHoler, temp, UnityEngine.Quaternion.identity) ;
        // tao ra ban sao cua 1 doi tuong Instantiate(flie muon sing ra, tai vi tri x or y, xoay(UnityEngine.Quaternion.identity khong xoay))
        StartCoroutine(Spawner());
    }
}
