using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Shooting_Controller : MonoBehaviour
{
    [SerializeField] Camera maincam;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletTransform;
    private float timer;
    [SerializeField] float timeBetweenShoot;

    bool canShoot;
    private Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        canShoot = true;

    }

    void Update()
    {


        mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
        if (!canShoot)
        {
            timer += Time.fixedDeltaTime;
            if (timer > timeBetweenShoot)
            {
                canShoot = true;
            }

        }
        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            timer = 0;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

}
