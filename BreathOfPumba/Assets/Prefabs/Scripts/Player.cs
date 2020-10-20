using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    [SerializeField] Camera MyCamera;
    [SerializeField] Transform weapon;
    public Vector2 MousePosition;
    public Vector2 Movement;
    public Rigidbody2D Rigidb;
    public Rigidbody2D GunRigidb;
    public bool IsSlow = false;
    public float SlowTime = 3f;
    public float SlowAmount = 5f;

    Animator animator;  // By Blawnode

    void Start()
    {
        animator = GetComponent<Animator>();  // By Blawnode
    }
    
    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        MousePosition = MyCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {

        Rigidb.MovePosition(Rigidb.position + Movement * MovementSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = MousePosition - GunRigidb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        GunRigidb.rotation = angle;
        


        Vector2 angleVector = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right);  // By Blawnode, https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
        if (System.Math.Abs(-angleVector.x) > 0.01) animator.SetFloat("Horizontal", angleVector.x);  // By Blawnode
        if (System.Math.Abs(-angleVector.y) > 0.01) animator.SetFloat("Vertical", angleVector.y);  // By Blawnode
    }


    private void PlayerMovement()//alternative way of movment (feels different)
    { 
        //Horizontal Player Movement Input

        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
        var NewPosX = transform.position.x + horizontalInput;
        transform.position = new Vector2(NewPosX, transform.position.y);

        //Vertical player Movement Input

        var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
        var NewPosY = transform.position.y + verticalInput;
        transform.position = new Vector2(transform.position.x ,NewPosY);

        animator.SetBool("IsRunning", (horizontalInput != 0 || verticalInput != 0));  // By Blawnode
    }

  private void Slow()
    {
        if(IsSlow == false)
        {
            IsSlow = true;
            StartCoroutine(SlowPlayer());

        }
        else 
        { 
        
            Debug.Log("Already Slowed");
            
        }
    }

    IEnumerator SlowPlayer()
    {
        MovementSpeed -= SlowAmount;
        yield return new WaitForSeconds(SlowTime);
        MovementSpeed += SlowAmount;
        IsSlow = false;

            
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SlowBullet")
        {
            Slow();

        }
    }

}
