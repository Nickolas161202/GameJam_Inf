using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Shooting_Controller : MonoBehaviour
{
    [SerializeField] Camera maincam;
    private Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

}
