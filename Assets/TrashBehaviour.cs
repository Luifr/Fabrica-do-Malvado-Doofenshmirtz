using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{
    
    [SerializeField]
    float scaleFactor;

    void OnTriggerEnter2D(Collider2D other){
        StartCoroutine(Vanish(other.gameObject));
    }

    IEnumerator Vanish(GameObject material){
        for(int i=0;i<10;i++){
            material.transform.localScale = new Vector3(material.transform.localScale.x*scaleFactor,material.transform.localScale.x*scaleFactor);
            yield return new WaitForSeconds(.1f);
        }
    }

}
