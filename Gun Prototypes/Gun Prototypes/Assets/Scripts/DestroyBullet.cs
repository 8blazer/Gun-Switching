using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Weapon")
        {
            Destroy(gameObject);
        }
	}
    
}
