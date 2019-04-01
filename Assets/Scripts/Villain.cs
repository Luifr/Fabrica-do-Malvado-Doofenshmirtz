using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Villain : MonoBehaviour
{   
    [SerializeField] private float maxRageLevel;
    public static float rageLevel;
    private Animator anim;
    AssemblerManager assemblers;
    Text rage;

    void Start()
    {
        rage = GameObject.Find("Rage").GetComponent<Text>();
        assemblers = GameObject.Find("Assemblers").GetComponent<AssemblerManager>();
        anim  = GetComponent<Animator>();
        StartCoroutine(CheckWin());
    }
    void Update()
    {
        rage.text = rageLevel.ToString();
        anim.SetFloat("rageLevel", rageLevel);
        if(rageLevel >= maxRageLevel)
        {
            DestroyFactory();
        }
    }

    void DestroyFactory()
    {
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator CheckWin(){
        while(true){
            yield return new WaitForSeconds(1f);
            if(assemblers.Done()){
                SceneManager.LoadScene("Victory");
            }
        }
    }

}
