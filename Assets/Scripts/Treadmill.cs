using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    [SerializeField]
    bool isTurn;
    [SerializeField]
    int direction; //L=0, N=1, O=2, S=3
    [SerializeField]
    bool isSwitchable;
    SpriteRenderer treadmillSprite;


    void Start(){
        treadmillSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTurn) {
            MaterialMovement mm = other.GetComponent<MaterialMovement>();
            if(mm != null){
                StartCoroutine(ChangeDirection(mm));
            }
        }
    }

    IEnumerator ChangeDirection(MaterialMovement mm){
        yield return new WaitForSeconds(0.25f);
        mm.direction = direction;
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && isTurn && isSwitchable){
            treadmillSprite.flipY = !treadmillSprite.flipY;
            direction = (direction+2)%4;
        }
    }

}
