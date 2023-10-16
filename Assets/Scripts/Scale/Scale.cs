using System.Transactions;
using Microsoft.Win32.SafeHandles;
using System.Numerics;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        UnityEngine.Vector3 tempScale = transform.localScale;
        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;
        
        float dai = Camera.main.orthographicSize * 2f;
        float rong = dai * Screen.width/Screen.height;  

        tempScale.y = dai / height;
        tempScale.x = rong / width;

        transform.localScale = tempScale;  
        // transform.localScale = new UnityEngine.Vector3(rong, dai, 0);    
    }

}
