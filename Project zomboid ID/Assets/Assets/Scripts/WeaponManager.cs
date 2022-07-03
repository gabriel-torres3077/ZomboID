using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public Camera playerCam;
    public float range;
    public float damage = 20;

    public int magazineSize;
    public int currentMagazine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //Debug raycast fired
        //Debug.DrawRay(playerCam.transform.position, transform.forward * range, Color.blue, 5f);

        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();

            if (enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
        }
    }
}
