using UnityEngine;

public class Pickup : MonoBehaviour
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
            Destroy(this.gameObject);
        }
    }
}
