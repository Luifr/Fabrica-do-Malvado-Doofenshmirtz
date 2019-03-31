using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMachine : MonoBehaviour
{

    public int _direcao=0; //L=0, N=1, O=2, S=3
    public GameObject[] materiasPrima;
    public float initialSpeed;

    public float spawnTime = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            GameObject materiaPrima = materiasPrima[Random.Range(0,materiasPrima.Length)];

            materiaPrima = Instantiate(materiaPrima, new Vector3(transform.position.x, transform.position.y-.5f, -0.1f), transform.rotation);

            materiaPrima.GetComponent<MaterialMovement>().Initialize(_direcao, initialSpeed);
             
            yield return new WaitForSeconds(spawnTime);

        }
    }
}
