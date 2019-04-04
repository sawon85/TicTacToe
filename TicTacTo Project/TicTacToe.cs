using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study._02_틱택토__최사원
{
    class TicTacToe
    {
        IUser user1; //기본은 IUser으로 선언
        IUser user2;
        Board board;

        /*WARNING 문구를 저장*/
        string sameNameWarning = " 첫 번 째 유 저 와 이 름 이 겹 치 지 않 게 해 주 세 요 !    ";
        string longNameWarning = " 이 름 은 여 덟 글 자 까 지 만 가 능 합 니 다 !                ";
        string computerNameWarning = " Computer와 같 은 이 름 을 사 용 하 지 마 세 요 !    ";


        public TicTacToe(char button)
        {
            board = new Board();

            switch (button)
            {
                case '1':  // 1이 입력 들어오면 Human class 두개 할당
                    user1 = new Human('A');
                    user2 = new Human('B');
                    break;

                case '2': // 2가 입력 들어오면 Human 과 Computer class로 할당
                    user1 = new Human('A');
                    user2 = new Computer();
                    break;
            }

            ResetName();
        }

        public string ReturnUser1Name()
        {
            return user1.ReturnName();
        }

        public string ReturnUser2Name()
        {
            return user2.ReturnName();
        }

        public void ResetName() // 이름 입력 받기
        {
            string warning;

            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME);
            Console.Write(" 첫 번 째 유 저 이 름 을 입 력 해 주 세 요 :  ");
         
            while(true)
            {
                user1.ResetName(); //USER1 이름 입력 

                if (user1.ReturnName().Length > 8)
                    warning = longNameWarning; // 이름이 길다는  주의 사항

                else if (user1.ReturnName() == "Computer")
                    warning = computerNameWarning; // 컴퓨터와 이름이 같으면 주의 사항

                else
                      break; //  주의 사항이 없으면 끝

                Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME+2);
                Console.Write(warning);
                Console.SetCursorPosition(Constants.BUTTON_X_FRAME + 46, Constants.BUTTON_Y_FRAME);
                Console.Write("                                                      ");
                Console.SetCursorPosition(Constants.BUTTON_X_FRAME + 46, Constants.BUTTON_Y_FRAME);

            }

            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME + 2);
            Console.Write("                                                      ");
            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME+4);
            Console.Write(" 두 번 째 유 저 이 름 을 입 력 해 주 세 요 :  ");

            while(true)
            {
                user2.ResetName();

                if (user1.ReturnName() == user2.ReturnName()) //user1과 user2와 이름이 같으면 주의
                    warning = sameNameWarning;


                else if (user2.ReturnName().Length > 8) // 이름이 길면 주의 
                    warning = longNameWarning;
                
                else if (user2.ReturnName() == "Computer" && !user2.IsComputer()) // 이름이 Computer이며 user2가 컴퓨터가 아니면
                    warning = computerNameWarning; // 컴퓨터 이름 주의

                else
                    break;

                    Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME + 6);
                    Console.Write(warning);
                    Console.SetCursorPosition(Constants.BUTTON_X_FRAME + 46, Constants.BUTTON_Y_FRAME + 4);
                    Console.Write("                                                      ");
                    Console.SetCursorPosition(Constants.BUTTON_X_FRAME + 46, Constants.BUTTON_Y_FRAME + 4);

            } 
        }

        private void PrintWhoseTurn(string name)  // 누구 차례인지 가이드라인 출력
        {
            Console.SetCursorPosition(Constants.GUIDE_X_FRAME, Constants.GUIDE_Y_FRAME);
            Console.Write( name + " 님의 차례 입니다.");

        }

        private void ReplaceInputCusor()  // 입력 커서 초기화
        {
            Console.SetCursorPosition(Constants.INPUT_X_FRAME - 14, Constants.INPUT_Y_FRAME);
            Console.Write("입력하세요 :  ");
            Console.SetCursorPosition(Constants.INPUT_X_FRAME, Constants.INPUT_Y_FRAME);
        }
        
        private void ResetGuide() //가이드라인 초기화
        {
            
            Console.SetCursorPosition(Constants.GUIDE_X_FRAME, Constants.GUIDE_Y_FRAME);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition(Constants.GUIDE_X_FRAME2, Constants.GUIDE_Y_FRAME2);
            Console.WriteLine("                                                         ");
        }

        public int PlayTicTacToe()
        {
            int selected;

            for(int turn =0; turn < 9;turn++)
            {

                if (turn == 0) board.DrawBoard(); //첫 턴 그리기.

                PrintWhoseTurn(user1.ReturnName());

                /*---user1 Turn---*/
                ReplaceInputCusor(); //번호를 입력할 커서 위치로
                selected = user1.SelectNumber(board.ReturnBoard(),board.ReturnSumArr()); //숫자 선택

                // 게임이 끝났으면 user1로 코드 반환
                if (board.AfterTurnAndCheck(Constants.USER1, selected, user1.ReturnIcon()))
                    return Constants.USER1;

                
                ResetGuide(); //가이드라인 초기화

                /*---게임 끝 체크--*/
                turn++;
                if (turn == 9) break;


                /*---user2 Turn---*/
                PrintWhoseTurn(user2.ReturnName());

                ReplaceInputCusor();  // 번호를 입력할 커서 위치로
                selected = user2.SelectNumber(board.ReturnBoard(),board.ReturnSumArr()); // 숫자 선택

                //게임이 끝났으면 user2로 코드 반환
                if (board.AfterTurnAndCheck(Constants.USER2, selected, user2.ReturnIcon()))
                    return Constants.USER2;

                ResetGuide(); //가이드라인 초기화

            }

            return Constants.DRAW; //무승부 코드 반환
        }
    }
}
