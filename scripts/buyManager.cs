using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyManager : MonoBehaviour
{
	public static buyManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private turretBlueprint turretToBuild;
	private buildspot selectedNode;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void SelectNode(buildspot node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;
	}

	public void DeselectNode()
	{
		selectedNode = null;
	}

	public void SelectTurretToBuild(turretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public void DeselectTurretToBuild()
	{
		turretToBuild = null;
		Debug.Log("success");
		DeselectNode();
	}

	public turretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
