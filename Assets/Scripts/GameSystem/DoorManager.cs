using System.Collections;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public float openDuration = 0.8f;
    public float moveDistance = 3f;

    public float closeDelay = 2.0f;
    public float closeDuration = 0.5f;

    private bool isDoorOpen = false;
    private Vector3 closedPosition;
    private Vector3 openedPosition;

    void Start()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + -transform.right * moveDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isDoorOpen)
        {
            StartCoroutine(HandleDoorCycle());
        }
    }

    IEnumerator HandleDoorCycle()
    {
        isDoorOpen = true;

        yield return StartCoroutine(MoveDoor(closedPosition, openedPosition, openDuration));

        yield return new WaitForSeconds(closeDelay);

        yield return StartCoroutine(MoveDoor(openedPosition, closedPosition, closeDuration));

        isDoorOpen = false;
    }

    IEnumerator MoveDoor(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(start, end, t);

            yield return null;
        }

        transform.position = end;
    }
}