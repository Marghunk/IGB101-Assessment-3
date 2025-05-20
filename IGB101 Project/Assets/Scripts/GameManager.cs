using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public Text pickupText;

    // Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    // Pickup and level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    private void Update()
    {
        levelCompleteCheck();
        UpdateGUI();
    }

    public void Start()
    {

    }

    private void levelCompleteCheck()
    {
        if (currentPickups >= maxPickups) { levelComplete = true; }
        else { levelComplete = false; }
    }

    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + " / " + maxPickups;
    }

    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) < audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }
}
