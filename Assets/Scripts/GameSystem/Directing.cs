using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Directing : MonoBehaviour
{
    [Header("전등 추락 연출")]
    public GameObject DelectLight;
    public GameObject DownLight;

    private bool isDirecting01;

    private void OnCollisionEnter(Collision collision)
    {
        {
            // 연출 01(전등 추락 연출)
            if (collision.gameObject.CompareTag("Directing01") && !isDirecting01)
            {
                Destroy(DelectLight.gameObject);
                DownLight.gameObject.SetActive(true);
                isDirecting01 = true;
            }
            else if (isDirecting01)
            {
                Debug.Log("이미 연출이 진행됬습니다.");
            }

        }
    }
}
