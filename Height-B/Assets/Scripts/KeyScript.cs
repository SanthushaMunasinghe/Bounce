using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private LevelComplete levelComplete;
    [SerializeField] private GameObject parentObj;

    private bool isActivated = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Player" && !isActivated)
    //    {
    //        levelComplete.keyCount++;
    //        levelComplete.keyCountTxt.text = levelComplete.keyCount.ToString();
    //        isActivated = true;        
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isActivated)
        {
            //levelComplete.keyCount++;
            //gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("FresnelPower", 1);
            isActivated = true;
            StartCoroutine(DestroyObj());
        }
    }

    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(0.3f);

        parentObj.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(0.25f);

        Destroy(parentObj);
    }
}
