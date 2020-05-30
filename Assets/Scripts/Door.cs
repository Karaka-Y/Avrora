using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 destination;
    public Transform charTransform;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other != null && other.gameObject.tag == "Player"){
            StartCoroutine("Delay");
        }
    }
    IEnumerator Delay(){
        yield return new WaitForSeconds(0.5f);
        charTransform.position = destination;
    }
}
