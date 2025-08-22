using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Target;
    public Vector3 Offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Target == null) { return; } // full stop dont do anything else

        transform.position = Target.transform.position + Offset;
    }
}
