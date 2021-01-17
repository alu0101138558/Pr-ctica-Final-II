using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
  // Start is called before the first frame update
  public Rigidbody platformRB;
  public Transform[] positions;
  public float speed = 5;
  public bool moveToNext = true;
  public float waitTime = 1f;
  private int currentPosition = 0;
  private int nextPosition = 1;

  void Update()
  {
    Movement();
  }

  void Movement() {
    if (moveToNext) {
      StopCoroutine(waitForMove(0));
      platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, positions[nextPosition].position, speed * Time.deltaTime));
    }
    if (Vector3.Distance(platformRB.position, positions[nextPosition].position) <= 0) {
      StartCoroutine(waitForMove(waitTime));
      currentPosition = nextPosition;
      nextPosition = (nextPosition + 1) % positions.Length;
    }
  }

  IEnumerator waitForMove(float time) {
    moveToNext = false;
    yield return new WaitForSeconds(time);
    moveToNext = true;
  }

}
