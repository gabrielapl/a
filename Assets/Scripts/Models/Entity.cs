using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [Header("Geral")]

    [Header("Health")]
    public float currentHealth = 0f;
    public float maxHealth = 0f;

    [Header("Mana")]
    public float currentMana = 0f;
    public float maxMana = 0f;

    [Header("Stamina")]
    public float currentStamina = 0f;
    public float maxStamina = 0f;

    [Header("Status")]
    public float speed = 0f;
}
