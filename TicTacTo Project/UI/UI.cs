using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study._02_틱택토__최사원
{
    class UI
    {
        TicTacToe playingGame; //틱택톡 게임 선언
        ScoreBoard scoreBoard;


        public UI()
        {
            Console.CursorVisible = false; //커서 제거
            scoreBoard = new ScoreBoard (); //스코어보드 클래스 생성
        }

     
        private void WhoWin(int whoWin, string player1, string player2)  // 게임 결과가 나왔을 때 호출될 함수
        {

            Console.SetWindowSize(94, 35);

            Console.Clear();
            Console.SetCursorPosition(Constants.WIN_X_FRAME, Constants.WIN_Y_FRAME);
            string text = System.IO.File.ReadAllText(@"text\win.txt", Encoding.Default);  // txt에서 문자를 가져와서 출력
            Console.WriteLine("{0}", text);

            /* --누가 이겼는 지 출력--*/
            Console.SetCursorPosition(Constants.WIN_X_FRAME+35, Constants.WIN_Y_FRAME+5);

            if (whoWin != Constants.DRAW)
            {
                string winner, loser;
                if(whoWin == Constants.USER1)
                {
                    winner = player1;
                    loser = player2;
                }
                else
                {
                    winner = player2;
                    loser = player1;
                }

                Console.WriteLine(winner + "님께서 ");
                Console.SetCursorPosition(Constants.WIN_X_FRAME + 47, Constants.WIN_Y_FRAME + 8);
                Console.WriteLine("이겼습니다!");

            }

            /*--무승부--*/
            else
            {
                Console.WriteLine("무승부입니다.");
            }

            /* SCOREBOARD에 값을 넘겨 줌.*/
            scoreBoard.InsertSocre(player1, player2, whoWin);
        }

        private void Outtro()
        {

            /*--다시 첫 메뉴로 돌아갈 것 인 지 안내해주는 UI--*/
            Console.SetCursorPosition(Constants.WIN_X_FRAME + 35, Constants.WIN_Y_FRAME + 16);
            Console.Write("[ P R E S S      K E Y ]");
            Console.SetCursorPosition(Constants.WIN_X_FRAME + 25, Constants.WIN_Y_FRAME + 19);
            Console.Write(" GO TO THE MAIN (Y/N)");

            string yesOrNo;

            while (true)
            {
                Console.SetCursorPosition(Constants.WIN_X_FRAME + 50, Constants.WIN_Y_FRAME + 19);
                Console.Write("                                       ");
                Console.SetCursorPosition(Constants.WIN_X_FRAME + 50, Constants.WIN_Y_FRAME + 19);

                yesOrNo = Console.ReadLine();

                switch (yesOrNo)
                {
                    case "Y":
                    case "y":
                        Console.Clear();
                        return;

                    case "N":
                    case "n":
                        Environment.Exit(0);  //프로그램 종료
                        break;

                    default:
                        break;
                }
            }
        }

        private void PrintTitleUI()
        {

            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME-2);
            Console.WriteLine("■□■□■□■□■□■□■□■□■");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME - 1);
            Console.WriteLine("□                              □");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME);
            Console.WriteLine("■     T i c   T a c  T o e     ■");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME + 1);
            Console.WriteLine("□                              □");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME + 2);
            Console.WriteLine("■    버 튼 을 입 력 하 세 요   ■");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME + 3);
            Console.WriteLine("□                              □");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME + 4);
            Console.WriteLine("■□■□■□■□■□■□■□■□■");

        }

        private void PrintButtonUI()
        {
            
            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME);
            Console.WriteLine("■   1.   U S E R 1        VS       U S E R 2   □");
            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME+2);
            Console.WriteLine("■   2. C O M P U T E R    VS       Y  O  U     □");
            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME+4);
            Console.WriteLine("■   3.                 Ranking                 □");

            Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME + 9);
            Console.Write("입 력 하 세 요 : ");

        }

        private void GetNameUI()
        {
            Console.Clear();
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME);
            Console.WriteLine("■□■□■□■□■□■□■□■□■");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME + 1);
            Console.WriteLine("■   당 신  의   이 름  은  ?   ■");
            Console.SetCursorPosition(Constants.TITLE_X_FRAME, Constants.TITLE_Y_FRAME + 2);
            Console.WriteLine("■□■□■□■□■□■□■□■□■");

        }

        private void GameUI()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            string text = System.IO.File.ReadAllText(@"text\ui.txt",Encoding.Default); // 저장된 txt에서 game ui를 가져와 출력
            Console.WriteLine("{0}", text);
        }

        private void ScoreBoardUI()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            string text = System.IO.File.ReadAllText(@"text\score.txt", Encoding.Default); // 저장된 txt에서 scoreboard ui를 가져와서 출력
            Console.WriteLine("{0}", text);
        }

        public void Menu()
        {

            string number;

            while (true)
            {
                Console.SetWindowSize(100, 30);
                PrintTitleUI();
                PrintButtonUI();
                number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        GetNameUI(); //이름을 입력할 UI 출력
                        playingGame = new TicTacToe('1');  // USER VS USER로 생성
                        break;

                    case "2":
                        GetNameUI(); //이름을 입력할 UI 출력
                        playingGame = new TicTacToe('2'); // USER VS COMPUTER로 생성
                        break;

                    case "3":
                        ScoreBoardUI();  //스코어보드 UI 출력
                        scoreBoard.PrintScoreBoard(); //스코어 출력
                        Outtro();
                        continue;

                    default:
                        Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME + 9);
                        Console.Write(" 예 외 처 리 했 으 니 까 제 대 로 입 력 하 세 요 ~");
                        Thread.Sleep(500);                                                                   //0.5초 출력 후
                        Console.SetCursorPosition(Constants.BUTTON_X_FRAME, Constants.BUTTON_Y_FRAME + 9);
                        Console.Write("                                                           ");        //출력 제거
                        PrintButtonUI();
                        continue;
                }

               GameUI();           //입력이 끝나면  GameUI로 모든 출력 초기화
               WhoWin(playingGame.PlayTicTacToe(), playingGame.ReturnUser1Name(),playingGame.ReturnUser2Name()); //결과가 나오면 whoWin 실행
               Outtro();

            }
            
        }
    }
}
