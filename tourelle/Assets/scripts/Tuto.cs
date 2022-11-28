using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tween();
    }
    private void ResetPos()
    {
        transform.localPosition = new Vector3(22, -17, 127);
        Tween();
    }

    private void Tween()
    {
        transform.DOLocalMove(new Vector3(22, 668, 127), 1f).OnComplete(() => ResetPos());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
}
