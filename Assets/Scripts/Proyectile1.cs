using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Proyectile1 : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private Material shaderMaterial;
    public static event Action<Material> instantiatedProjectil;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
        UpdateMaterialColor(); 
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        UpdateMaterialColor();
        float angle = Mathf.Atan2(myRB.velocity.y, myRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void UpdateMaterialColor()
    {
        //shaderMaterial.SetColor("_MainColor", Random.ColorHSV());
        Material newMaterial = new Material(shaderMaterial);
        GetComponent<Renderer>().material = newMaterial; 
        instantiatedProjectil?.Invoke(newMaterial);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
