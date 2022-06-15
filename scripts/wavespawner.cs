using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public Transform enemyprefab;
    public Transform thickenemyprefab;
    public Transform thinenemyprefab;

    public Transform spawnpoint;

    public float cooldown = 0f;
    public float timebetween = 1f;
    public float enemyperwave = 5f;
    public float enemyspawned = 0f;

    public float wavecontroll = 1;

    public Text waveCount;
    public int wave = 1;
    public bool startnext = false;

    public bool autostart = false;

    public bool canstart = true;

    // Update is called once per frame
    void Update()
    {
        if (canstart==true)   //nicht wave spawnen während wave noch am leben ist
        {
            if (startnext == true)      //waves nicht automatisch anfangen lassen
            {
                waveCount.text = "Round: " + wave.ToString();
                if (cooldown <= 0)      //zwischen gegnern warten
                {
                    spawnEnemy(Random.Range(1, 4));
                    cooldown = timebetween;
                    enemyspawned++;
                }
                if (enemyspawned == enemyperwave)       //wave fertig
                {
                    if (autostart == false)
                        startnext = false;

                    wavecontroll++;
                    wave++;

                    enemyspawned = 0f;
                    cooldown = 0f;
                }
                if (wavecontroll == 5)              //um alle 5 waves die anzahl an gegnern zu erhöhen
                {
                    enemyperwave++;
                    wavecontroll = 0;
                }
                cooldown -= Time.deltaTime;
            }
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == enemyperwave)
        {
            canstart = false;
        }
        else if (enemies.Length == 0)
        {
            canstart = true;
        }
    }

    public void startNext()
    {
        startnext = true;
    }

    public void activateAutoStart()
    {
        autostart = !autostart;
    }
    public void spawnEnemy(int what)
    {
        switch (what){
            case 1: Instantiate(enemyprefab, spawnpoint.position, spawnpoint.rotation);break;
            case 2: Instantiate(thinenemyprefab, spawnpoint.position, spawnpoint.rotation);break;
            case 3: Instantiate(thickenemyprefab, spawnpoint.position, spawnpoint.rotation);break;
            default: Debug.Log("ERROR");break;
        }
    }
}
