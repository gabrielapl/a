using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Entity entity;

  [Header("Spell")]
  public Spell spell;
  public float spellCastCooldownTime = 2f;
  float spellCastCooldown;

  private void Start()
  {
    spellCastCooldown = spellCastCooldownTime;
  }
  private void Update()
  {

    if (spellCastCooldown <= 0)
    {
      spellCastCooldown = 0;
    }
    else if (spellCastCooldown > 0)
    {
      spellCastCooldown -= Time.deltaTime;
    }

    if (Input.GetKeyDown(KeyCode.C) && spellCastCooldown <= 0)
    {
      spell.Cast();
      spellCastCooldown = spellCastCooldownTime;
    }
  }
}
