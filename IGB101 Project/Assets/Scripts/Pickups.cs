using UnityEngine;

public class Pickups : MonoBehaviour
{
    Liam_GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Liam_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherObject){
        if(otherObject.transform.tag == "Player"){
            gameManager.currentPickups += 1;
            Destroy(this.gameObject);
        }
    }
}
