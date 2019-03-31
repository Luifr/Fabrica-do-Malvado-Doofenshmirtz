using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Villain : MonoBehaviour
{   
    [SerializeField] private float maxRageLevel;
    public static float rageLevel;
    [SerializeField] private Animator anim;

    void Start()
    {
        anim  = GetComponent<Animator>();
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
        print("APOCALIPSE!!");
    }
}
