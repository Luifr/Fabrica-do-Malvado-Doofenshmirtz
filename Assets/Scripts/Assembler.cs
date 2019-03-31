﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Assembler : MonoBehaviour
{   
    [System.Serializable]
    private class Material
    {
        public int quantityNeeded;
        public int quantityCollected;
        public string name;
    }


    [SerializeField] private Material[] materialCheckList;
    private bool collectedSomething;
    [SerializeField] private float rageIncreased;
    [SerializeField] private Text[] checkList;


     

    void Start()
    {
        // trashEvent = TrashListener;
        
    }

    void Update()
    {
     
            UpdateText();
        
    }

    void TrashListener(string materialTag){
        
    }


    void UpdateText()
    {
        int i = 0;
        foreach(Material material in materialCheckList)
        {
            checkList[i].text = material.name + ": " + material.quantityCollected + "/" + material.quantityNeeded;
            i+=1; 
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        
        foreach (Material material in materialCheckList)
        {   
            if((material.name == other.gameObject.tag) && (material.quantityNeeded > material.quantityCollected))
            {
                material.quantityCollected += 1;
                collectedSomething = true;  
            }
        }
        if(!collectedSomething)
        {
            Villain.rageLevel += rageIncreased;
        }

        collectedSomething = false;
        GameObject.Destroy(other.gameObject);
    }
}
