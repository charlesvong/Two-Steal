using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerController : MonoBehaviour
{
    Animator ninjaAnim;
    public float speed;

    void Start()
    {
        ninjaAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        //GetComponent<Animation>().Play("NinjaIdle");
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        //ninjaAnim.SetFloat("Speed", vertical);
        if (vertical != 0)
        {
            ninjaAnim.Play("NinjaForward");
        }
        else if (horizontal < 0)
        {
            ninjaAnim.Play("NinjaLeft");
        }
        else if (horizontal > 0)
        {
            ninjaAnim.Play("NinjaRight");
        }
        else
        {
            ninjaAnim.Play("NinjaIdle");
        }
        var playerMovement = new Vector3(horizontal, 0f, vertical).normalized * (speed * Time.deltaTime);
        transform.Translate(playerMovement, Space.Self);
    }
}
