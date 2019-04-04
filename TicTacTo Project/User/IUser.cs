using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study._02_틱택토__최사원
{
    /* Human 과 Computer class의 상위 인터페이스*/
    /*         두  class의 기본 기능           */

    interface IUser
    {
        char ReturnIcon(); //출력할 아이콘 리턴

        void ResetName(); //이름 초기화

        string ReturnName(); //이름 리턴

        int SelectNumber(int[,] boardArr, int[,]sumArr); //번호 선택

        bool IsComputer(); //컴퓨터인지 아닌지 반환
    }
}
