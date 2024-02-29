using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class gun_1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float force = 10;
    public Camera camera;
    public PhotonView view;

    delegate void MyDelegate();
    MyDelegate Shoot_OS;
    void Start()
    {
#if UNITY_EDITOR
        Shoot_OS = PC_Shoot;
#elif UNITY_STANDALONE
        Shoot_OS = PC_Shoot;
#elif UNITY_ANDROID
        Shoot_OS = Mobile_Shoot;
#endif 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    void Update()
    {
        if (view.IsMine)
        {
            Shoot_OS();
        }
    }

    private void PC_Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }    
    }
    public void Mobile_Shoot()
    {
        Shoot();
    }

    private void Shoot()
    {
        Debug.Log("Shoot__!!!");
        Camera mainCamera = camera;
        Vector3 centerOfScreen = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));
        Ray ray = new Ray(mainCamera.transform.position, centerOfScreen - mainCamera.transform.position);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Vector3 direction = (targetPoint - transform.position).normalized;
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}

