using UnityEngine;

public class SparkMoving : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    public float Speed;
    Vector2 characterPosition;
    public static float characterPositionX;
    public float rotationSpeed;
    [SerializeField]
    private GameObject Particle;

    private void Start()
    {
        characterPositionX = character.transform.position.x + 0.6f;
    }

    void Update()
    {
        if (HPBar.HP > 0.3f)
        {
            characterPosition = new Vector2(characterPositionX, character.transform.position.y + 0.6f);
        }
        else
        {
            characterPosition = new Vector2(character.transform.position.x, character.transform.position.y - 0.2f);
        }
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, characterPosition, Speed * Time.deltaTime);
        Particle.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed, Space.Self);
    }
}
