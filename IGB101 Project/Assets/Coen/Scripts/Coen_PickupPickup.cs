using UnityEngine;

public class Coen_Pickup : MonoBehaviour
{
    Coen_GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Coen_GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.currentPickups += 1;
            gameManager.pickupSound.Play();
            Destroy(this.gameObject);
        }
    }
}
