using System;
using UnityEngine;
using System.Collections;
public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Finish")
        {
            PlayerManager.ResetPosition();
            LevelManager.NextLevel();
        }
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Enemy2" || collision.transform.tag == "Zombie")
        {
  
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }

        }

        if (collision.transform.tag == "DeadZone")
        {

            HealthManager.health -= 3;
            if (HealthManager.health <= 0)
            {
                Physics2D.IgnoreLayerCollision(6, 8, false);
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
   

}
