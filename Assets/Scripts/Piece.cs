using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private bool whitePiece = true;
    public enum PieceType { Pawn, Tower, Knight, Bishop, Queen, King };
    [SerializeField] private PieceType pieceType = PieceType.Pawn;

    [SerializeField] private Sprite[] whitePieces;
    [SerializeField] private Sprite[] blackPieces;

    void Start()
    {
        int pieceId = 0;

        switch (pieceType)
        {
            case PieceType.Pawn:
                pieceId = 0;
                break;
            case PieceType.Tower:
                pieceId = 1;
                break;
            case PieceType.Knight:
                pieceId = 2;
                break;
            case PieceType.Bishop:
                pieceId = 3;
                break;
            case PieceType.Queen:
                pieceId = 4;
                break;
            case PieceType.King:
                pieceId = 5;
                break;
            default:
                Debug.LogError("Deu ruim");
                break;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = (whitePiece) ? whitePieces[pieceId] : blackPieces[pieceId];
    }

}
