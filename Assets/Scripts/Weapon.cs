using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //todo 

    /*
     *weapon ammo 
     * projectile spawn
     * sound effect for trigger
     * aiming anim
     * wobble(procedurally generate?)
     * 
    */


    public int  weaponCapacity;
    public int ammoLeft;
    public int range;

    public ParticleSystem muzzleFlash;

    public GameObject bullet;
    public int bulletSpeed;
    public Transform bulletSpawnPos;
    public float bulletLifetime = 3f;
    
    public Transform aimingPosition, nonAimingPosition;

    // Start is called before the first frame update
    void Start()
    {
        ammoLeft = weaponCapacity;
        transform.SetPositionAndRotation(nonAimingPosition.position, nonAimingPosition.rotation);


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            transform.SetPositionAndRotation(nonAimingPosition.position, nonAimingPosition.rotation);

        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.SetPositionAndRotation(aimingPosition.position, aimingPosition.rotation);


        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoLeft>0)
        {

           
            FireWeapon();
            //ammoLeft--;
        }
    }

    public void FireWeapon()
    {
        Camera cam = Camera.main;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
        {
            /*Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {

                //target.takeDamage
            }*/


            muzzleFlash.Play();
            GameObject bulletIns = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bulletIns, bulletLifetime);

        }



    }



    


}
