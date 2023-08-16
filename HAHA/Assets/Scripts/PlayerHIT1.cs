using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHIT1 : MonoBehaviour
{
    float delayInSeconds = 1f;
    public int damage = 5;
    public EnemyAI enemyAI; 
    private bool canHit = true;
    public Camera fpscam;
    public float playerRange;

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && canHit)
        {
            RaycastHit hit;
            animator.SetTrigger("Attack Enemy");
            if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, playerRange))
            {
                
                if (hit.collider.CompareTag("Enemy"))
                {

                    enemyAI.TakeDamage(damage);
                
                }
            
            
            }
            
            
            
            
            canHit = false;
            StartCoroutine(EnableHitAfterDelay());
            animator.SetTrigger("Reset Animation");
        
            
        
        }
    }

    IEnumerator EnableHitAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canHit = true;
    }

}
