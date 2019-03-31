using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
