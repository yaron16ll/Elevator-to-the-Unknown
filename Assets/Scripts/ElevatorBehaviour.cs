using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject == other.gameObject)
        {
            StartCoroutine(SceneTransition());
        }
    }

    IEnumerator SceneTransition()
    {

        //before scene change updates the amount of gold
        PersistentObjectManager.Instance.setGold(CoinBehaviour.numCoins);
        Animator a = fade.GetComponent<Animator>();
        a.SetBool("startFadeIn", true);

        //Delay for 3 seconds
        yield return new WaitForSeconds(3);

        //start scene transition
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                PersistentObjectManager.Instance.setSpawnPoint(spawnPoint.transform.position);
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
                SceneManager.LoadScene(0);
        }


    

}
