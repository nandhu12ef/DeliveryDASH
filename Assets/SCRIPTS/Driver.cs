using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] TMP_Text BoostText;
    [SerializeField] TMP_Text Collected;
    [SerializeField] TMP_Text Delivered;

    private void Start()
    {
        BoostText.gameObject.SetActive(false);
        Collected.gameObject.SetActive(false);
        Delivered.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            BoostText.gameObject.SetActive(true);
            Destroy(Collision.gameObject);
        }
        if (Collision.CompareTag("Package"))
        {
            Collected.gameObject.SetActive(true);
            Delivered.gameObject.SetActive(false);
        }
        if (Collision.CompareTag("Customer"))
        {
            Collected.gameObject.SetActive(false);
            Delivered.gameObject.SetActive(true);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.collider.CompareTag("CollisionBoxes"))
        {
            BoostText.gameObject.SetActive(false);
            moveSpeed = currentSpeed;

        }
        
        
    }
    void Update()
    {
        float move = 0f;
        float steer = 0f;


        if (Keyboard.current.wKey.isPressed)
        {
            move = -1f;
        }


        else if (Keyboard.current.sKey.isPressed)
        {
            move = 1f;
        }

         if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f; 
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount , 0);
        transform.Rotate(0, 0, steerAmount);
        
    }
}
