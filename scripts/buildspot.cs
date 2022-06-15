using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buildspot : MonoBehaviour
{
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public turretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	buyManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = buyManager.instance;
	}

	public Vector3 GetBuildPosition(turretBlueprint blueprint)
	{
		if (blueprint.prefab.tag == "laserbeamer")
        {
			return transform.position + positionOffset;
        }
        else
        {
			return transform.position;
        }
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret(turretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(blueprint), Quaternion.identity);
		turret = _turret;

		Debug.Log("Turret build!");
		buildManager.DeselectTurretToBuild();
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
