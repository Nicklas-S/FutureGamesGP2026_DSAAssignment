using Environment;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        // this is a test change for the git lecture
        [SerializeField]
        private Animator animator = null;

        [Header("Input")]
        [SerializeField]
        private InputActionReference moveAction = null;
        [SerializeField]
        private InputActionReference interactAction = null;
        [SerializeField]
        private InputActionReference rotationAction = null;

        [Header("Movement")]
        [SerializeField]
        private float movementSpeed = 10f;
       [Header("Interaction")]
        [SerializeField]
        private float interactionRange = 5f;
        [Header("Rotation")]
        [SerializeField]
        private float rotationSpeed = 90f;

        private Vector2 movementInput = Vector2.zero;
        private float rotationInput = 0f;

        private void Awake() {
            if(!animator) {
                Debug.LogError("Animator not set");
                return;
            }

            if(!moveAction || !interactAction) {
                Debug.LogError("Input actions not set");
                return;
            }

            moveAction.action.performed += OnMove;
            moveAction.action.canceled += OnMove;
            rotationAction.action.performed += OnRotate;
            rotationAction.action.canceled += OnRotate;

            interactAction.action.performed += OnInteract;
        }

        private void OnMove(InputAction.CallbackContext context) {
            movementInput = context.ReadValue<Vector2>();
            animator.SetBool("bIsMoving", movementInput != Vector2.zero);
        }

        private void OnRotate(InputAction.CallbackContext context) {
            //rotationInput = context.ReadValue<Vector2>().x == 0 ? 0 : Mathf.Sign(context.ReadValue<Vector2>().x); (Does the same as lines 58 - 61)
            if(context.ReadValue<Vector2>().x == 0)
                rotationInput = 0;
            else
                rotationInput = Mathf.Sign(context.ReadValue<Vector2>().x);

        }

        private void OnInteract(InputAction.CallbackContext context) {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionRange);
            IInteractable interactable = hit.collider?.gameObject.GetComponentInParent<IInteractable>();
            if(interactable != null) {
                interactable.OnInteract();
            }
        }

        private void Update() {
            transform.position += (transform.forward * movementInput.y + transform.right * movementInput.x) * (movementSpeed * Time.deltaTime);
            transform.eulerAngles += (new Vector3(0, rotationSpeed * Time.deltaTime * rotationInput, 0));
            }


        private void OnEnable() {
            moveAction.action.Enable();
            interactAction.action.Enable();
        }

        private void OnDisable() {
            moveAction.action.performed -= OnMove;
            moveAction.action.canceled -= OnMove;

            interactAction.action.performed -= OnInteract;

            moveAction.action.Disable();
            interactAction.action.Disable();
        }
    }
}
