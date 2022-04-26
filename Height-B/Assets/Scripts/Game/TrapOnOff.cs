using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOnOff : MonoBehaviour
{
    private Vector3 initialScale;
    private Vector3 endScaleX;
    private Vector3 endScaleY;

    [SerializeField] private bool isHorizontal = false;

    [SerializeField] private float duration = 2.0f;

    IEnumerator Start()
    {
        initialScale = transform.localScale;
        endScaleX = new Vector3(0, initialScale.y, initialScale.z);
        endScaleY = new Vector3(initialScale.x, 0, initialScale.z);

        while (true)
        {
            if (isHorizontal)
            {
                yield return HorizontalScale(initialScale, endScaleY, duration);
                yield return new WaitForSeconds(2.0f);
                yield return HorizontalScale(endScaleY, initialScale, duration);
                yield return new WaitForSeconds(2.0f);
            }
            else
            {
                yield return HorizontalScale(initialScale, endScaleX, duration);
                yield return new WaitForSeconds(2.0f);
                yield return HorizontalScale(endScaleX, initialScale, duration);
                yield return new WaitForSeconds(2.0f);
            }
            
        }
    }

    void Update()
    {
        if (transform.localScale.x <= 0 || transform.localScale.y <= 0)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }
    }

    private IEnumerator HorizontalScale(Vector3 startScale, Vector3 endScale, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time);

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(startScale, endScale, i);
            yield return null;
        }
    }
}
