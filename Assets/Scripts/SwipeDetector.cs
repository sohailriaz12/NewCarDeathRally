using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 levelBarStartPosition;
    private bool isDragging = false;

    public float minY = 50f;
    public float maxY = 2900f;

    private void Start()
    {
        levelBarStartPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchStartPos.z = levelBarStartPosition.z;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 touchEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchEndPos.z = levelBarStartPosition.z;
            Vector3 delta = touchEndPos - touchStartPos;

            // Calculate the new Y position
            float newY = levelBarStartPosition.y + delta.y;
            newY = Mathf.Clamp(newY, minY, maxY);

            // Update the position of the GameObject
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}