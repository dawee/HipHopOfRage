﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollide : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;
    private bool isHitting = false;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Activate() {
        if(!isHitting) {
            isHitting = true;
            gameObject.SetActive(true);
            StartCoroutine(WaitForHit());
        }
        
    }

    IEnumerator WaitForHit()
    {
        yield return new WaitForSeconds(0.4F);

        isHitting = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
