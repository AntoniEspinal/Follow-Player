using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Rigidbody enemyRb;
    public float speed = 5.0f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        transform.LookAt(player);
        transform.LookAt(player, Vector3.up);

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        if (Vector3.Distance(transform.position, player.position) < 0.001f)
        {
            player.position *= -1.0f;
        }
    }
}
