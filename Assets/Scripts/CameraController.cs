using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector2 deadZoneSize;
    public float smooth = 5f;

    void LateUpdate()
    {
        Vector3 camPos = transform.position;
        Vector3 targetPos = target.position;

        Vector3 localPos = transform.InverseTransformPoint(targetPos);

        float dx = Mathf.Max(0, Mathf.Abs(localPos.x) - deadZoneSize.x / 2);
        float dy = Mathf.Max(0, Mathf.Abs(localPos.y) - deadZoneSize.y / 2);

        Vector3 move = new Vector3(
            dx * Mathf.Sign(localPos.x),
            dy * Mathf.Sign(localPos.y),
            0
        );

        Vector3 worldMove = transform.TransformVector(move);

        transform.position = Vector3.Lerp(
            camPos,
            camPos + worldMove,
            smooth * Time.deltaTime
        );
    }
}
