using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;
    private TargetJoint2D target;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D colidir)
    {
        if (colidir.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }
    }
    void OnTriggerEnter2D(Collider2D colidir)
    {
        if (colidir.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    } 
    
    void Falling()
    {
        target.enabled = false;
        boxCollider.isTrigger = true;
    } 
}
