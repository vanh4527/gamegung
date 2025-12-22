using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Đây là thân nhân vật (Capsule)

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Lấy dữ liệu chuột
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // XOAY LÊN XUỐNG (Tác động vào chính Object chứa Script này - Camera)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Khóa góc nhìn

        // Áp dụng xoay lên xuống cho Camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // XOAY TRÁI PHẢI (Tác động vào toàn bộ thân nhân vật)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}