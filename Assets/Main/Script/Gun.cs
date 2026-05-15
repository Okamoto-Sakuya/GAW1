using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Gun Settings")]
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private float bulletSpeed = 40f;
    [SerializeField] private float range = 100f;

    private int currentAmmo;
    private bool isReloading;
    private float nextFireTime;

    void Start()
    {
        if (cam == null) cam = Camera.main;
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("クリックしてる");
        }
        if (isReloading) return;

        // ?? 左クリック長押しで連射
        if (Mouse.current.leftButton.isPressed)
        {
            if (Time.time >= nextFireTime && currentAmmo > 0)
            {
                Shoot();
                currentAmmo--;
                nextFireTime = Time.time + fireRate;
            }
        }

        // ?? Rキーでリロード
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (currentAmmo < maxAmmo)
                StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("リロード中...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;

        Debug.Log("リロード完了");
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, range))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(range);

        if (bulletPrefab != null && firePoint != null)
        {
            Vector3 dir = (targetPoint - firePoint.position).normalized;

            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.LookRotation(dir)
            );

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
                rb.velocity = dir * bulletSpeed;
            else
                Debug.LogError("Rigidbodyが弾に付いてない");
        }
        else
        {
            Debug.LogError("bulletPrefab or firePoint 未設定");
        }
    }
}