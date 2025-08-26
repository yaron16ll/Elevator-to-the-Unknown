using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//based on Singleton
public class PersistentObjectManager : MonoBehaviour
{
    public static PersistentObjectManager Instance = null;
    private static int gold = 0;
    public Text goldText;
    private static bool hasCoin = true;
    public CoinBehaviour aCoin;
    private static Vector3 SpawnPoint;
    public GameObject player;

    //runs before Start
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {

            Destroy(gameObject);
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                player.transform.position = SpawnPoint;
                player.transform.Rotate(new Vector3(0,-90,0));

            }

        }

        goldText.text = "Gold: " + gold;
        aCoin.exists = hasCoin;
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGold(int num)
    {
        gold = num;
    }

    public void setHasCoin(bool value)
    {
        hasCoin = value;
       

    }
    public void setSpawnPoint(Vector3 sp)
    {
        SpawnPoint = sp;
    }
}
