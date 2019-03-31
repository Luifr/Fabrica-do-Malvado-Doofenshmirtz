using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{
    
    [SerializeField]
    float scaleFactor=.1f;
    AssemblerManager assemblerManager;

    void Start(){
        assemblerManager = GameObject.Find("Assemblers").GetComponent<AssemblerManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
        StartCoroutine(ChangeDirection(other.gameObject.GetComponent<MaterialMovement>()));
        StartCoroutine(Vanish(other.gameObject.transform));
        Debug.Log(assemblerManager.MaterialNeeded(other.gameObject.tag));
    }

    IEnumerator ChangeDirection(MaterialMovement mm){
        yield return new WaitForSeconds(0.08f);
        mm.direction = 4;
    }

    IEnumerator Vanish(Transform material){
        for(int i=0;i<10;i++){
            material.localScale -= new Vector3(scaleFactor,scaleFactor,0);
            yield return new WaitForSeconds(.1f);
        }
        Destroy(material.gameObject);
    }

}
