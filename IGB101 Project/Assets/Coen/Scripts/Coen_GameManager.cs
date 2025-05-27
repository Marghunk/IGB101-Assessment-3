using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Coen_GameManager : MonoBehaviour
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

            GameObject.FindAnyObjectByType<Coen_LevelSwitch>().m.color = GameObject.FindAnyObjectByType<Coen_LevelSwitch>().deactivated;
        }
        else
        {
            levelComplete = false;
        }
    }
    void UpdateGUI()
    {
        if (currentPickups >= maxPickups)
        {
            pickupText.text = $"Coins: {currentPickups}/{maxPickups} \b Head to the Exit!";
        }
        else
        {
            pickupText.text = "Coins: " + currentPickups + "/" + maxPickups;
        }
        
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

    private void Start()
    {
        maxPickups = GameObject.FindObjectsByType<Pickup>(FindObjectsSortMode.None).Length;
    }
    private void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

}
