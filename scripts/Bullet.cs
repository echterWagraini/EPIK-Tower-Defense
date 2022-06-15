using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	private Transform target;

	public float speed = 70f;

	public float damage = 0;

	public float explosionRadius = 0f;
	public GameObject impactEffect;

	public void Case(Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void Update()
	{

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}


		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}
		
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		//transform.LookAt(target,Vector3.left);
		transform.rotation = Quaternion.FromToRotation(Vector3.left, Vector3.forward) * Quaternion.LookRotation(target.position - transform.position, Vector3.up);
	}

	void HitTarget()
	{
		//GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		//Destroy(effectIns, 5f);

		if (explosionRadius > 0f)
		{
			Explode();
		}
		else
		{
			Damage(target);
		}

		Destroy(gameObject);
	}

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage(Transform enemy)
	{
		enemymovement e = enemy.GetComponent<enemymovement>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}