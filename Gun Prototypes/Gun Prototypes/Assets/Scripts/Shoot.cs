using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject firePrefab;
    public GameObject laserPrefab;
    List<string> holdWeapons = new List<string>();
    float timer = 0;
    bool timerGoing = false;
    float reload;
    // Start is called before the first frame update
    void Start()
    {
        holdWeapons.Add("Minigun");
        holdWeapons.Add("GoldMinigun");
        holdWeapons.Add("MachineGun");
        holdWeapons.Add("GoldMachineGun");
        holdWeapons.Add("Flamethrower");
        holdWeapons.Add("GoldFlamethrower");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && holdWeapons.Contains(PlayerPrefs.GetString("Weapon")))
        {
            ShootWeapon();
            timerGoing = false;
        }
        else if (Input.GetButtonDown("Fire1") && timerGoing == false)
        {
            timerGoing = true;
            ShootWeapon();
        }
        if (timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > reload)
            {
                timer = 0;
                timerGoing = false;
            }
        }
    }
    void ShootWeapon()
    {
        switch (PlayerPrefs.GetString("Weapon"))
        {
            case ("Pistol"):
                reload = 0;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
                }
                break;
            case ("GoldPistol"):

                break;
        }

    }
}
