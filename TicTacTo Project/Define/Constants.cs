using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study._02_틱택토__최사원
{
    static class Constants
    {

        /// <summary>
        /// FOR UI            //UI 간격을 한번에 조정하기 위해 정의해두고 사용
        /// </summary>
        /// 

        //title 
        public const int TITLE_X_FRAME = 30;
        public const int TITLE_Y_FRAME = 8;

        //button
        public const int BUTTON_X_FRAME = 22;
        public const int BUTTON_Y_FRAME = 16;

        //board
        public const int BOARD_X_FRAME = 18;
        public const int BOARD_Y_FRAME = 1;

        public const int BOARD_X_RANGE = 10;
        public const int BOARD_Y_RANGE = 5;

        //Guide 1st line
        public const int GUIDE_X_FRAME = 5;
        public const int GUIDE_Y_FRAME = 25;

        //Gudie 2nd line
        public const int GUIDE_X_FRAME2= 5;
        public const int GUIDE_Y_FRAME2 = 27;

        //Input
        public const int INPUT_X_FRAME = 30;
        public const int INPUT_Y_FRAME = 3;

        //win
        public const int WIN_X_FRAME = 0;
        public const int WIN_Y_FRAME = 8;

        //scoreboard for user
        public const int USERSCORE_X_FRAME = 40;
        public const int USERSCORE_Y_FRAME = 3;

        //scoreboard for user
        public const int COMPUBERSCORE_X_FRAME = 9;
        public const int COMPUTERSCORE_Y_FRAME = 19;



        /// <summary>
        /// User Code
        /// </summary>
        /// 

        public const int USER1 = 1;
        public const int USER2 = -1;
        public const int DRAW = 0; //무승부
    }
  
}
