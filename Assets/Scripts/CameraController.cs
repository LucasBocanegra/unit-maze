using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject player;
    public static float rotationAngle = 0;
	float speed = 10f;
	private Vector3 offset;
    private float rotateSensitivity = 0.5f;

	void Start()
	{
		transform.rotation = Quaternion.Euler(0, 0, 0);
		player.transform.rotation = Quaternion.Euler(0, (180), 0);

		offset = transform.position - player.transform.position;
	}

	void LateUpdate()
	{

		transform.position = player.transform.position;

        if (Input.GetKey(KeyCode.Q))
		{
			float my_y = transform.rotation.eulerAngles.y;
			transform.rotation = Quaternion.Euler(0, (my_y - rotateSensitivity), 0);
			player.transform.rotation = Quaternion.Euler(0, (my_y - rotateSensitivity), 0);
            rotationAngle = my_y - 5;
		}

		if (Input.GetKey(KeyCode.E))
		{
			float my_y = transform.rotation.eulerAngles.y;
			transform.rotation = Quaternion.Euler(0, (my_y + rotateSensitivity), 0);
			player.transform.rotation = Quaternion.Euler(0, (my_y + rotateSensitivity), 0);
            rotationAngle = my_y + rotateSensitivity;
		}

	}
}

