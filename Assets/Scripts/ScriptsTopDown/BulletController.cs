using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

	// Se ejecuta cuando el objeto queda fuera de la vista de cualquier cámara
    void OnBecameInvisible()
    {
    	// Destruir el game object si el objeto queda fuera de la cámara
    	Debug.Log("bala fuera de la pantalla, se eliminará");
    	Destroy(gameObject);
    }
}
