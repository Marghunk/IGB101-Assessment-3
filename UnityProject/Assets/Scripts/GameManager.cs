    using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
        public GameObject player;

        public int currentPickups = 0;
        public int maxPickups = 6;
        public bool levelComplete = false;
        public Text pickUpText;
        public AudioSource[] audioSources;
        public float audioProximity = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelCompleteCheck();
        UpdateGUI();
        PlayAudioSample();
    }

    private void levelCompleteCheck()
    {
        if(currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }  
    private void UpdateGUI()
    {
        pickUpText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    private void PlayAudioSample(){
        for (int i = 0; i < audioSources.Length; i++){
            if(Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity){
                if(!audioSources[i].isPlaying){
                    audioSources[i].Play(); 
                }
            }
        }
    }
}
