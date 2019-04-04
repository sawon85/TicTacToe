using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study._02_틱택토__최사원
{
    class Computer : IUser
    {
        char icon;   // 버튼 출력시 출력할 아이콘
        string name; // Computer player의 네임 
        int turn;   // computer의 TURN 저장

        public Computer()
        {
            this.icon = '@'; //아이콘 고정
            turn = 0;
        }

        /* Interface 구현 */

        char IUser.ReturnIcon()
        {
            return this.icon;
        }

        void IUser.ResetName()
        {
            //컴퓨터를 출력하고 사용자에게 보여 줄 대기시간 1초 딜레이.

            name = "Computer";
            Console.Write("Computer");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
        }

        string IUser.ReturnName()
        {

            return this.name;
        }
        bool IUser.IsComputer()
        {

            return true;
        }

        int IUser.SelectNumber(int[,] boardArr, int[,] sumArr)
        {
            Thread.Sleep(400); // 너무 빨리 출력 되지 않기 위해서

            turn++;

            if (turn == 1)
                return FirstTurn(boardArr); //첫 번째 자리는 임의로 선택
            
            /*---컴퓨터의 자리 찾기---*/

            //1. 컴퓨터가 놓으면 이기는 자리 찾기

            for (int number = 0; number < 9; number++)
                if (FindPlace(boardArr,sumArr, number/3, number%3, Constants.USER2 * 2))
                    return number;

            //2. 없으면 상대방이 놓으면 이기는 자리 찾기
            // 단, 대각선은 일부러 보지 않도록 함.  -> 이길 수 없는 게임이 되기 때문.//

            for (int number = 0; number < 9; number++)
                if (FindPlace(boardArr, sumArr, number / 3, number % 3, Constants.USER1 * 2))
                    return number;

            //3.  한 줄에 컴퓨터만 놓여져 있는 자리 찾기.

            for (int number = 0; number < 9; number++)
                if (FindPlace(boardArr, sumArr, number / 3, number % 3, Constants.USER2))
                    return number;

            return 0;
        }


        /*computer 함수*/
        
        int FirstTurn(int[,] boardArr) //첫번째 턴
        {
            if (boardArr[1, 1] == 0)
                return 4; //중앙
                                 //혹은
            else //모서리
                return 8;        
        }

        bool FindPlace(int[,] boardArr, int[,] sumArr, int row, int column, int value)
        {
            if (!Blank(boardArr,row,column)) return false;

            if (sumArr[0, row] == value) return true;
            if (sumArr[1, column] == value) return true;

            if ((row + column) % 2 == 0) //대각선도 고려를 해야한다면
            {
                if (row == column) // 1번 5번 9번
                {
                    if (sumArr[1, 3] == -2) return true ;
                }

                if (row != column || row == 1)  // 3번 5번 7번
                {
                    if(sumArr[0, 3] == -2) return true;
                }
            }

            return false;
        }

        bool Blank(int[,] boardArr,int row, int column) //보드에 비어있는 칸인지 확인
        {
            if (boardArr[row, column] != 0) return false;
            return true;

        }
    }
}
