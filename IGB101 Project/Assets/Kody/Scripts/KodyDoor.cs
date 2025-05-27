using UnityEngine;
using UnityEngine.Animations;

public class KodyDoor : MonoBehaviour
{
    Animation animation;
    public float interactProximity = 0.6f;
    public GameObject player;
    Animator playerAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animation = GetComponent<Animation>();
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && Vector3.Distance(player.transform.position, transform.position) <= interactProximity)
        {
            animation.Play();
            playerAnimator.SetBool("Kicking Door", true);
        }
        else
            playerAnimator.SetBool("Kicking Door", false);
    }
}
