using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Assembler : MonoBehaviour
{   
    [System.Serializable]
    private class Material
    {
        public int quantityNeeded;
        public int quantityCollected;
        public string name;
    }
    public delegate void TrashEvent(string s);
    public TrashEvent trashEvent;

    [SerializeField] private Material[] materialCheckList;
    private bool collectedSomething;
     

    void Start(){
        trashEvent = TrashListener;
    }

    void TrashListener(string materialTag){
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        name  = other.gameObject.tag;
        foreach (Material material in materialCheckList)
        {
            Debug.Log(other.gameObject.tag);   
            if((material.name == other.gameObject.tag) && (material.quantityNeeded > material.quantityCollected))
            {
                material.quantityCollected += 1;
                collectedSomething = true;  
            }
        }
        if(!collectedSomething)
        {
            print("rage++");
        }
        collectedSomething = false;
        GameObject.Destroy(other.gameObject);
    }



}
