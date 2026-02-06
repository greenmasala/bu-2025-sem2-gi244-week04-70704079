using UnityEditor;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    float cameraSize;
    float belowCamera;
    float aboveCamera;

    private void Awake()
    {
        cameraSize = Camera.main.orthographicSize;
        belowCamera = cameraSize * -1;
        aboveCamera = cameraSize + 10;
        Debug.Log(belowCamera);
        Debug.Log(aboveCamera);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > aboveCamera || transform.position.z < belowCamera)
        {
            Destroy(gameObject);
        }

        //else if (transform.position.z < -10)
        //{
        //    Destroy(gameObject);
        //}
    }
}
