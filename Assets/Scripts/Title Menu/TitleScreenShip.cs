using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenShip : MonoBehaviour
{

    public float speed = (float)30;
    public Vector3 pivot = new Vector3(50, 0, 50);

    void Start()
    {

    }


    void Update()
    {
        transform.RotateAround(pivot, -Vector3.one, speed * Time.deltaTime);
    }
}
