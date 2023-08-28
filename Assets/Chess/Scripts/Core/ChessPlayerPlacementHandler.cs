using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        public GameObject go;
        public int hitWho = 0; // 0 rest all , 1 pawn

        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
        }

        private void OnMouseDown()
        {
            go = gameObject;
        }

        private void Update()
        {
            if(go != null)
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                switch (go.name)
                {
                    case "King":
                        KingMove();
                        break;
                    case "Bishop1":
                    case "Bishop":
                        BishopMove();
                        break;
                    case "Pawn":
                    case "Pawn1":
                    case "Pawn2":
                    case "Pawn3":
                    case "Pawn4":
                    case "Pawn5":
                    case "Pawn6":
                    case "Pawn7":
                        hitWho = 1;
                        PawnMove();
                        hitWho = 0;
                        break;
                    case "Knight":
                    case "Knight1":
                        KnightMove();
                        break;
                    case "Rook":
                    case "Rook1":
                        RookMove();
                        break;
                    case "Queen":
                        RookMove();
                        BishopMove();
                        break;
                }
                go = null;
            }
        }

        private void KingMove()
        {
            int ini = row, inj = column;
            if(ini+1 < 8)
            {
                if (inj - 1 > -1 && Check(ini + 1, inj - 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini + 1, inj - 1);
                if (Check(ini + 1, inj))
                    ChessBoardPlacementHandler.Instance.Highlight(ini + 1, inj);
                if (inj +1 <8 && Check(ini + 1, inj + 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini + 1, inj + 1);
            }
            if (inj - 1 > -1 && Check(ini, inj - 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini , inj - 1);
            if (Check(ini, inj))
                    ChessBoardPlacementHandler.Instance.Highlight(ini , inj);
             if (inj + 1 < 8 && Check(ini , inj + 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini , inj + 1);


            if (ini - 1 > -1)
            {
                if (inj - 1 > -1 && Check(ini - 1, inj - 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini - 1, inj - 1);
                if (Check(ini - 1, inj))
                    ChessBoardPlacementHandler.Instance.Highlight(ini - 1, inj);
                if (inj + 1 < 8 && Check(ini - 1, inj + 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini - 1, inj + 1);
            }

        }

        private void BishopMove()
        {
            int ini = row, inj = column;
            int i, j;
            for(i = ini+1 , j=inj+1; i<8 && j<8  && Check(i,j);i++,j++)
            {
                ChessBoardPlacementHandler.Instance.Highlight(i, j);
            }

            for (i = ini+1 , j=inj-1; i<8 &&j > -1 && Check(i, j); i++ , j--)
            {
                ChessBoardPlacementHandler.Instance.Highlight(i, j);
            }
            for (i = ini - 1, j = inj + 1; i>-1 && j < 8 && Check(i, j); i--, j++)
            {
                ChessBoardPlacementHandler.Instance.Highlight(i, j);
            }

            for (i = ini - 1, j = inj - 1; i>-1 && j > -1 && Check(i, j); i--, j--)
            {
                ChessBoardPlacementHandler.Instance.Highlight(i, j);
            }

        }

        private void PawnMove()
        {
            if(row == 1 && Check(row+2, column) && Check(row + 1, column))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 1, column);
                ChessBoardPlacementHandler.Instance.Highlight(row + 2, column);
            }
            else if(row == 1 && Check(row + 1, column))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 1, column);
            }
            if(row >1 && row+1 <8  && column+1 <8  && (!Check(row+1 , column+1)) )
            {
                ChessBoardPlacementHandler.Instance.RedHighlight(row + 1, column +1);
            }

            if ( row > 1 && row + 1 < 8 && column - 1 >-1 && (!Check(row + 1, column - 1)))
            {
                ChessBoardPlacementHandler.Instance.RedHighlight(row + 1, column - 1);
            }


        }



        private void RookMove()
        {
            int ini = row, inj = column;
            int i, j;
            for(i=ini+1; i<8 && Check(i, inj); i++)
                ChessBoardPlacementHandler.Instance.Highlight(i,inj);
            for(j=inj+1; j<8 && Check(ini, j); j++)
                ChessBoardPlacementHandler.Instance.Highlight(ini , j);
            for (i = ini - 1; i >-1 && Check(i, inj); i--)
                ChessBoardPlacementHandler.Instance.Highlight(i, inj);
            for (j = inj - 1; j >-1 && Check(ini, j); j--)
                ChessBoardPlacementHandler.Instance.Highlight(ini, j);

        }


        private void KnightMove()
        {
            int ini = row, inj = column;
            int i, j,n;

            if(ini+2<8 )
            {
                if(inj+1 < 8 && Check(ini +2 , inj+1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini+2, inj+1);
                if (inj - 1 >-1 && Check(ini + 2, inj - 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini +2, inj -1);
            }
            if (ini + 1 < 8)
            {
                if (inj + 2 < 8 && Check(ini + 1, inj + 2))
                    ChessBoardPlacementHandler.Instance.Highlight(ini + 1, inj + 2);
                if (inj - 2 > -1 && Check(ini + 1, inj - 2))
                    ChessBoardPlacementHandler.Instance.Highlight(ini + 1, inj - 2);
            }
            if (ini -2 > -1)
            {
                if (inj + 1 < 8 && Check(ini - 2, inj + 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini-2, inj+1);
                if (inj - 1 > -1 && Check(ini - 2, inj - 1))
                    ChessBoardPlacementHandler.Instance.Highlight(ini - 2, inj-1);
            }
            if (ini - 1 > -1)
            {
                if (inj + 2 < 8 && Check(ini - 1, inj + 2))
                    ChessBoardPlacementHandler.Instance.Highlight(ini - 1, inj + 2);
                if (inj - 2 > -1 && Check(ini - 1, inj - 2))
                    ChessBoardPlacementHandler.Instance.Highlight(ini - 1, inj - 2);
            }

        }

        private bool Check(int i , int j)
        {
            String[] names = { "Queen", "Rook", "Rook1", "Bishop", "Bishop1", "Knight", "Knight1", "King", "Pawn", "Pawn1", "Pawn2", "Pawn3", "Pawn4", "Pawn5", "Pawn6", "Pawn7" };
            GameObject obj ;
            ChessPlayerPlacementHandler cs ;

            for(int d=0;d<names.Length; d++)
            {
                obj = GameObject.Find(names[d]);
                cs = obj.GetComponent<ChessPlayerPlacementHandler>();
                if (cs.row == i && cs.column == j)
                {
                    return false;
                }
            }

            String[] namesW = { "WQueen", "WRook", "WBishop", "WKnight", "WKing"};

            for (int d = 0; d < namesW.Length; d++)
            {
                obj = GameObject.Find(namesW[d]);
                cs = obj.GetComponent<ChessPlayerPlacementHandler>();
                if (cs.row == i && cs.column == j)
                {
                    if (hitWho == 1)
                        return false;
                    ChessBoardPlacementHandler.Instance.RedHighlight(i, j);
                    return false;
                }
            }

            return true;
        }


    }
}