using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float force = 10;
    public Camera camera;

    void Start()
    {
        // Приховати курсор миші
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDestroy()
    {
        // Показати курсор миші при закритті гри
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot2();
        }
    }
   


    private void Shoot2()

    {
        Debug.Log("Shoot__!!!");
        // Отримуємо позицію та напрямок камери
        Camera mainCamera = camera;
        Vector3 centerOfScreen = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));
        Ray ray = new Ray(mainCamera.transform.position, centerOfScreen - mainCamera.transform.position);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;

            // Створюємо пулю в позиції transform.position та рухаємо її у напрямку targetPoint
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Vector3 direction = (targetPoint - transform.position).normalized;
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
        else
        {
            // Якщо луч не перетинає жодну поверхню, стріляємо у напрямку transform.forward
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}

