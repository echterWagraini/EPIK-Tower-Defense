using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemymovement : MonoBehaviour
{
    public float movespeed = 15f;
    private Transform target;
    private int waypointin = 0;

    public float starthealth=100f;
    public float health;

    public int deathcost;

    public int damage=1;

    public Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        health = starthealth;
        target = waypoints.points[0];
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * movespeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
            transform.LookAt(target);
        }
    }

    void GetNextWaypoint()
    {
       if (waypointin >= waypoints.points.Length)
        {
            Destroy(gameObject);
            PlayerStats.instance.looseHealth(damage);
        }
        waypointin++;
        target = waypoints.points[waypointin];
    }

    public void TakeDamage(float damage)
    {
        if (damage >= health)
            die();
        else
            health -= damage;

        healthbar.fillAmount = health/starthealth;
    }
    void die()
    {
        Destroy(gameObject);
        PlayerStats.instance.earnMoney(deathcost);
    }
}
