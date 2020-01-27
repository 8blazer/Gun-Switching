using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetString("Weapon", collision.gameObject.name);
    }
}
