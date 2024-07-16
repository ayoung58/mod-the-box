﻿using System.Collections;
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
    public enum CubeMove {
        xAxis,
        yAxis,
        zAxis
    };
    public CubeMove cubeMove = CubeMove.xAxis;
    public float movementSpeed = 2.0f;
    public float movementSpeedLower = 1.0f;
    public float movementSpeedUpper = 3.0f;

    public float xLimit = 3.0f;
    public float yLimit = 3.0f;
    public float zLimit = 3.0f;
    
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;

        InvokeRepeating("changeDirectionAndSpeed", 2.0f, changeInterval);
        InvokeRepeating("changeColor", 2.0f, changeInterval);
        InvokeRepeating("changeMovement", 2.0f, changeInterval);

    }
    
    void Update()
    {   
        // resetDirections();
        rotation();
        moving();
    }

    void moving() {
        if (cubeMove == CubeMove.xAxis) {
            if (transform.position.x >= xLimit) {
                transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
            } else {
                transform.Translate(movementSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        } else if (cubeMove == CubeMove.yAxis) {
            if (transform.position.y >= yLimit) {
                transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
            } else {
                transform.Translate(0.0f, movementSpeed * Time.deltaTime, 0.0f);
            }
        } else if (cubeMove == CubeMove.zAxis) {
            if (transform.position.z >= zLimit) {
                transform.position = new Vector3(transform.position.x,transform.position.y, zLimit);
            } else {
                transform.Translate(0.0f, 0.0f, movementSpeed * Time.deltaTime);
            }
        }
    }

    void changeMovement() {
        movementSpeed = Random.Range(rotationSpeedLower, rotationSpeedUpper);
        int movementCode = Random.Range(0, 3);
        if (movementCode == 0) {
            cubeMove = CubeMove.xAxis;
        } else if (movementCode == 1) {
            cubeMove = CubeMove.yAxis;
        } else if (movementCode == 2) {
            cubeMove = CubeMove.zAxis;
        }
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
