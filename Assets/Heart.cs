using System;
using UnityEngine.UI;

public class Heart
{
    private readonly Image _image;
    public const int HeartPiecesPerHeart = 4;
    private const float FillPerHeartPiece = 0.25f;

    public int FilledHeartPieces => CalculateFilledHeartPieces();

    public int EmptyHeartPieces => HeartPiecesPerHeart - (int) (_image.fillAmount * HeartPiecesPerHeart);

    public Heart(Image image)
    {
        _image = image;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0)
            throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberOfHeartPieces");
        _image.fillAmount += numberOfHeartPieces * FillPerHeartPiece;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0)
            throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberOfHeartPieces");
        _image.fillAmount -= numberOfHeartPieces * FillPerHeartPiece;
    }

    private int CalculateFilledHeartPieces()
    {
        return (int) (_image.fillAmount * HeartPiecesPerHeart);
    }
}