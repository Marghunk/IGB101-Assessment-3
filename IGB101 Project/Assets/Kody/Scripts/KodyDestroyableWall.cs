
using UnityEngine;

public class KodyDestroyableWall : MonoBehaviour
{
    public Animation anim;
    public GameObject player;
    Animator playerAnimator;
    public int WallRange = 1;
    bool doorKicked = false;
    KodyGameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KodyGameManager>();
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            playerAnimator.SetBool("Kicking Door", true);
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= WallRange && !doorKicked)
            {
                anim.Play();
                doorKicked = true;
                gameManager.DoorKicked();
            }
            Invoke("ResetAnimation", 0.5f);
        }

    }

    void ResetAnimation()
    {
        if (playerAnimator.GetBool("Kicking Door") == true)
        {
            playerAnimator.SetBool("Kicking Door", false);
        }
    }
}
