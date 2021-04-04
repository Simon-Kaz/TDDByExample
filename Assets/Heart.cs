using System;
using UnityEngine.UI;

public class Heart
{
    private readonly Image _image;
    private const float FillPerHeartPiece = 0.25f;

    public Heart(Image image)
    {
        _image = image;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        if(numberOfHeartPieces < 0)
            throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberOfHeartPieces");
        _image.fillAmount += numberOfHeartPieces * FillPerHeartPiece;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if(numberOfHeartPieces < 0)
            throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberOfHeartPieces");
        _image.fillAmount -= numberOfHeartPieces * FillPerHeartPiece;
    }
}