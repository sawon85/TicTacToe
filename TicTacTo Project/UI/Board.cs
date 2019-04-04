using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study._02_틱택토__최사원
{
    class Board
    {
        int[,] boardArr;  //board 배열
        int[,] sumArr;   //각 줄 마다 합계를 더할 배열
        

        public Board() {

            ResetBoardArr();
            ResetSumArr();
        }
        
        /*배열 초기화*/
        private void ResetBoardArr()
        {
            boardArr = new int[3, 3]
                    {
                        {0, 0, 0 },
                        {0, 0, 0 },
                        {0, 0, 0 }
                    };

        }
        
        private void ResetSumArr()
        {
           /// [i, j] 
           /// i가 0 -> j번째 행들의 합
           /// i가 1 -> j번째 열들의 합
           /// j가 3 -> 각 대각선 합
           /// 
            sumArr = new int[2, 4] 
            {
                {0, 0, 0, 0},  
                {0, 0, 0, 0}
            };
        }

        public int[,] ReturnBoard()
        {
            return boardArr;

        }

        public int[,] ReturnSumArr()  
        {
            return sumArr;
        }

        public void DrawBoard()  //게임이 시작하면 바로 보드를 그릴 함수
        {
         
            for (int top = 1; top <= 3; top++)
                for (int row = 1; row <= 3; row++)
                {
                    Console.SetCursorPosition(Constants.BOARD_X_FRAME + row* Constants.BOARD_X_RANGE, Constants.BOARD_Y_FRAME+top * Constants.BOARD_Y_RANGE);
                    Console.Write(top*3 + row -3);
                }

        }

        private void UpdateBoardArr(int who, int  place,int row, int column)  // 보드 배열 업데이트
        {
            boardArr[row, column] = who;

            sumArr[0, row] += who;
            sumArr[1, column] += who;

            if ((row + column) % 2 == 0) //대각선도 고려를 해야한다면
            {
                if (row == column) // 1번 5번 9번
                {
                    sumArr[1, 3] += who;
                }

                if (row != column || row ==1)  // 3번 5번 7번
                {
                    sumArr[0, 3] += who;
                }
            }         
        }

        private void DrawAfterTurn(int row, int column, char icon) // 누른 번호를 찾아가서 출력
        {
            Console.SetCursorPosition(Constants.BOARD_X_FRAME+(column+ 1) * Constants.BOARD_X_RANGE, Constants.BOARD_Y_FRAME+(row + 1) * Constants.BOARD_Y_RANGE);
            Console.Write(icon);
        }

        private bool IsGameFinished(int row, int column,int who) // 게임이 끝났는지 확인
        {
            if (sumArr[0, row] == who * 3 || sumArr[1, column] == who * 3 || sumArr[0, 3] == who * 3 || sumArr[1, 3] == who * 3) // 한 줄이 3개가 되면
                return true;

            return false;
        }
        
        public bool AfterTurnAndCheck(int who, int place,char icon) // 턴이 끝날 때마다 밖에서 호출 될 함수.
        {
    
            int column = place % 3; //각 번호의 행, 열 계산
            int row = place / 3 ;

            UpdateBoardArr(who, place, row, column);
            DrawAfterTurn(row, column, icon);

            if (IsGameFinished(row,column,who)) return true; //game이 끝났는 지 확인

            return false;
        }

    }
}
