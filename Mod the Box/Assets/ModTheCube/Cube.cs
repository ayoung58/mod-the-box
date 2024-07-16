using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public enum Directions {
        xAxis,
        yAxis,
        zAxis
    };
    public Directions direction = Directions.xAxis;
    public float changeInterval = 3.0f;
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        InvokeRepeating("changeDirection", 2.0f, changeInterval);
    }
    
    void Update()
    {   
        // resetDirections();
        rotation();
    }

    void changeDirection() {
        int directionCode = Random.Range(0, 3);
        if (directionCode == 0) {
            direction = Directions.xAxis;
        } else if (directionCode == 1) {
            direction = Directions.yAxis;
        } else if (directionCode == 2) {
            direction = Directions.zAxis;
        }
    }

    void rotation() {
        if (direction == Directions.xAxis) {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        } else if (direction == Directions.yAxis) {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        } else if (direction == Directions.zAxis) {
            transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
        }
    }
}
