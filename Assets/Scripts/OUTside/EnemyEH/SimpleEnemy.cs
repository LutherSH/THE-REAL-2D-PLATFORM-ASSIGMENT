using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float movespeed = 2f;
    public Transform pointA;
    public Transform pointB;
    private UnityEngine.Vector3 nextPosition;
    private bool lookleft = false;

    public EnemyLevelManager enemyLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position,nextPosition, movespeed * Time.deltaTime);

        if(UnityEngine.Vector3.Distance(transform.position, nextPosition)<0.1f)
        {
            nextPosition = nextPosition == pointA.position ? pointB.position : pointA.position;
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collition)
    {
        if (collition.CompareTag("Bullet"))
        {
            EnemyLevelManager.Instance?.JerkDies();
            enemyLevelManager.JerkDies();
            Destroy(gameObject);
            Destroy(collition.gameObject);
            Debug.Log("HIT");
        }
    }

    private void Flip()
    {
        lookleft = !lookleft;
        UnityEngine.Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
