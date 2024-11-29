using UnityEngine;
using UnityEngine.UI;

public class KeyIndicator : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private Image image;

    private void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();

        }
    }

        private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            image.color = Color.yellow;
        }
        else if (Input.GetKeyUp(key))
        {
            image.color = Color.white;
        }
    }
}
