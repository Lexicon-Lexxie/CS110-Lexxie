using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        float x = 0f, z = 0f;
        if (kb.leftArrowKey.isPressed || kb.aKey.isPressed) x -= 1f;
        if (kb.rightArrowKey.isPressed || kb.dKey.isPressed) x += 1f;
        if (kb.upArrowKey.isPressed || kb.wKey.isPressed) z += 1f;
        if (kb.downArrowKey.isPressed || kb.sKey.isPressed) z -= 1f;

        transform.Translate(new Vector3(x, 0f, z) * speed * Time.deltaTime, Space.World);
    }
}