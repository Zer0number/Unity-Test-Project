using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    InputAction shoot;
    public Transform FpsCam;
    public float range = 500;
    public float force = 150;
    public int fireRate = 10;
    private float nextTimeFire = 0;

    public ParticleSystem muzzleflash;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isShooting = shoot.ReadValue<float>() == 1;

        if(isShooting && Time.time >= nextTimeFire){
            nextTimeFire = Time.time + 1f / fireRate;
            Fire();
        } 
    }
    
    private void Fire()
    {
        RaycastHit hit;

        muzzleflash.Play();

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