using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    public Transform Target;
    public Vector3 targetPos;

    public Transform emptyGameObjectPrefab;
    public GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera=GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x,mainCamera.transform.position.y,mainCamera.transform.position.z);

        Target=Instantiate(emptyGameObjectPrefab, pos, Quaternion.identity);

        transform.LookAt(Target);

        /*Vector3 center = new Vector3(0, this.transform.position.y, 0);
        Vector3 targetPos = Target.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);*/

    }
}