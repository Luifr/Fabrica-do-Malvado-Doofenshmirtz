using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblerManager : MonoBehaviour
{
    // Start is called before the first frame update

    Assembler[] assemblers;

    void Start()
    {
        assemblers = gameObject.GetComponentsInChildren<Assembler>();

    }

    public bool MaterialNeeded(string material){
        for(int i=0;i<assemblers.Length;i++){
            if(assemblers[i].MaterialNeeded(material)){
                return true;
            }
        }
        return false;
    }
}
