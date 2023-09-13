using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _velocity = 1.5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    private bool _jumped = false;
    
    private Rigidbody2D _rb;

    private PlayerControls _controls;

    private void Awake(){
        gameObject.name = $"Player {GetComponent<PlayerInput>().playerIndex.ToString()}";
        _controls = new PlayerControls();
    }

    private void Start(){
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if (_jumped){
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    private void OnEnable(){
        _controls.Enable();
    }

    private void OnDisable(){
        _controls.Disable();
    }

    public void OnJump(InputAction.CallbackContext context){
        _jumped = context.action.triggered;
    }

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed); 
    }
}