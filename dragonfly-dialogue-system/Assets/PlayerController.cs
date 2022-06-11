using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask interactableLayers;

    private Vector2 _movement;

    private Rigidbody2D _rigidbody;

    private void Update()
    {
        // movement
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        // interact
        if (!Input.GetKeyDown(KeyCode.E)) return;
        var interactableCollider = Physics2D.OverlapCircle(_rigidbody.position, 2f, interactableLayers);
        if (interactableCollider == null) return;

        if (interactableCollider.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }

    private void FixedUpdate()
    {
        if (_movement.magnitude != 0)
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_rigidbody.position, 2f);
    }
}
