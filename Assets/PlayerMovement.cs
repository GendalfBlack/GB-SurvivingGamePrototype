using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Animator animatior;
    public float playerSpeed = 5f; 
    public float playerRunSpeed = 1.3f;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animatior = gameObject.GetComponent<Animator>();
    }
        
    void Update()
    {
        float dX_Press = Input.GetAxis("Horizontal");
        float dY_Press = Input.GetAxis("Vertical");
        animatior.SetFloat("dX", dX_Press);
        animatior.SetFloat("dY", dY_Press);
        float run_modifier = Input.GetKey(KeyCode.LeftShift) ? playerRunSpeed : 1;
        if (dX_Press != 0) {
            controller.Move(
                new Vector3(
                    playerSpeed * Time.deltaTime * dX_Press * run_modifier,
                    0,
                    -playerSpeed * Time.deltaTime * dX_Press * run_modifier
                ));
        } 
        if(dY_Press != 0) {
            controller.Move(
                new Vector3(
                    playerSpeed * Time.deltaTime * dY_Press * run_modifier,
                    0,
                    playerSpeed * Time.deltaTime * dY_Press * run_modifier
                ));
        }
    }
}
