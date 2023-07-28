using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;

    public GameObject bullet;
    public Transform bulletHole;
    public float force=200;
    private void Awake()
    {
        controls=new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += Shoot;
    }
    private void OnDisable()
    {

        controls.Land.Shoot.performed -= Shoot;

    }
    private void Shoot(CallbackContext callbackContext)
    {
        Fire();
    }
    private void Fire()
    {
        animator.SetTrigger("shoot");
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        if (GetComponent<PlayerMovement>().isFacingRight) 
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        else
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }



    }

}
