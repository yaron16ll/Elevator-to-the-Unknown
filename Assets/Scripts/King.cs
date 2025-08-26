using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public Text coinText;
    Animator animator;
    public RawImage goldMission, dragonMission,SwordText,elevatorMission;
    public RawImage[] kingMission = new RawImage[5];
    public GameObject player;//connect to player in Unity
    public static int numCoins = 0;
    AudioSource sound;
    bool isMuted = false,isCounted = true;
    public GameObject swordBox;
    public GameObject bridge;
    public AudioClip clip1, clip2;
    public float targetTime = 45;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();//connect to property in unity
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCounted)
        {
            targetTime -= Time.deltaTime;
            if (targetTime < 40)
            {
                kingMission[0].gameObject.SetActive(false);
                kingMission[1].gameObject.SetActive(true);
            }
            if (targetTime < 35)
            {
                kingMission[1].gameObject.SetActive(false);
                kingMission[2].gameObject.SetActive(true);
            }
            if (targetTime < 30)
            {
                kingMission[2].gameObject.SetActive(false);
                kingMission[3].gameObject.SetActive(true);
            }
            if (targetTime < 25)
            {
                kingMission[3].gameObject.SetActive(false);
                kingMission[4].gameObject.SetActive(true);
            }
            if (targetTime < 20)
            {
                kingMission[3].gameObject.SetActive(false);
                kingMission[4].gameObject.SetActive(true);
            }
            if (targetTime < 15)
                {
                    animator.SetInteger("State", 0);
                    kingMission[4].gameObject.SetActive(false);
                if (elevatorMission.gameObject.activeSelf == false)
                {
                        dragonMission.gameObject.SetActive(true);
                }
            
                    swordBox.gameObject.SetActive(true);  
                bridge.gameObject.SetActive(true);
                    sound.Stop();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
                      isCounted = false;   

                if (!isMuted)
                {
                    sound.PlayOneShot(clip2);
                    isMuted = true;

                }
                sound.PlayOneShot(clip1);
                kingMission[0].gameObject.SetActive(true);
                goldMission.gameObject.SetActive(false);
                animator.SetInteger("State", 1);//talking
                coinText.text = "Gold: " + numCoins;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCounted = true;
            for (int i = 0; i < kingMission.Length; i++)
            {
                kingMission[i].gameObject.SetActive(false);
            }
            animator.SetInteger("State", 0);
            sound.Stop();
        }
    }
}


