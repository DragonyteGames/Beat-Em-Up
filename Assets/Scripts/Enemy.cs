using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Animator myAnim;
    public float speed;
    public float scaleX;
	public float scaleY;
    public float  particleHeight;
    public bool enemyDead;
    public bool isHit;
    public GameObject myPlayer;
    public float damageMin;
    public float damageMax;
    public GameObject textDamage;
    public Transform damagePoint;
    
    [SerializeField] float damage; 
    [SerializeField] float health, maxHealth;
    [SerializeField] ProgressBar healthBar;
    [SerializeField] GameObject canvasObject; 
    [SerializeField] Transform target;
    [SerializeField] NavMeshAgent agent;
    
    void Awake()
    {
        healthBar = canvasObject.GetComponentInChildren<ProgressBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyDead = false;
        isHit = false;
        damage = Mathf.Round(Random.Range(damageMin, damageMax));
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void FixedUpdate(){

        //check if health is above zero. Otherwise, enemy is dead.
        if(health >= 0)
        {
            enemyDead = false;
        }else if(health < 0)
        {
            enemyDead = true;
            myAnim.SetBool("Fainted", true);
            GetComponent<Collider2D>().enabled = false;
            agent.enabled = false;
            canvasObject.SetActive(false);
        }
        
       
        if(!enemyDead && !isHit)
        {
            agent.SetDestination(target.position);
            myAnim.SetBool("Walk", true);
            agent.isStopped = false;

            if((agent.remainingDistance <=2.0f)){
                if(transform.position.x >= target.transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x+1.9f, target.transform.position.y), agent.speed*Time.fixedDeltaTime);
                    agent.isStopped = false;
                    myAnim.SetBool("Walk", true);
                }else if(transform.position.x < target.transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x-2.0f, target.transform.position.y), agent.speed*Time.fixedDeltaTime);
                    myAnim.SetBool("Walk", true);
                    agent.isStopped = false;
                }

                if(Mathf.Abs(transform.position.y - target.transform.position.y) <= 0.5f){
                    myAnim.SetBool("Walk", false);
                    myAnim.SetTrigger("Attack1");
                    agent.isStopped = true;
                }
            }

			if (myPlayer.transform.position.x >= transform.position.x) 
            {
				transform.localScale =	new Vector2 (-scaleX, scaleY);		
			} else if (myPlayer.transform.position.x < transform.position.x) {
				transform.localScale =	new Vector2 (scaleX, scaleY);
			}            
        }

    }

    //public function to take damage on health based on player damage amount
    public void TakeDamage(float damageAmount)
    {
        if(!enemyDead){
            health -= damageAmount;
            healthBar.UpdateHealth(health, maxHealth);
            StartCoroutine ("GotHit");
            //damage text float
            textDamage.GetComponentInChildren<TextMeshProUGUI>().text = damageAmount.ToString();
            (Instantiate (textDamage, new Vector3(damagePoint.position.x, damagePoint.position.y, damagePoint.position.z), Quaternion.identity) as GameObject).transform.parent = canvasObject.transform;
            //particle effect and positioning
            for(int i = 0; i < GlobalScript.hitParticle.Length; i++)
            {
                GlobalScript.hitParticle [i].GetComponent<ParticleSystem> ().Play ();
                GlobalScript.bloodParticle [i].GetComponent<ParticleSystem> ().Play ();
                GlobalScript.hitParticle [i].GetComponent<Transform> ().transform.position = new Vector2 (transform.position.x, transform.position.y + particleHeight);
                GlobalScript.bloodParticle [i].GetComponent<Transform> ().transform.position = new Vector2 (transform.position.x, transform.position.y + particleHeight);
            }
        }

    }

    IEnumerator GotHit(){
        isHit = true;
        myAnim.Play("Enemy_Hit");
        yield return new WaitForEndOfFrame();
        isHit = false;
    }

    //Trigger to hit player
    void OnTriggerEnter2D(Collider2D hitBox)
    {
        damage = Mathf.Round(Random.Range(damageMin, damageMax));

        if(hitBox.gameObject.TryGetComponent<CharacterScript>(out CharacterScript playerComponent) && hitBox.gameObject.tag != "AttackCollider")
        {
            playerComponent.TakeDamage(damage);
            SoundMaster.me.PlaySound (Random.Range (0, 2));
            SoundMaster.me.PlaySound (4);
        }
    }
    
}
