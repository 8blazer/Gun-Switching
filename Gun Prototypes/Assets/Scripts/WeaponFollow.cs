using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public GameObject player;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Weapon") == this.gameObject.name)
        {
            if (PlayerPrefs.GetString("Facing") == "Left")
            {
                transform.position = player.transform.position + new Vector3(1, 0, 0);
            }
            else
            {
                transform.position = player.transform.position - new Vector3(1, 0, 0);
            }
        }
        else
        {
            transform.position = new Vector3(x, y, 0);
        }
    }

}
