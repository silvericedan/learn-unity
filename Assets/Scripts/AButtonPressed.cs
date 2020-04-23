using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AButtonPressed : MonoBehaviour
{
    //Esta clase registra los botones presionados y utiliza el patron Template Method para
    //especificar que accion realiza el boton segun lo que necesite el script que lo implemente

    public void PressUp()
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
        {
            UpPressed();
        }
    }

    public void PressDown()
    {
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
            DownPressed();
        }
    }

    public void PressLeft()
    {
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            LeftPressed();
        }
    }

    public void PressRight()
    {
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            RightPressed();
        }
    }

    public void PressSpace()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SpacePressed();
        }
    }

    public void PressMouseClick()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LeftClickPressed();
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            RightClickPressed();
        }
    }

    public void PressQER()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            QPressed();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            EPressed();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            RPressed();
        }
    }
    
    public void PressAlpha12345()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Alpha1Pressed();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Alpha2Pressed();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Alpha3Pressed();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Alpha4Pressed();
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            Alpha5Pressed();
        }
    }



    //La clase que herede de esta debera implementar estos metodos y definir su funcionalidad 
    public abstract void UpPressed(); 
    public abstract void DownPressed();
    public abstract void LeftPressed();
    public abstract void RightPressed();

    //No esta obligada a implementar estos metodos, pero estan disponibles para definirlos y usarlos
    public void SpacePressed() { } 
    public void LeftClickPressed() { }
    public void RightClickPressed() { }
    public void QPressed() { }
    public void EPressed() { }
    public void RPressed() { }
    public void Alpha1Pressed() { }
    public void Alpha2Pressed() { }
    public void Alpha3Pressed() { }
    public void Alpha4Pressed() { }
    public void Alpha5Pressed() { }

}
