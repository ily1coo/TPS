using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.DealDamage(damage);
           
        }
        DestroyFireball();
    }

    private void DestroyFireball()
    {
       
        Destroy(gameObject);
    }

    public float speed;
    public float lifetime;
    public float damage = 10;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        MooveFIxedUpdate();
    }

    // Update is called once per frame
     private void MooveFIxedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
