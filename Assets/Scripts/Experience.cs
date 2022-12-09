using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      player.entity.level += 10;
      Destroy(this.gameObject);
    }
  }
}
