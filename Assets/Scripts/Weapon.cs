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

    void Start()
    {
        currentAmmo = magSize;

        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        reload = new InputAction("Reload", binding: "<keyboard>/r");
        
        shoot.Enable();
    }

    void Update()
    {
        isShooting = shoot.ReadValue<float>() == 1;
        if((maxAmmo + currentAmmo) != 0 && !isReloading){
            animator.SetBool("isShooting", isShooting);
        }

        if(isShooting && Time.time >= nextTimeFire){
            
            nextTimeFire = Time.time + 1f / fireRate;
            Fire();
        }
        if(currentAmmo == 0 && !isReloading){
            StartCoroutine(Reload());
        }
    }
    
    private void Fire()
    {
        if((maxAmmo + currentAmmo) != 0 && !isReloading){
            RaycastHit hit;

            muzzleflash.Play();
            if(currentAmmo != 0){
                currentAmmo--;
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
    }

    IEnumerator Reload(){
        isReloading = true;

        animator.SetBool("isShooting", false);
        
        yield return new WaitForSeconds(reloadTime);

        maxAmmo = maxAmmo - (magSize - currentAmmo);
        if((maxAmmo + currentAmmo) != 0){
            currentAmmo = magSize;
        }
        else{
            currentAmmo = magSize;
            maxAmmo = 0;
        }

        isReloading = false;
    }
}