using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Settings")]
    public float surfaceHigh;
    public int maxIterations;

    [Header("Reference")]
    public GameObject objectToSpawn;
    public Collider areaCollider;

    private void Start()
    {
        GenerateRandomPosition();
    }

    private void GenerateRandomPosition()
    {
        Vector3 pointRandom;
        Vector3 pointOnSurface = Vector3.zero;

        bool pointFound = false;

        for (int i = 0; i < maxIterations; i++)
        {
            pointRandom = RandomPointInBounds(areaCollider.bounds, 2f) - transform.position;

            pointFound = GetRandomPointOnColliderSurface(pointRandom, out pointOnSurface);

            if (pointFound)
            {
                i++;
                GameObject newObject = Instantiate(objectToSpawn);
                newObject.transform.position = pointOnSurface - new Vector3(0, 1f, 0);
            }
        }
    }

    private bool GetRandomPointOnColliderSurface(Vector3 point, out Vector3 pointSurface)
    {
        Vector3 pointOnSurface = Vector3.zero;
        RaycastHit hit;
        bool pointFound = false;

        if(Physics.Raycast(point + surfaceHigh * transform.up, -transform.up * surfaceHigh, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                pointOnSurface = hit.point;
                pointFound = true;
            }
        }

        pointSurface = pointOnSurface;
        return pointFound;
    }

    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            0,
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }

    void OnDrawGizmos()
    {
        Bounds bounds;

        if (areaCollider != null)
        {
            bounds = areaCollider.bounds;

            Gizmos.color = new Color(1, 0, 0, 1f);
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}