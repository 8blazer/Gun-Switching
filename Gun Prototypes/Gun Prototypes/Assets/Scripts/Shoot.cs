using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject firePrefab;
    public GameObject laserPrefab;
    public static float bulletLife = 1;
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
        if (Input.GetButton("Fire1") && holdWeapons.Contains(PlayerPrefs.GetString("Weapon")) && timerGoing == false)
        {
            ShootWeapon();
            timerGoing = true;
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
                bulletLife = 1;
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
                bulletLife = 1;
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
                bulletLife = 1;
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
                bulletLife = 1;
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
            case ("MachineGun"):         //Hold down and it gets less accurate
                reload = .1f;
                i = rnd.Next(-15, 16);
                bulletLife = 1;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(2f, 0);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.Rotate(0, 0, i);
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -15;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity - new Vector2(2f, 0);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.transform.Rotate(0, 0, i);
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 15;
                }
                break;
            case ("GoldMachineGun"):
                reload = .1f;
                i = rnd.Next(-5, 6);
                bulletLife = 1;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.2f, .15f, 0), Quaternion.identity);
                    bullet.GetComponent<Transform>().Rotate(0, 0, i);
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -15;
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.2f, .15f, 0), Quaternion.identity);
                    bullet.GetComponent<Transform>().Rotate(0, 0, i);
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 15;
                }
                break;
            case ("Shotgun"):
                reload = 1;
                i = rnd.Next(-45, 46);
                bulletLife = .25f;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(2000, 0));
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.4f, .15f, 0), Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
                        bullet.GetComponent<Transform>().Rotate(0, 0, i);
                        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -15;
                    }
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000, 0));
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.4f, .15f, 0), Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                        bullet.GetComponent<Transform>().Rotate(0, 0, i);
                        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 15;
                    }
                }
                break;
            case ("GoldShotgun"):
                reload = .55f;
                i = rnd.Next(-30, 31);
                bulletLife = .25f;
                if (PlayerPrefs.GetString("Facing") == "Left")
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(2000, 0));
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-1.4f, .15f, 0), Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
                        bullet.GetComponent<Transform>().Rotate(0, 0, i);
                    }
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000, 0));
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1.4f, .15f, 0), Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                        bullet.GetComponent<Transform>().Rotate(0, 0, bullet.transform.rotation.z + i);
                    }
                }
                break;
        }

    }
}
