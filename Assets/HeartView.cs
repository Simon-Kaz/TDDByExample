using UnityEngine;
using UnityEngine.UI;

public class HeartView : MonoBehaviour
{
    private Image _image;

    private Heart _heart;

    private void Start()
    {
        _image = GetComponent<Image>();
        _heart = new Heart(_image);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnGetHit();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnHealthItemPickup();
        }
    }

    public void OnGetHit()
    {
        _heart.Deplete(1);
    }

    public void OnHealthItemPickup()
    {
        _heart.Replenish(1);
    }
}
