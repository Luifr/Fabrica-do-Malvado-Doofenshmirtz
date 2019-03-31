using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Assembler : MonoBehaviour
{   
    

    [SerializeField] private Material[] materialCheckList;
    private bool collectedSomething;
    [SerializeField] private float rageIncreased;
    [SerializeField] private CheckListElem[] checkList;


    void Start()
    {
        initText();
    }

    void Update()
    {
        UpdateText();
    }

    void initText()
    {
        int i = 0;
        foreach(Material materil in materialCheckList)
        {
            checkList[i].spriteRenderer.sprite = checkList[i].image;
            i++;
        }
    }
    void UpdateText()
    {
        int i = 0;
        foreach(Material material in materialCheckList)
        {
            checkList[i].textObject.text = ": " + material.quantityCollected + "/" + material.quantityNeeded;
            i++;
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

    public bool MaterialNeeded(string mat){
        for(int i=0;i<materialCheckList.Length;i++){
            if(materialCheckList[i].name == mat && materialCheckList[i].quantityCollected == materialCheckList[i].quantityCollected){
                return true;
            }
        }
        return false;
    }

}
