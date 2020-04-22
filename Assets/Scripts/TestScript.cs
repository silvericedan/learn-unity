using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int hitpoints = 500;
    //todo lo que declares publico se ve en el inspector
    private int experiencia;
    // lo privado queda escondido del inspector
    public string clase;
    //se pueden declarar todo tipo de variables, array, listas, 
    //por ejemplo podes hacer un array de objetos y en inspector arrastrarlos todos.

    public GameObject cubo;
    private Transform referenciaTransformCubo;
    
    // Start is called before the first frame update
    void Start()
    {
        clase = "Fighter";
        hitpoints = 300;

        referenciaTransformCubo = cubo.GetComponent<Transform>();
        //esta es la forma correcta de acceder a un componente, sea transform, audio, rigidbody, lo que sea
        //normalmente para tener una referencia permanente, la tenes que tomar aca en el start, tambien se puede
        //referenciar en otras partes del codigo, pero tiene otras implicancias.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            moveteArribaCubo();
        }

    }


    public void moveteArribaCubo()
    {
        referenciaTransformCubo.position += Vector3.up * 1.0F;
    }

}

    
    
