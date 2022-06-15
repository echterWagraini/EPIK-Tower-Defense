using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shop : MonoBehaviour
{
	public turretBlueprint standardTurret;
	public turretBlueprint missileLauncher;
	public turretBlueprint laserBeamer;

	buyManager buildManager;

	public Text standardbutton, laserbutton, missilebutton;

	void Start()
	{
		buildManager = buyManager.instance;
	}

	void Update()
    {
		standardbutton.text = standardTurret.cost+"$";
		laserbutton.text = laserBeamer.cost+"$";
		missilebutton.text = missileLauncher.cost+"$";
    }

	public void SelectStandardTurret()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laserBeamer);
	}
}
