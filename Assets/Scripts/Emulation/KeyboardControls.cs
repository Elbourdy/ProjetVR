using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3;

    public float gravity = 0;

    void Update()
    {
        Vector3 inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputMovement *= _movementSpeed * Time.deltaTime;

        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 effectiveMovement = inputMovement.z * forward + inputMovement.x * right+Vector3.down * gravity * Time.deltaTime;

        transform.Translate(effectiveMovement, Space.World);
    }
}