using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calculation : MonoBehaviour
{
    //���� Scene�� �ҷ��� �ʱ�ȭ�Ѵ�.
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
}
