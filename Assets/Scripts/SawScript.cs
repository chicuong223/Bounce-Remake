using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    [SerializeField] private int speed = 300;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}