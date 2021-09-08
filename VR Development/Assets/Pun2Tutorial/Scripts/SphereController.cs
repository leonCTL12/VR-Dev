using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController: MonoBehaviour
{
    // Update is called once per frame

    private CharacterController controller;

    private float speed = 3f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

    }
}
