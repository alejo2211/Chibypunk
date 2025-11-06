using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{
    public float velocidad; 
    public Animator animator;
    void Update() 
    { Vector3 movimiento = Vector3.zero; 
        if (Input.GetKey(KeyCode.W))
        { movimiento.z = -1; }
        else if (Input.GetKey(KeyCode.S))
        { movimiento.z = 1; }
        if (Input.GetKey(KeyCode.D))
        { movimiento.x = -1; }
        else if (Input.GetKey(KeyCode.A)) 
        { movimiento.x = 1; } 
        transform.position = transform.position + velocidad * movimiento.normalized;
        if (movimiento != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, movimiento, Time.deltaTime * 20);
        }
        animator.SetFloat("Xspeed", movimiento.magnitude); 
        animator.SetFloat("Zspeed", movimiento.magnitude);
        animator.SetFloat("Yspeed", movimiento.magnitude); 
    }
}
