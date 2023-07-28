using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Zombie : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;
    public Animator animator;
    public Slider enemyHealthBar;
    


    // Start is called before the first frame update
    void Start()
    {
        
        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(),GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.45f, 0.45f);
        }
        else
        {
            transform.localScale = new Vector2(-0.45f, 0.45f);

        }
    }
    public void TakeDamege(int damageAmount)
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;

        if(enemyHP > 0)
        {
            animator.SetTrigger("damage");
           
        }
        else
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            boxCollider.tag = "Untagged";
            boxCollider.isTrigger = true;

        }
    }
}
