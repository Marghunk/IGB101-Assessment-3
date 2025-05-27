using UnityEngine;
using UnityEngine.SceneManagement;

public class Coen_LevelSwitch : MonoBehaviour
{
    Coen_GameManager gameManager;
    public string nextLevel;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Coen_GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameManager.levelComplete)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
