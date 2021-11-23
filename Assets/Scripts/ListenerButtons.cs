using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenerButtons : MonoBehaviour
{
    [SerializeField]
    TrackMoney trackMoney;
    Image image;

    private void OnEnable()
    {
        trackMoney.selectedCategory += PaintItBlack;
        image = gameObject.GetComponent<Image>();
    }

    public void PaintItBlack()
    {
        image.color = new Color(.14f, .14f, .14f);
    }

    public void Selected()
    {
        trackMoney.selectedCategory.Invoke();
        image.color = new Color(1, .75f, 0);
    }
}
