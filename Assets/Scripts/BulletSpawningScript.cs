using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawningScript : MonoBehaviour
{
    [Tooltip("Prefab to spawn")]
    [SerializeField] private GameObject spawnPrefab = null;

    [Tooltip("Time between spawns")]
    [SerializeField] private float spawnTime = 5.0f;

    private float nextSpawn;

    [SerializeField]
    private bool isMovingRight;

    // Start is called before the first frame update
    private void Start()
    {
        nextSpawn = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        nextSpawn += Time.deltaTime;
        if (nextSpawn > spawnTime)
        {
            GameObject projecttileObject
                = Instantiate(spawnPrefab, transform.position, transform.rotation, transform);
            Debug.Log(projecttileObject.transform.localScale);
            projecttileObject.transform.localScale = new Vector2(transform.localScale.x, projecttileObject.transform.localScale.y);
            nextSpawn = 0f;
        }
    }
}