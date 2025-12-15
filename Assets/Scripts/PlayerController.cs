using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        // 新InputSystemでは Mouse.current を使う
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.nearClipPlane;
            targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            targetPosition.z = 0;
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                isMoving = false;
        }
    }
}