﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public Manager manager;
    DestroyerE swarm;
    public Transform target;
    const float limite = 5f;
    public bool engage = true;
    private int j;

    IEnumerator DirChange()
    {
        yield return new WaitForSeconds(5);
        engage = true;
    }
	// Use this for initialization
	void Start ()
    {
        swarm.DestSpeed = 15f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if((transform.position - target.transform.position).magnitude <= 5 & engage)
        {
            engage = false;
            j = Random.Range(0, 9);
            StartCoroutine(DirChange());
        }
        Trayect();
        
	}

    public void Trayect()
    {
        if (engage)
        {
            transform.LookAt(target.transform);
            transform.Translate(0.0f, 0.0f, swarm.DestSpeed * Time.deltaTime);
        }
        else
        {
            
            transform.RotateAround(manager.orbits[j].transform.position, Vector3.forward, swarm.DestSpeed * Time.deltaTime);
            
        }
    }
}
