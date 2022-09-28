using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public float xDistance = 6f;
    public float yDistance = 5f;
    public float zDistance = 22f;
    public Vector3 cameraRotation = new(-8.041f, -90.27f, 0); 


    private void Start()
    {
        cameraRotation = mainCamera.transform.eulerAngles;
    }



    // fiksira rotacijsku os kamere i prati igraca
    // --------------------------------------------
    void Update()
    {
        Vector3 playerPosition = player.transform.position;

        mainCamera.transform.position = new Vector3(playerPosition.x + xDistance, playerPosition.y + yDistance, playerPosition.z - zDistance);
        
        mainCamera.transform.eulerAngles = cameraRotation;
    }
}
