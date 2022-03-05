using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{
    [SerializeField] float force; //crea un field (valor)
    Rigidbody2D rb2D; //crea un componente de rigidbody para modificar
    Vector3 move; //crea otro componente para que se mueva

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //read user input from keyboard or gamepad
        move.x = Input.GetAxis("Horizontal") * force;
        move.y = Input.GetAxis("Vertical") * force;  

        rb2D.AddForce(move);
    }
}
