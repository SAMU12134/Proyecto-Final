using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform spawnpoint;

    public GameObject bullet;

    public float shootforce = 1500f;
    public float shootrate = 0.5f;

    public Animator anim;

    [Header("Animacion")]


    public bool OnShoot;

    private float shootratetime = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (Time.time > shootratetime)
            {
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * shootforce);

                shootratetime = Time.time + shootrate;

                Destroy(newBullet, 1);


            }

            anim.SetTrigger("Shoot");
            OnShoot = true;




        }

        



    }








    private void Offshoot()
    {

        OnShoot = false;
        anim.SetBool("Shoot", false);
    }
}



