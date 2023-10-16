using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour

{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Birdcontrol.input != null)
        {
            if (Birdcontrol.input.tam != 0)
            {
              Destroy(GetComponent<Pipe>());
            }
           
        } 
        PipeMovement();
    }
    void PipeMovement(){
        UnityEngine.Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Destroy")
        {
            Destroy (gameObject);
        }
    }
}
