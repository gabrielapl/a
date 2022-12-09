using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [SerializeField] Transform target;
  Rigidbody2D rb2D;
  Animator enemyAnimation;
  public GameObject spellObject;
  public Entity entity;
  public GameObject experienceObject;
  public float minimumDistance = 1f;
  public bool combatCoroutine = false;
  public float attackDistance = 0.5f;
  public float attackTimer = 1;
  public float cooldown = 2;
  public bool dead = false;
  public bool inCombat = false;
  public bool isAttacking = false;
  [Header("Drop Reward")]
  public int rewardExperience = 10;
  public int lootGoldMin = 0;
  public int lootGoldMax = 10;
  public bool isMage = false;
  public void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    enemyAnimation = GetComponent<Animator>();
  }

  private void Update()
  {

    Vector2 positionTarget = this.target.position;
    Vector2 positionActuelle = this.transform.position;

    float distance = Vector2.Distance(positionTarget, positionActuelle);

    if (distance < attackDistance)
    {
      inCombat = true;
    }
    else
    {
      inCombat = false;
    }

    if (distance > minimumDistance && !inCombat)
    {

      Vector2 direction = positionTarget - positionActuelle;
      direction = direction.normalized;

      this.rb2D.velocity = (this.entity.speed * direction);

      enemyAnimation.SetBool("isWalking", true);
      enemyAnimation.SetFloat("input_x", rb2D.velocity.x);
      enemyAnimation.SetFloat("input_y", rb2D.velocity.y);


    }
    else
    {
      rb2D.velocity = Vector2.zero;
      enemyAnimation.SetBool("isWalking", false);
      isAttacking = false;
    }

    if (attackTimer > 0)
      attackTimer -= Time.deltaTime;

    if (attackTimer < 0)
      attackTimer = 0;

    if (target != null && inCombat && isMage)
    {
      // atacar
      if (!combatCoroutine)
        StartCoroutine(Attack());
    }
    else
    {
      combatCoroutine = false;
      isAttacking = false;
      StopCoroutine(Attack());
    }

    if (entity.currentHealth <= 0)
    {
      enemyAnimation.SetTrigger("deathing");
      Instantiate(experienceObject, transform.position, Quaternion.identity);
      Destroy(this.gameObject);
    }
  }

  private void FixedUpdate()
  {

  }



  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Spell")
    {
      entity.currentHealth -= 10;
      Destroy(collision.gameObject);
    }
  }

  IEnumerator Attack()
  {
    combatCoroutine = true;

    while (true)
    {
      yield return new WaitForSeconds(cooldown);

      if (target != null)
      {
        enemyAnimation.SetTrigger("attack");

        float distance = Vector2.Distance(target.transform.position, transform.position);

        if (distance <= attackDistance)
        {
          Debug.Log("Inimigo atacou o player, Dmg: ");
          GameObject spell = Instantiate(spellObject, transform.position, Quaternion.identity);
          Vector2 direction = (target.transform.position - spell.transform.position).normalized;
          //spell.transform.position = Vector2.MoveTowards(spell.transform.position, target.transform.position, 2f);
          spell.GetComponent<Rigidbody2D>().velocity = (direction * 2f);

          Destroy(spell, 5f);
        }
      }
    }
  }
}
