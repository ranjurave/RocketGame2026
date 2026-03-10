using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    [SerializeField]InputActionAsset inputActions;
    InputAction rocketMove;
    InputAction rotateRocket;
    Rigidbody rocketRB;

    [SerializeField] float thrustPower = 1000.0f;
    [SerializeField] float rotationPower = 50.0f;

    public int coins = 0;

    private void Awake() {
        rocketMove = InputSystem.actions.FindAction("Thruster");
        rotateRocket = InputSystem.actions.FindAction("RotateRocket");
        rocketRB = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable() {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Update() {
        if (rocketMove.IsPressed()) {
            rocketRB.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }

        float Rotation = rotateRocket.ReadValue<float>();
        transform.Rotate(0.0f, 0.0f, Rotation * Time.deltaTime * rotationPower);
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name );
        if (collision.gameObject.CompareTag("Ground")) {
            Debug.Log("Game over.....");
        }
    }
}
