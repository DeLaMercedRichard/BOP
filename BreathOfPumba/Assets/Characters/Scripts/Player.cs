using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    [SerializeField] float BaseMovementSpeed = 10f;
    [SerializeField] GameObject[] weapons;  // By BN
    //[SerializeField] Camera MyCamera;  // Commented out by Blawnode
    //[SerializeField] Transform weapon;  // Commented out by Blawnode
    public Vector2 MousePosition;
    public Vector2 Movement;
    public Rigidbody2D Rigidb;
    public Rigidbody2D GunRigidb;

    [SerializeField]
    SFXControl sfx;
    public bool IsSlow = false;
    public float SlowTime = 3f;
    public float SlowAmount = 5f;
    public bool isEnteringBattle, isLeavingBattle;
    
    public bool IsRooted = false;
    public float RootTime = 2f;
    public float RootAmount = 10f;


    //public float SpeedBoost = 10f;
    public float SpeedBoost = 1.2f;
    public float SpeedBoostdurration = 3f;

    public float DamageModifier = 1.5f;  // used by the weapons
    public float CurrentDamageModifier = 1.5f;  // used by the weapons

    private bool DidReachedGoal = false;  // By Blawnode

    Animator animator;  // By Blawnode

    void Start()
    {
        animator = GetComponent<Animator>();  // By Blawnode
        if (sfx == null)
            sfx = GetComponent<SFXControl>();
    }
    
    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        //if there's movement play stepping sound
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            sfx.PlaySound("Player - Step");
        }
        //MousePosition = MyCamera.ScreenToWorldPoint(Input.mousePosition);  // Commented out by Blawnode
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // By Blawnode
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

    public void Slow()
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

    public void Root()
    {
        if (IsRooted == false)
        {
            IsRooted = true;
            StartCoroutine(RootPlayer());
        }
        else
        {
            Debug.Log("Already Rooted");
        }
    }

    IEnumerator RootPlayer()
    {
        MovementSpeed -= RootAmount;
        yield return new WaitForSeconds(RootTime);
        MovementSpeed += SlowAmount;
        IsRooted = false;
    }

    public void SpeedUp(GameObject other)
    {
        if(MovementSpeed >= BaseMovementSpeed)
        {
            StartCoroutine(ISpeedUp(other));
        }
    }

    IEnumerator ISpeedUp(GameObject other)
    {
        other.GetComponent<PickUpScript>().GetPickedUp(gameObject);
        MovementSpeed += SpeedBoost;
        yield return new WaitForSeconds(SpeedBoostdurration);
        MovementSpeed -= SpeedBoost;
    }
    
    public void DamageUp(GameObject other)
    {
        if(MovementSpeed >= BaseMovementSpeed)
        {
            StartCoroutine(IDamageUp(other));
        }
    }

    IEnumerator IDamageUp(GameObject other)
    {
        other.GetComponent<PickUpScript>().GetPickedUp(gameObject);
        CurrentDamageModifier = DamageModifier;
        yield return new WaitForSeconds(SpeedBoostdurration);
        CurrentDamageModifier = 1;
    }

    public void AmmoUp(GameObject other)
    {
        foreach(GameObject weapon in weapons)
        {
            if(weapon.TryGetComponent<Weapon1>(out Weapon1 script1))
            {
                script1.AmmoBoost();
            }
            else if (weapon.TryGetComponent<Weapon2>(out Weapon2 script2))
            {
                script2.AmmoBoost();
            }
            else if(weapon.TryGetComponent<Weapon3>(out Weapon3 script3))
            {
                script3.AmmoBoost();
            }
            else if (weapon.TryGetComponent<Weapon4>(out Weapon4 script4))
            {
                script4.AmmoBoost();
            }
        }
        other.GetComponent<PickUpScript>().GetPickedUp(gameObject);
        //GetComponent<PlayerHealth>().Heal(other.GetComponent<PickUpScript>());
    }

    public void Heal(GameObject other)
    {
        GetComponent<PlayerHealth>().Heal(other.GetComponent<PickUpScript>());
    }

    // By Blawnode
    public void ReachedGoal()
    {
        if(!DidReachedGoal)
        {
            print("AYYYYYYY");
            // Finish game/Go to next level/Go to level select screen
        }
    }
}
