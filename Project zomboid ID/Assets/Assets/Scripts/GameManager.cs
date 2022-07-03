using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int zombiesAlive = 0;
    public int totalZombiesAlive = 0;
    public int zombiesThisTurn = 0;

    public int maxZombiesAlive = 24;

    public int worldZombiesTotal = 0;
    
   

    public int round = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public TextMeshProUGUI roundCounter;
    // Start is called before the first frame update
    void Start()
    {
        SetZombiesCount(round);
        spawnZombie();
        roundCounter.text = round.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bool canSpawn = zombiesAlive < maxZombiesAlive && totalZombiesAlive <= zombiesThisTurn;
        if (canSpawn)
        {
            Debug.Log("Zombie Spawnned");
            spawnZombie();
        }
        else if (zombiesAlive == 0)
        {
            round++;
            SetZombiesCount(round);
            roundCounter.text = round.ToString();

        }
        
    }
    public void spawnZombie()
    {
        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemySpawned = Instantiate(enemyPrefab, spawnpoint.transform.position, Quaternion.identity);
        
        enemySpawned.GetComponent<EnemyManager>().manager = GetComponent<GameManager>();

        zombiesAlive++;
        totalZombiesAlive++;
    }
    

    public void SetZombiesCount(int round)
    {
        if (round >= 20)
        {
            float zombies = 0.09f * Mathf.Pow(round, 2) + (-0.0029f * round) + 23.958f;

            zombiesThisTurn = (int)Mathf.Round(zombies);
        }
        else
        {
            zombiesThisTurn = 6 + (round * 2) ;
        }

        totalZombiesAlive = 0;
    }
}
