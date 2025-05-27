using UnityEngine;
using UnityEngine.SceneManagement;

public class Coen_LevelSwitch : MonoBehaviour
{
    Coen_GameManager gameManager;
    public string nextLevel;
    public Material m;
    public Color activated, deactivated;


    private void Start()
    {
        m = GetComponent<Renderer>().material;
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
