using System.Xml;
using UnityEditor.Build.Content;
using UnityEngine;

public class LucasPickup : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        
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
