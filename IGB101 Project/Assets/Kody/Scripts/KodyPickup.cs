using Unity.VisualScripting;
using UnityEngine;

public class KodyPickup : MonoBehaviour
{
    KodyGameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KodyGameManager>();
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.transform.tag == "Player")
        {
            gameManager.currentPickups += 1;
            Destroy(this.gameObject);
        }
    }
}
