﻿using GoneuraOu.Logic;

namespace GoneuraOu.Search
{
    public static class MoveOrdering
    {
        public static int ScoreMove(this Board.Board pos, uint move, Searcher searcher)
        {
            if (searcher.PrincipalVariationTable[0][searcher.Ply] == move)
            {
                return 20000;
            }

            var sp = move.GetPieceType();

            if (move.GetCapture() == 1)
            {
                var tp = pos.PieceLoc[move.GetTarget()]!;
                return MvvLvaTable[(int)sp][(int)tp] + 500;
            }

            if (move.GetDrop() == 1)
            {
                return MvvLvaTable[(int)sp][0] + 450;
            }

            if (searcher.KillerMoves[0][searcher.Ply] == move)
                return 9000;
            if (searcher.KillerMoves[1][searcher.Ply] == move)
                return 8000;

            return searcher.HistoryMoves[move.GetPieceType()][move.GetTarget()];
        }

        //     P   G   S   R   B   K   +P  +S  +R  +B
        // P   107 307 207 507 407 907 307 307 707 607
        // G   105 305 205 505 405 905 305 305 705 605
        // S   106 306 206 506 406 906 306 306 706 606
        // R   103 303 203 503 403 903 303 303 703 603
        // B   104 304 204 504 404 904 304 304 704 604
        // K   100 300 200 500 400 900 300 300 700 600
        // +P  105 305 205 505 405 905 305 305 705 605
        // +S  105 305 205 505 405 905 305 305 705 605
        // +R  101 301 201 501 401 901 301 301 701 601
        // +B  102 302 202 502 402 902 302 302 702 602
        public static readonly int[][] MvvLvaTable =
        {
            new[]
            {
                107, 307, 207, 507, 407, 907, 307, 307, 707, 607,
                107, 307, 207, 507, 407, 907, 307, 307, 707, 607
            },
            new[]
            {
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605,
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605
            },
            new[]
            {
                106, 306, 206, 506, 406, 906, 306, 306, 706, 606,
                106, 306, 206, 506, 406, 906, 306, 306, 706, 606
            },
            new[]
            {
                103, 303, 203, 503, 403, 903, 303, 303, 703, 603,
                103, 303, 203, 503, 403, 903, 303, 303, 703, 603
            },
            new[]
            {
                104, 304, 204, 504, 404, 904, 304, 304, 704, 604,
                104, 304, 204, 504, 404, 904, 304, 304, 704, 604
            },
            new[]
            {
                100, 300, 200, 500, 400, 900, 300, 300, 700, 600,
                100, 300, 200, 500, 400, 900, 300, 300, 700, 600
            },
            new[]
            {
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605,
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605
            },
            new[]
            {
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605,
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605
            },
            new[]
            {
                101, 301, 201, 501, 401, 901, 301, 301, 701, 601,
                101, 301, 201, 501, 401, 901, 301, 301, 701, 601
            },
            new[]
            {
                102, 302, 202, 502, 402, 902, 302, 302, 702, 602,
                102, 302, 202, 502, 402, 902, 302, 302, 702, 602
            },
            new[]
            {
                107, 307, 207, 507, 407, 907, 307, 307, 707, 607,
                107, 307, 207, 507, 407, 907, 307, 307, 707, 607
            },
            new[]
            {
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605,
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605
            },
            new[]
            {
                106, 306, 206, 506, 406, 906, 306, 306, 706, 606,
                106, 306, 206, 506, 406, 906, 306, 306, 706, 606
            },
            new[]
            {
                103, 303, 203, 503, 403, 903, 303, 303, 703, 603,
                103, 303, 203, 503, 403, 903, 303, 303, 703, 603
            },
            new[]
            {
                104, 304, 204, 504, 404, 904, 304, 304, 704, 604,
                104, 304, 204, 504, 404, 904, 304, 304, 704, 604
            },
            new[]
            {
                100, 300, 200, 500, 400, 900, 300, 300, 700, 600,
                100, 300, 200, 500, 400, 900, 300, 300, 700, 600
            },
            new[]
            {
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605,
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605
            },
            new[]
            {
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605,
                105, 305, 205, 505, 405, 905, 305, 305, 705, 605
            },
            new[]
            {
                101, 301, 201, 501, 401, 901, 301, 301, 701, 601,
                101, 301, 201, 501, 401, 901, 301, 301, 701, 601
            },
            new[]
            {
                102, 302, 202, 502, 402, 902, 302, 302, 702, 602,
                102, 302, 202, 502, 402, 902, 302, 302, 702, 602
            }
        };
    }
}