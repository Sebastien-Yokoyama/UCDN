// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: Gun.cs
/* FILE DESCRIPTION: Class that provides gun functionality to object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /*----- PROPERTIES -----*/
    [Header("Gun Stats")]
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;

    [Header("Gun State")]
    public bool shooting, readyToShoot, reloading;

    [Header("References")]
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask shootable;

    [Header("Gun FX")]
    [SerializeField] AudioSource audioSource;
    public AudioClip gunshotSound;
    public AudioClip reloadSound;


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If mag empty and not already reloading, reload.
        if((bulletsLeft <= 0) && !reloading) { Reload(); }
    }

    // Shoot gun
    public void Shoot()
    {
        Debug.Log("Shoot");

        readyToShoot = false;

        // Raycast
        if (Physics.Raycast(CameraMgr.inst.playerCam.transform.position, CameraMgr.inst.playerCam.transform.forward, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

            // Apply damage to target
        }

        // Play Audio
        audioSource.clip = gunshotSound;
        audioSource.Play();


        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if((bulletsShot > 0) && (bulletsLeft > 0))
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
    }

    public void Reload()
    {
        Debug.Log("Reload");

        // Play Audio
        audioSource.clip = reloadSound;
        audioSource.Play();

        // Reload
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
