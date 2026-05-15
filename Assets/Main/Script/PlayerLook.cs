using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 5f;

    [Header("Look")]
    public float sensitivity = 300f;
    public float minX = -80f;
    public float maxX = 80f;

    [Header("HeadBob")]
    public float bobSpeed = 10f;
    public float bobAmount = 0.05f;
    public float returnSpeed = 5f;

    public Transform cameraTransform;

    float xRotation = 0f;

    float bobTimer = 0f;
    Vector3 cameraStartPos;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = GetComponentInChildren<Camera>().transform;

        cameraStartPos = cameraTransform.localPosition;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
        HeadBob();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HeadBob()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f;

        if (isMoving)
        {
            // タイマーはリセットしない（ここ重要）
            bobTimer += Time.deltaTime * bobSpeed;

            float bobX = Mathf.Cos(bobTimer) * bobAmount;
            float bobY = Mathf.Sin(bobTimer * 2f) * bobAmount;

            Vector3 targetPos = cameraStartPos + new Vector3(bobX, bobY, 0f);

            cameraTransform.localPosition = Vector3.Lerp(
                cameraTransform.localPosition,
                targetPos,
                Time.deltaTime * 10f
            );
        }
        else
        {
            // なめらかに戻す（リセットしない）
            cameraTransform.localPosition = Vector3.Lerp(
                cameraTransform.localPosition,
                cameraStartPos,
                Time.deltaTime * returnSpeed
            );
        }
    }
}