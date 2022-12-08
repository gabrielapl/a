using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
  [HideInInspector] public Player player;
  public Animator playerAnimator;
  Rigidbody2D rb2D;

  float input_x = 0;
  float input_y = 0;
  bool isWalking = false;
  bool isDashing;
  bool canDash = true;
  Vector2 movement = Vector2.zero;

  public float dashPower = 24f;
  public float dashTime = 0.2f;
  public float dashCooldown = 1f;
  void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    player = GetComponent<Player>();
  }

  private void Update()
  {
    if (isDashing) return;

    input_x = Input.GetAxisRaw("Horizontal");
    input_y = Input.GetAxisRaw("Vertical");
    isWalking = (input_x != 0 || input_y != 0);
    movement = new Vector2(input_x, input_y);

    if (isWalking)
    {
      playerAnimator.SetFloat("input_x", input_x);
      playerAnimator.SetFloat("input_y", input_y);
    }

    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
    {
      StartCoroutine(Dash());

    }

    playerAnimator.SetBool("isWalking", isWalking);
  }
  private void FixedUpdate()
  {

    if (!isDashing)
    {
      rb2D.MovePosition(rb2D.position + movement * player.entity.speed * Time.fixedDeltaTime);
    }

  }

  IEnumerator Dash()
  {
    canDash = false;
    isDashing = true;
    float originalGravity = rb2D.gravityScale;
    rb2D.gravityScale = 0f;

    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 myPos = transform.position;
    Vector2 direction = (mousePos - myPos).normalized;

    rb2D.velocity = new Vector2(direction.x * dashPower, direction.y * dashPower);

    yield return new WaitForSeconds(dashTime);

    rb2D.gravityScale = originalGravity;
    isDashing = false;

    yield return new WaitForSeconds(dashCooldown);
    canDash = true;
  }
}
