using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;
    public float lifeTime = 6f;

    public GameObject destroyEffect;
    
    //
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector2 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		transform.Translate(Vector3.right * speed * Time.deltaTime);
        Debug.Log(position);

    }

    protected void destroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
