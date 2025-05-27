using UnityEngine;

public class Coen_SpinnyScript : MonoBehaviour
{
    public float speed = 10f;


    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
