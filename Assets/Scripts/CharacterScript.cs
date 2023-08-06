using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Animator myAnim;
    public float horizontalSpeed;
    public float damageMin;
    public float damageMax;
    public float damage;
    [SerializeField] float health, maxHealth;
    [SerializeField] ProgressBar healthBar;
    [SerializeField] GameObject canvasObject;  

    public bool isAttacking = false;
    public static CharacterScript instance;

    float HInput;
    float VInput;
    Vector2 moveDirection;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
        healthBar = canvasObject.GetComponentInChildren<ProgressBar>();
    }
    void Start()
    {
        damage = Mathf.Round(Random.Range(damageMin, damageMax)); 
    }

    // Update is called once per frame
    void Update()
    {

        HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");
        myAnim.SetFloat("Walk", moveDirection.sqrMagnitude);

        //sets gameObject local scale so that it faces the right direction when moving.
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(HandleIt());                 
        }
    
    }

    void FixedUpdate()
    {
        moveDirection = new Vector2(HInput, VInput);
        moveDirection *= horizontalSpeed * Time.fixedDeltaTime;
        transform.position += transform.TransformDirection(moveDirection);
    }

    void OnTriggerEnter2D(Collider2D hitBox)
    {
        damage = Mathf.Round(Random.Range(damageMin, damageMax));

        if(hitBox.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent) && hitBox.gameObject.tag != "AttackCollider")
        {
            enemyComponent.TakeDamage(damage);
            SoundMaster.me.PlaySound (Random.Range (0, 2));
            SoundMaster.me.PlaySound (4);
        }
    }

     void OnCollisionEnter2D(Collision2D hit){
       if(hit.gameObject.tag == "WallCollider"){
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       }
    } 

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealth(health, maxHealth);
        myAnim.Play("Knight_Hit");
    }

private IEnumerator HandleIt()
{  
    // process pre-yield
    horizontalSpeed = 0f;
    isAttacking = true;
    damage = Mathf.Round (Random.Range (damageMin, damageMax));     
    yield return new WaitForSeconds( 0.5f );
    // process post-yield
    horizontalSpeed = 2.5f; 
}
}
