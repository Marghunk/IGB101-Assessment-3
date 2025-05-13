using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    // UI
    public TMP_Text pickupText;

    // Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;


    void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
        {
            levelComplete = true;
        }
        else
        {
            levelComplete = false;
        }
    }
    void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
            else
            {
                if (audioSources[i].isPlaying)
                {
                    audioSources[i].Stop();
                }
            }
        }
    }

    private void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

}
