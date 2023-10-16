using System.Numerics;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdcontrol : MonoBehaviour
{
    public static  Birdcontrol input;

    public float fly;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip Fly, score, died;
 
 // using button;
    private bool isAlive;
    private bool didFlap;

    public float tam = 0;
    public int diem = 0;
    private GameObject spawner;
    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        Makeinput();
        spawner = GameObject.Find("spawnerpipe");
    }
    void Makeinput(){
        if (input == null)
        {
            input = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BirdMoveMent();
    }
    void BirdMoveMent(){
        // control bird using button
        if(isAlive == true){
            if(didFlap == true){
                didFlap = false;
            myBody.velocity = new UnityEngine.Vector2(myBody.velocity.x, fly);
            audioSource.PlayOneShot(Fly);
            }
        }
        // control bird using mouse and keyboard
        // if(UnityEngine.Input.GetMouseButtonDown(0)){
        //     myBody.velocity = new UnityEngine.Vector2(myBody.velocity.x, fly);
        //     audioSource.PlayOneShot(Fly);
        // }
        if(UnityEngine.Input.GetKeyDown("space")){
            myBody.velocity = new UnityEngine.Vector2(myBody.velocity.x, fly);
            audioSource.PlayOneShot(Fly);
        }
        // xoay bird 
        if(myBody.velocity.y > 0){
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y /7);
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, angel);
        }else if(myBody.velocity.y == 0)
        {
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0); 
        }else if(myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y /7);
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, angel);
        }
    }
    public void FlapButton(){
        didFlap = true;

    }
     void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Score")
        {
            diem++;
            if (GamePlayControler.input != null)
            {
            GamePlayControler.input.Setscore(diem);
            } 
            audioSource.PlayOneShot(score);
        }
    }
    private void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Floor" )
        {
            tam = 1;
            if (isAlive == true)
            {
            isAlive = false;
            Destroy(spawner);
            audioSource.PlayOneShot(died);
            anim.SetTrigger("Died");
            }
            if (GamePlayControler.input != null)
            {
                GamePlayControler.input.BirdDide(diem);
            }
        }
    }
}
