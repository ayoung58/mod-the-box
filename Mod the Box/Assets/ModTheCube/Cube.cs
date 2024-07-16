using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public bool xDirection = true;
    public bool yDirection = false;
    public bool zDirection = false;
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {   
        resetDirections();
        rotation();
    }

    void resetDirections() {
        if (xDirection) {
            yDirection = false;
            zDirection = false;
        } else if (yDirection) {
            xDirection = false;
            zDirection = false;
        } else if (zDirection) {
            xDirection = false;
            yDirection = false;
        }
    }

    void rotation() {
        if (xDirection) {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        } else if (yDirection) {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        } else if (zDirection) {
            transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
        }
    }
}
