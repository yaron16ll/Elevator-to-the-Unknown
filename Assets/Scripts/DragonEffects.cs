using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEffects : MonoBehaviour
{
    AudioSource audio;
    public GameObject effect;


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
            effect.gameObject.SetActive(true); 
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Stop();
            effect.gameObject.SetActive(false); 
        }
    }

}
