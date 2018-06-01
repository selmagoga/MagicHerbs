using UnityEngine;


public class CameraController : MonoBehaviour
{

    // The target we are following
    public GameObject target;
    // The distance in the x-z plane to the target
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    public float distance = 5.0f;
    public float xSpeed = 80.0f;
    public float ySpeed = 80.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float yRotationOffset = 20f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    float x = 0.0f;
    float y = 0.0f;

    Animation otherAnimator;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;


        Quaternion rotation = target.transform.rotation;

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

        Vector3 negDistance = new Vector3(0f, 0f, -distance);
        transform.position = target.transform.rotation * negDistance + target.transform.position + offset;
        Vector3 rotaionAngles = target.transform.rotation.eulerAngles;
        rotaionAngles[0] += cameraInclinationaAngle;
        rotation = Quaternion.Euler(rotaionAngles);
        transform.rotation = rotation;

        otherAnimator = target.GetComponent<Animation>();
    }

    float cameraInclinationaAngle = 25;
    void LateUpdate()
    {
        if (!RecipeeIngredients.gameEnded)
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))//if (Input.GetMouseButtonDown(0))
            {
                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

                Vector3 negDistance = new Vector3(0f, 0f, -distance);
                transform.position = target.transform.rotation * negDistance + target.transform.position + offset;
                Vector3 rotaionAngles = target.transform.rotation.eulerAngles;
                rotaionAngles[0] += cameraInclinationaAngle;
                Quaternion rotation = Quaternion.Euler(rotaionAngles);
                transform.rotation = rotation;
            }
            else {
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f; //pot face de sus in jos cu mouseul
                y = ClampAngle(y, yMinLimit, yMaxLimit);
                Vector3 rotaionAngles = target.transform.rotation.eulerAngles;
                rotaionAngles[0] += y;
                Quaternion rotation = Quaternion.Euler(rotaionAngles);

                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

                Vector3 negDistance = new Vector3(0f, 0f, -distance);
                transform.position = target.transform.rotation * negDistance + target.transform.position + offset;
                transform.rotation = rotation;
            }
        }

    } 
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}