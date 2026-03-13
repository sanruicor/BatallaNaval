using UnityEngine;
using UnityEngine.InputSystem;

public class PanCameraController : MonoBehaviour
{
    [SerializeField] private Transform playerShip;
    [SerializeField] private Transform playerCannonCabinPivot;

    [Tooltip("Referencia al CannonShot cuyas balas va a seguir la cámara")]
    [SerializeField] private CannonShot cannon;

    [SerializeField] private Camera panCamera;
    private Bullet bulletToFollow;
    private Quaternion startRotation;
    private float startFieldOfView;


    void Start()
    {
        cannon.OnCannonShot += CannonShot;
        startFieldOfView = panCamera.fieldOfView;
        startRotation = panCamera.transform.rotation;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = playerShip.position.x;
        newPosition.z = playerShip.position.z;
        transform.position = newPosition;

        Vector3 newEulerAngles = transform.eulerAngles;
        newEulerAngles.y = playerCannonCabinPivot.eulerAngles.y;
        transform.eulerAngles = newEulerAngles;

        if (bulletToFollow != null)
        {
            // Seguimiento de la bala
            panCamera.transform.LookAt(bulletToFollow.transform);
            // cambio de enfoque (zoom)
            panCamera.fieldOfView = 1500f / (bulletToFollow.transform.position - panCamera.transform.position).magnitude;
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SwitchCameras();
        }
    }

    private void SwitchCameras()
    {
        /*
        * Rect auxViewPort = panCamera.rect;
        * panCamera.rect = Camera.main.rect;
        * Camera.main.rect = auxViewPort;
        */
        (Camera.main.rect, panCamera.rect) = (panCamera.rect, Camera.main.rect); // esto es igual a lo anterior
        (Camera.main.depth, panCamera.depth) = (panCamera.depth, Camera.main.depth);
    }

    private void CannonShot(Bullet bullet)
    {
        Debug.Log("[PanCameraController] CannonShot");
        if (bulletToFollow != null)
        {
            bulletToFollow.OnBulletExploded -= OnBulletExploded;
        }
        bulletToFollow = bullet;
        bullet.OnBulletExploded += OnBulletExploded;
    }

    private void OnBulletExploded(Bullet b)
    {
        Debug.Log("[PanCameraController] OnBulletExploded");
        if (b == bulletToFollow)
        {
            b.OnBulletExploded -= OnBulletExploded;

            bulletToFollow = null;
            Invoke(nameof(RestorePanCamera), 2f);
        }
    }

    private void RestorePanCamera()
    {
        panCamera.fieldOfView = startFieldOfView;
        panCamera.transform.rotation = startRotation;
    }
}
