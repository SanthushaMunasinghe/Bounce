using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTrap : MonoBehaviour
{
    public float duration = 3;
    private float elapsedTime;

    public Vector3 endScale;
    public Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        startLerping();
    }

    private void startLerping()
    {
        elapsedTime += Time.deltaTime;

        float percentageComplete = elapsedTime / duration;

        transform.localScale = Vector3.Lerp(startScale, endScale, percentageComplete);
    }
}
