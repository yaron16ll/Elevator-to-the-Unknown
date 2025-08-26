using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PickSword : MonoBehaviour
{
    public GameObject swordOnWall;
    public GameObject swordInHand;
    public RawImage swordText;
    public AudioSource sound;
    private bool isTaken= false;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnMouseDown()
    {
        if (swordOnWall.activeSelf)
        {
            sound.Play();
        }  
        swordOnWall.SetActive(false);
        swordInHand.SetActive(true);
    isTaken = true;
    }

    void OnMouseOver()
    {
        if (!isTaken)
        swordText.gameObject.SetActive(true);

    }
    void OnMouseExit()
    {
        swordText.gameObject.SetActive(false);

    }
}
