using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private float speed; 
    void Start() => player = GameObject.FindWithTag("Player").transform;
    void Update() => Move();
	public void Move()
	{
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            transform.position += direction.normalized * speed * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}