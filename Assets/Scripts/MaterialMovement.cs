using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMovement : MonoBehaviour
{
    public float speed;
    public int direction;
    
    float[] dirX = {1f,0f,-1f,0f,0f};
    float[] dirY = {0f,1f,0f,-1f,0f};
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3( dirX[direction], dirY[direction], 0) * speed * Time.deltaTime;
    }

    public void Initialize(int rotationAngle, float initialSpeed) 
    {
        direction = rotationAngle;
        speed = initialSpeed;
    }
}
