﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        float minYPos = -Camera.main.orthographicSize;
        //if obstacle leaves game area, destroy it
        if (transform.position.y < minYPos - transform.localScale.y){
            Destroy(gameObject);
        }
    }
}
