using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales : MonoBehaviour
{
    [SerializeField] private GameObject[] Scales1;
    [SerializeField] private GameObject[] Scales2;
    public void ChangeState()
    {

        foreach (var item in Scales1)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in Scales2)
        {
            item.gameObject.SetActive(true);
        }
    }
}
