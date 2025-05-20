using UnityEngine;
using UnityEngine.SceneManagement;

public class LiamLevelSwitch : MonoBehaviour
{
    Liam_GameManager gameManager;
    public string nextLevel;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Liam_GameManager>();
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.transform.tag == "Player")
        {
            if (gameManager.levelComplete == true)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}