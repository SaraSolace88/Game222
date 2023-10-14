using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction = new Vector3(0, 1, 0);
    [SerializeField]
    private float speed = 10;

    private void Start()
    {
        StartCoroutine(nameof(WaitToDie));
    }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
