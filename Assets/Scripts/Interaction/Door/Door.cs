using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _leftDoor;
    [SerializeField] private GameObject _rightDoor;
    [Space]
    [SerializeField] private float _angleRotation;
    [SerializeField] private float _speedRotation;

    public void Open()
    {
        Quaternion targetRotationLeft = Quaternion.Euler(0, _angleRotation, 0);
        Quaternion targetRotationRight = Quaternion.Euler(0, -_angleRotation, 0);

        StartCoroutine(OpenDoor(_leftDoor, targetRotationLeft));
        StartCoroutine(OpenDoor(_rightDoor, targetRotationRight));
    }

    private IEnumerator OpenDoor(GameObject door, Quaternion targetRotation)
    {

        Quaternion startRotation = door.transform.rotation;

        float startTime = Time.time;
        float endTime = startTime + _speedRotation;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / _speedRotation;

            door.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, progress);
            yield return null;
        }

        door.transform.rotation = targetRotation;
    }
}
