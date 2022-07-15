using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float destroyDistance = 20f;

    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        //Move projectile
        var parent = transform.parent;

        if (transform.localScale.x == -1f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (transform.localScale.x == 1f)
        {
            transform.position += transform.right * speed * Time.deltaTime * -1;
        }

        //Distance between current position and original position
        var distance = Vector2.Distance(originalPosition, transform.position);

        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}