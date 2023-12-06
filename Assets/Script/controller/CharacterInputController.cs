using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : CharacterController
{
    private Camera _camera;
    private bool isFacingRight = true;
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log("OnMove" +  value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            FlipCharacter(newAim.x);
            CallLookEvent(newAim);
        }
    }

    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
    }

    public void FlipCharacter(float direction)
    {
        if ((direction > 0 && !isFacingRight) || (direction < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
