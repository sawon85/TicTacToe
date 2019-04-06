using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study._02_틱택토__최사원
{
    class Human : IUser
    {
        
        string name;
        char icon;
        int user;

        public Human(char icon, int user)
        {
            this.icon = icon;
            this.user = user;
        }

        /*---interface 구현---**/

        char IUser.ReturnIcon()
        {
            return icon;
        }

        void IUser.ResetName()
        {
            this.name = Console.ReadLine().Trim();
           
        }

        string IUser.ReturnName()
        {
            return this.name;
        }

        bool IUser.IsComputer()
        {
            return false;
        }

        int IUser.SelectNumber(int[,] boardArr, int[,]sumArr)
        {
            string number;
            int button;

            while (true)
            {
                number = Console.ReadLine();   //값 입력
                switch(number)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":

                        button = int.Parse(number)-1;  //boardarr자리를 찾기위해 1 감소

                        if (boardArr[button / 3, button % 3] == 0)  // 자리가 비어있으면
                        {
                            InputClear();  //입력했던 자리 지우기
                            return button;
                        }
                        else //자리가 비어있지 않으면
                        {
                            // 가이드라인을 Guide 자리에 출력
                            Console.SetCursorPosition(Constants.GUIDE_X_FRAME2, Constants.GUIDE_Y_FRAME2);
                            Console.WriteLine("이미 선택된 곳 입니다. 다시 입력해 주세요.       ");
                            InputClear();
                            continue; //다시 입력 받으러

                        }

                    default: //그 외의 입력이 들어오면 메세지 출력
                        Console.SetCursorPosition(Constants.GUIDE_X_FRAME2, Constants.GUIDE_Y_FRAME2);
                        Console.WriteLine("입력값을 제대로 입력해 주세요. (1 ~ 9 중에 선택)");
                        InputClear();
                        break;
                }
            }
        }

        void IUser.TurnChange()
        {
            user *= -1;
        }

        int IUser.ReturnUserCode()
        {
            return user;
        }

            /*---human private 함수---*/
            private void InputClear()
        {
            Console.SetCursorPosition(Constants.INPUT_X_FRAME, Constants.INPUT_Y_FRAME);
            Console.Write("                           ");
            Console.SetCursorPosition(Constants.INPUT_X_FRAME, Constants.INPUT_Y_FRAME);

        }
    }
}
