using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Entity
{

  [Header("Geral")]
  public string name;
  public int level;

  [Header("Health")]
  public int currentHealth;
  public int maxHealth;

  [Header("Mana")]
  public int currentMana;
  public int maxMana;

  [Header("Stamina")]
  public int currentStamina;
  public int maxStamina;

  [Header("Stats")]
  public float speed = 2f;
}
