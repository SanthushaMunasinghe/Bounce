using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Dissappear());
    }

    private IEnumerator Dissappear()
    {
        GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
