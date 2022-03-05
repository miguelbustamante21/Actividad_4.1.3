using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{
    [SerializeField] float force; //crea un field (valor)
    Rigidbody2D rb2D; //creas un componente de rigidbody para modificar
    Vector3 move; //creas otro componente para que se mueva

    // Start is called before the first frame update
    void Start() //función que se llama al iniciar el juego
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() //cada frame que pasa se actualiza y se llama a esta función 
    {
        //read user input from keyboard or gamepad
        move.x = Input.GetAxis("Horizontal") * force;
        move.y = Input.GetAxis("Vertical") * force;  

        rb2D.AddForce(move);
    }
}
