using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSound : MonoBehaviour
{
    AudioSource audio;
     public GameObject live;
    public bool isPlayerIn = false;
    public RawImage dragonMission;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            live.SetActive(true);   
            isPlayerIn = true;  
            dragonMission.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Stop();
            live.SetActive(false);
            isPlayerIn = false;
            dragonMission.gameObject.SetActive(true);

        }
    }
}
