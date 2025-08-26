using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinBehaviour : MonoBehaviour
{
    public static int numCoins= 0;
    public GameObject coins;
    public GameObject bridge;
    public AudioClip clip1, clip2;
    public Text coinText;
    public RawImage castleMission, coinsMission;
    public GameObject player;
    public bool exists = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!exists)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            numCoins++;
            coinText.text = "Gold: " + numCoins;
            exists = false;        
            AudioSource sound = coins.GetComponent<AudioSource>();
             sound.PlayOneShot(clip1); 
            gameObject.SetActive(false);
            //PersistentObjectManager.Instance.setHasCoin(false);
           
            if(numCoins ==10)
        {
            bridge.SetActive(true);
            sound.PlayOneShot(clip2);
            coinsMission.gameObject.SetActive(false);
            castleMission.gameObject.SetActive(true);


            }

        }
    }
        
}
