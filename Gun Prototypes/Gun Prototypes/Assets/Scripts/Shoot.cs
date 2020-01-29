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
    System.Random rnd = new System.Random();
    float i = 0;
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
                reload = .2f;
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
            case ("Revolver"):
                reload = .2f;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.localScale += new Vector3(1f, 1f, 0);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-25, 0);
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.localScale += new Vector3(1f, 1f, 0);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(25, 0);
                }
                break;
            case ("GoldRevolver"):
                reload = 0;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.localScale += new Vector3(1f, 1f, 0);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-25, 0);
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.localScale += new Vector3(1f, 1f, 0);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(25, 0);
                }
                break;
            case ("MachineGun"):
                reload = 0;
                i = rnd.Next(-30, 31);
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(1.5f, 0);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.rotation = Quaternion.Euler(0, 0, i);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-25, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity - new Vector2(1.5f, 0);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.Rotate(0, 0, i, Space.Self);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(25, 0);
                }
                break;
            case ("GoldMachineGun"):
                reload = 0;
                i = rnd.Next(-30, 31);
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(1f, 0);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.rotation = Quaternion.Euler(0, 0, i);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-25, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity - new Vector2(1f, 0);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.Rotate(0, 0, i, Space.Self);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(25, 0);
                }
                break;
        }

    }
}
