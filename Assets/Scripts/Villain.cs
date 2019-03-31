using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Villain : MonoBehaviour
{   
    [SerializeField] private float maxRageLevel;
    public static float rageLevel;


    void Update()
    {
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
