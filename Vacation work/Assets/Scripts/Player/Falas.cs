using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Falas : MonoBehaviour
{
    public float timer;
    public Text texto;
    
    public Canvas canv;

    private void Update() {

        canv.transform.eulerAngles = Vector3.zero;

        if(timer > 0)     
        {
            texto.enabled = true;
            timer -= Time.deltaTime;
        }
        else texto.enabled = false;
        
    }




}
