using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    InputAction shoot, reload;
    public Transform FpsCam;
    public float range = 500;
    public float force = 150;
    public int fireRate = 10;
    private float nextTimeFire = 0;

    public ParticleSystem muzzleflash;
    public GameObject impactEffect;

    public int currentAmmo;
    public int maxAmmo = 300;
    public int magSize = 30;
    public float reloadTime = 3f;

    bool isShooting;
    bool isReloading;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magSize;

        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        reload = new InputAction("Reload", binding: "<keyboard>/r");
        
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        isShooting = shoot.ReadValue<float>() == 1;

        if(isShooting && Time.time >= nextTimeFire){
            nextTimeFire = Time.time + 1f / fireRate;
            if(maxAmmo != -magSize){
                Fire();
            }
        } 
    }
    
    private void Fire()
    {
        RaycastHit hit;

        muzzleflash.Play();
        if(currentAmmo != 1){
            currentAmmo--;
        }
        else if(!isReloading){
            Reload();
        }

        if(Physics.Raycast(FpsCam.position, FpsCam.forward, out hit, range)){
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * force);
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 10);

        }
    }

    private void Reload(){
        isReloading = true;
        maxAmmo -= (magSize - currentAmmo) + 1;
        if(maxAmmo != -magSize)
            currentAmmo = magSize;
        isReloading = false;
    }
}