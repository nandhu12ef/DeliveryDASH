using UnityEngine;


public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay=0.5f;
   
    
    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Package") &&hasPackage == false) 
        {
            Debug.Log("package picked up");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(Collision.gameObject, delay);
            
        
        }

        if (Collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("delivered");
            GetComponent<ParticleSystem>().Stop();
            hasPackage = false;
            Destroy(Collision.gameObject);
            

        }
    }  


}
