using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private EnemyScript bossScript;

    private void Start()
    {
        bossScript = boss.GetComponent<EnemyScript>();
    }

    private void Update()
    {
        if (bossScript.isKilled)
        {
            Destroy(gameObject);
        }
    }
}