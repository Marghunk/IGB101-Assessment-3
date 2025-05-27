using UnityEngine;
using UnityEngine.UI;

public class KodyGameManager : MonoBehaviour
{
    public GameObject player;
    //Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 4;
    public bool levelComplete = false;
    public Text pickupText;
    public Text doorText;
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;
    private int doorsKicked = 0;

    public void DoorKicked()
    {
        doorsKicked++;
    }
    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups && doorsKicked == 4)
            levelComplete = true;
        else
            levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
        doorText.text = "Walls Kicked: " + doorsKicked.ToString() + "/4";
    }

    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                    audioSources[i].Play();
            }
        }
    }
}
