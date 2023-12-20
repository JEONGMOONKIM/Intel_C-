#include <stdio.h>
//함수의 포인터를 사용한 대리호출 방법

void f1() {printf("Function F1\n");}
void f2() { printf("Function F2\n");}
void f3() { printf("Function F3\n");}

int main()
{
    void* func[3] = { f1, f2, f3 };
    //func[0] = f1;
    ((void(*)(void))(func[0]))(); //(*)(함수원형)(arg)--> void(*)(함수원형)(arg)--> ((void(*)(void))(함수원형))(arg)
}

