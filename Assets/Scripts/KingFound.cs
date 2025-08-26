using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingFound : MonoBehaviour
{
    AudioSource audio;
    public bool isFound = false;
    public RawImage goldMission,castleMission;
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
        if (other.CompareTag("Player") && !isFound)
        {
            audio.Play();
            isFound = true;
            goldMission.gameObject.SetActive(true); 
            castleMission.gameObject.SetActive(false);   
        }

    }
}
