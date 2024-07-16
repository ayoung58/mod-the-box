using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public int rotationDirection = 0;
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
        rotation();
    }

    void rotation() {
        if (rotationDirection == 0) {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        } else if (rotationDirection == 1) {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        } else if (rotationDirection == 2) {
            transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
        }
    }
}
