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
    public float rotationSpeedLower = 5.0f;
    public float rotationSpeedUpper = 15.0f;
    public float rColor = 0.5f;
    public float gColor = 1.0f;
    public float bColor = 0.3f;
    public float aColor = 0.4f;
    private Material material;
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;

        InvokeRepeating("changeDirectionAndSpeed", 2.0f, changeInterval);
        InvokeRepeating("changeColor", 2.0f, changeInterval);

    }
    
    void Update()
    {   
        // resetDirections();
        rotation();
    }

    void changeDirectionAndSpeed() {
        rotationSpeed = Random.Range(rotationSpeedLower, rotationSpeedUpper);
        int directionCode = Random.Range(0, 3);
        if (directionCode == 0) {
            direction = Directions.xAxis;
        } else if (directionCode == 1) {
            direction = Directions.yAxis;
        } else if (directionCode == 2) {
            direction = Directions.zAxis;
        }
    }

    void changeColor() {
        rColor = Random.Range(0.0f, 1.0f);
        bColor = Random.Range(0.0f, 1.0f);
        gColor = Random.Range(0.0f, 1.0f);
        aColor = Random.Range(0.0f, 1.0f);
        material.color = new Color(rColor, gColor, bColor, aColor);
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
