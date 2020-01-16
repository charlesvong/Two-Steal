using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{

    public Transform player;


    bool m_IsPlayerInRange;

    private float y;
    private bool rotateY;
    public float rotationSpeed;

    void Start()
    {
        y = 0.0f;
        rotateY = true;
        rotationSpeed = 75.0f;
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
            print("detected");
            SceneManager.LoadScene("SampleScene"); //Load scene called Game
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (rotateY == true)
        {
            y += Time.deltaTime * rotationSpeed;

            if (y > 140.0f)
            {
                rotateY = false;
            }
        }
        else
        {
            y -= Time.deltaTime * rotationSpeed;

            if (y < 0.0f)
            {
                rotateY = true;
            }
        }
        
        transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}