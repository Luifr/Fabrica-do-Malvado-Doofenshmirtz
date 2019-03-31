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
    [SerializeField]
    bool isUp;
    SpriteRenderer treadmillSprite;
    [SerializeField]
    Sprite changedState;
    public bool retaState=true;
    Animator animator;

    void Start(){
        treadmillSprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
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
        yield return new WaitForSeconds(0.13f);
        mm.direction = direction;
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && isSwitchable){
            if(gameObject.CompareTag("EsteiraReta")){
                retaState = !retaState;
                animator.SetBool("state",retaState);
                Sprite aux = treadmillSprite.sprite;
                treadmillSprite.sprite = changedState;
                changedState = aux;
                if(isUp){
                    direction = (direction+1)%2;
                }
                else{
                    treadmillSprite.flipY = !treadmillSprite.flipY;
                    direction = (3-direction);
                }
            }
            else if(isTurn){
                treadmillSprite.flipY = !treadmillSprite.flipY;
                direction = (direction+2)%4;
            }
        }
    }

}
