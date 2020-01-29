using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Shoot.bulletLife)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
	}
    
}
