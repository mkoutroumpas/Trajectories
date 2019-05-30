using UnityEngine;
using System.Linq;

public class TerrainObject : MonoBehaviour
{
    private readonly string[] _BallDesignationLiterals = { "Ball", "Sphere" };

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == null)
            return;

        if (_BallDesignationLiterals.Contains(collision.gameObject.name) || _BallDesignationLiterals.Contains(collision.gameObject.tag))
        {
            LaunchableObject launchableObject = collision.gameObject.GetComponent<LaunchableObject>();
            if (launchableObject != null)
            {
                launchableObject.ReceiveCollision(collision);
            }
        }
    }
}
