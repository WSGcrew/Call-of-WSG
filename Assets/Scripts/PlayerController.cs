using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Oblicz kierunek poruszanai się w modelu 3D
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Ostateczny keirunek poruszania
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Zatwierdz poruszanie sie
        motor.Move(_velocity);

        //Oblicz kierunek dla vektora 3D (obrot)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Zatwierdz obrot
        motor.Rotate(_rotation);


        //Oblicz kierunek kamery vektora 3D (obrot)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //Zatwierdz obrot
        motor.RotateCamera(_cameraRotation);

    }
}
