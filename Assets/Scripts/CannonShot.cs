using System;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private ParticleSystem psShot;

    [Tooltip("Activar para que la PanCamera siga a la bala disparada por el cañon")]
    [SerializeField] bool BulletToFollow;

    public delegate void OnCannonShotDelegate(Bullet bullet);

    public OnCannonShotDelegate OnCannonShot;

    [SerializeField] private bool cannonLoaded;

    void Start()
    {
        cannonLoaded = true;
    }
    void Update()
    {

    }

    public void Shot()
    {
        if (!cannonLoaded)
        {
            return;
        }

        GameObject bulletGO = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.Shot();
        psShot.Play();

        cannonLoaded = false;
        UIController.instance.SetCannonLoadStatus(false);
        Invoke(nameof(LoadCannon), 4f);

        // ya que hemos puesto la variable BulletToFollow para indicar si el cañon se debe hacer responsable de airear la información de
        // las balas que dispara, la usamos.
        // En realidad es redundante este control ya que simplemente el cañón que no debe hacer ese broadcast no tendrá ningún suscriptor
        //  a su evento OnCannonShot, pero lo dejamos para que quede claro que es el cañón el que decide si hace ese broadcast o no.
        if (BulletToFollow)
        {
            OnCannonShot?.Invoke(bullet);
        }
    }

    private void LoadCannon()
    {
        cannonLoaded = true;
        UIController.instance.SetCannonLoadStatus(true);
    }

    // void OnGUI()
    // {
    //     // Usamos BulletToFollow para que solo uno de los cañones modifique el IU
    //     string loaded = "Loaded";
    //     GUIStyle style = new GUIStyle();
    //     style.normal.textColor = Color.green;
    //     style.fontSize = 30;

    //     if (BulletToFollow)
    //     {
    //         if (!cannonLoaded)
    //         {
    //             loaded = "Not loaded";
    //             style.normal.textColor = Color.red;
    //         }
    //         GUI.Label(new Rect(Screen.width -140, Screen.height - 50, 130, 40), loaded, style);
    //     }
    // }
}
