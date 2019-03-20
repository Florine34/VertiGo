using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Es.InkPainter.InkCanvas>() != null)
            Destroy(this.gameObject);
    }
}
