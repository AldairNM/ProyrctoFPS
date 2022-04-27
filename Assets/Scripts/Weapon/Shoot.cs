using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shootForce = 1500f;
    public float shootRate = 0.3f;
    private float shootRateTime = 0;
    public Animator Animacion;
    public GameObject AnimacionCamara;
    int x=1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            x = 0;
            Animacion.SetBool("apuntar", true);
            AnimacionCamara.GetComponent<Animator>().SetBool("apuntadoCam", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            x = 1;
            Animacion.SetBool("apuntar", false);
            AnimacionCamara.GetComponent<Animator>().SetBool("apuntadoCam", false);
        }
        disparoClickIzquierdo(x);
    }
    public void disparo()
    {
        GameManager.Instance.ammo--;
        GameObject newBullet;
        newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);
        shootRateTime = Time.time + shootRate;
        Destroy(newBullet, 5);
    }
    public int disparoClickIzquierdo(int y)
    {
        if (y == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Time.time > shootRateTime && GameManager.Instance.ammo > 0)
                {
                    Animacion.SetBool("disparo", true);
                    Animacion.SetBool("correr", false);
                    disparo();
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Animacion.SetBool("disparo", false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Time.time > shootRateTime && GameManager.Instance.ammo > 0)
                {
                    Animacion.SetBool("dispararapuntar", true);
                    Animacion.SetBool("correr", false);
                    disparo();
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Animacion.SetBool("dispararapuntar", false);
            }
        }
        return 0;
    }

}
