using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public ObjectPool pool;


    public void ShowEffect(Vector3 position)
    {

        int i = Random.Range(0, pool.list.Count);
        var p = pool.list[i];
        p.transform.position = position;
        p.gameObject.SetActive(true);
        Debug.Log(p + " " + i);
        p.GetComponent<ParticleSystem>().Play();
    }


}
