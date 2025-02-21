using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;

    [SerializeField, Range(1f, 1000f)] float speedMove;
    [SerializeField, Range(1f, 100f)] float speedUp;

    void Update()
    {
        ControlPlayer();
    }

    void ControlPlayer()
    {
        gameObject.transform.TryGetComponent(out Transform cube);

         Vector3 movePosition = ((cube.transform.right * left.LocalPositionEnd.x / 15000f)
         + (Vector3.zero)
         + (cube.transform.forward * left.LocalPositionEnd.y) / 15000f);

        transform.position += movePosition * speedMove;

        transform.Rotate((Vector3.up * right.LocalPositionEnd.x / 2000f) * speedUp);
    }
}
