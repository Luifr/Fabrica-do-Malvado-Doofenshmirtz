using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Villain : MonoBehaviour
{   
    [SerializeField] private float maxRageLevel;
    public static float rageLevel;
    [SerializeField] private Animator anim;
    AssemblerManager assemblers;

    void Start()
    {
        assemblers = GameObject.Find("Assemblers").GetComponent<AssemblerManager>();
        anim  = GetComponent<Animator>();
        StartCoroutine(CheckWin());
    }
    void Update()
    {
        
        anim.SetFloat("rageLevel", rageLevel);
        if(rageLevel >= maxRageLevel)
        {
            DestroyFactory();
        }
    }

    void DestroyFactory()
    {
        //print("APOCALIPSE!!");
    }

    IEnumerator CheckWin(){
        while(1){
            yield return new WaitForSeconds(1f);
            if(assemblers.Done()){
                //win
            }
        }
    }

}
