using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float velocity = 1f;
    private Vector3 direction = Vector3.zero;

    public void init(Vector2 _direction) {
        direction = _direction.normalized;
    }
	
	// Update is called once per frame
	void Update () {
        if (direction == Vector3.zero)
        {
            return;
        }
        Vector3 targetdirection = transform.position + direction;
        transform.position = Vector3.Lerp(transform.position, targetdirection, velocity * Time.deltaTime);
		//Move to direction
	}

    public void OnCollisionEnter2D(Collision2D collision) {
        Atom collisionAtom = collision.gameObject.GetComponent<Atom>();
        if (collisionAtom != null) {
            collisionAtom.addElectron();
        }
        Destroy(gameObject);
    }
}
