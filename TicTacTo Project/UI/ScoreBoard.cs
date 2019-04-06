using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Study._02_틱택토__최사원
{
    //score board
    public struct score  //유저 스코어를 저장할 STRUCT 생성
    {
        public string name;
        public int point;
    };

    class ScoreBoard
    {
        private List<score> userScore; // 유저 점수를 저장할 STRUCT
        private ArrayList computerScore; //컴퓨터 점수를 저장할 ArrayList

        public ScoreBoard()  //생성자
        {

            userScore = new List<score>();
            computerScore = new ArrayList();

        }

        public void PrintScoreBoard()  // ScoreBoard 출력
        {

            Console.SetCursorPosition(Constants.USERSCORE_X_FRAME - 22, Constants.USERSCORE_Y_FRAME + 4);
            Console.Write("<  User  >");

            for (int index = 0; index < 5; index++)
            {
                Console.SetCursorPosition(Constants.USERSCORE_X_FRAME - 2, Constants.USERSCORE_Y_FRAME + index * 2);
                Console.Write((index + 1) + "등. ");

                if (index < userScore.Count)
                    Console.Write(userScore[index].name + "  :  " + userScore[index].point + " 점");

            }


            Console.SetCursorPosition(Constants.COMPUBERSCORE_X_FRAME, Constants.COMPUTERSCORE_Y_FRAME - 2);
            Console.Write("<     Computer 최근 5 게임 전적    >");

            Console.SetCursorPosition(Constants.COMPUBERSCORE_X_FRAME, Constants.COMPUTERSCORE_Y_FRAME);

            if (computerScore.Count == 0)
            {
                Console.Write("Computer의 전적이 없습니다.");
            }

            else
            {
                for (int play = 0; play < computerScore.Count; play++)
                {
                    if (play > 4) break;
                    Console.Write((play + 1) + "번 째 : " + computerScore[play] + " / ");
                }
            }
        }


        /*---private 함수---*/
        private void SwapString(ref string name1, ref string name2)
        {
            string buffer = name1;
            name1 = name2;
            name2 = buffer;
        }

        public void InsertSocre(string user1, string user2, int whoWin) // 점수 저장
        {
            if (user1 == "Computer") //USER1이 컴퓨터라면
            {
                SwapString(ref user1, ref user2); // 두 개의 이름 바꾸고  /**/
                whoWin *= -1;           //승리 반대로

            }

            score score1;
            score1.name = user1;
            score1.point = Constants.USER1 * whoWin; //자신의 코드에 게임 결과 코드를 곱하면 자신의 점수가 된다. 
            InsertUserArray(score1);  //user1 저장

            if (user2 == "Computer")   // user2가 컴퓨터이면
            {
                InsertComputerArray(whoWin);  // computerArray에 저장
                return;

            }

                score score2;
                score2.name = user2;
                score2.point = Constants.USER2 * whoWin;
                InsertUserArray(score2);
   
        }

        private void InsertUserArray(score score1) // userarray에 struct score 값 저장
        {
           
            for (int i = 0; i < userScore.Count; i++)
            {
                if (userScore[i].name == score1.name)
                {

                    score1.point += userScore[i].point; // 같은 이름이 존재하면 포인트만 업데이트 후
                    userScore[i] = score1;
                    return;  //탈출

                }
            }
        
           userScore.Add(score1); //없으면 추가
            SortScoreBoard();

        }

        private void InsertComputerArray(int whoWin) // 컴퓨터 ArrayList에 정보 저장
        {

            if (whoWin == Constants.USER2)
                computerScore.Add("Win");

            else if(whoWin == Constants.USER1)
                computerScore.Add("LOSE");

            else
                computerScore.Add("DRAW");

            if(computerScore.Count>5) // 5번 째 부터 값이 들어오면 첫번 째 값 지우기.
                computerScore.RemoveAt(0); 
            
        }

        private void SortScoreBoard()  // 사용자 배열 높은 포인트 순으로 정렬하기.
        {
            for(int index=0; index<userScore.Count; index++)
            userScore.Sort(CompareScore);
        }

        private int CompareScore(score x1, score x2) //정렬 기준
        {
            if (x1.point < x2.point) return 1;

            else if (x1.point > x2.point) return -1;

            else return 0;
        }

    }
}
