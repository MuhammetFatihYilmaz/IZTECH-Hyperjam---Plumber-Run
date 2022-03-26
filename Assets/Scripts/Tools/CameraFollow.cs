using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject playerObj;
    [SerializeField] Vector3 offset;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerObj.transform.position + offset;
    }
}
