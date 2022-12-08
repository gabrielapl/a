using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Spell : MonoBehaviour
{
  public GameObject spellObject;

  public void Cast()
  {
    GameObject spell = Instantiate(spellObject, transform.position, Quaternion.identity);
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 myPos = transform.position;
    Vector2 direction = (mousePos - myPos).normalized;
    spell.GetComponent<Rigidbody2D>().velocity = direction * 2f;

    Destroy(spell, 1f);
  }

  
}
