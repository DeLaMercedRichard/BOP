using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;

    Animator animator;  // By Blawnode

    void Start()
    {
        animator = GetComponent<Animator>();  // By Blawnode
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();

        
    }

    
    private void PlayerMovement()
    { 
        //Vorizontal Player Movement Input

        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
        var NewPosX = transform.position.x + horizontalInput;
        transform.position = new Vector2(NewPosX, transform.position.y);

        //Vertical player Movement Input

        var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
        var NewPosY = transform.position.y + verticalInput;
        transform.position = new Vector2(transform.position.x ,NewPosY);

        animator.SetBool("IsRunning", (horizontalInput != 0 || verticalInput != 0));  // By Blawnode
    }
   

}
