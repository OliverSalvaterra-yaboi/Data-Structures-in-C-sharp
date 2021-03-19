#include <iostream>

using namespace std;

void swap(int* xpt, int* ypt)	// swap by ptr
{
	int temp = *xpt;
	*xpt = *ypt;
	*ypt = temp;
}


void swap2(int& x, int& y)
{
	int temp = x;
	x = y;
	y = temp;
}

int main()
{
	//int x = 5;

	//int* xptr = &x;

	//std::cout << x << std::endl;
	//std::cout << &x << std::endl;
	//std::cout << xptr << std::endl;
	//std::cout << *xptr << std::endl;

	//std::cout << &xptr << std::endl;



	int x = 5; // 2 5
	int y = 6; // 8 7
	//int* xpt = &x;
	//int* ypt = &y;

	// create a function to swap x with y
	/*x = x*y;
	y = x / y;
	x = x / y;*/

	//swap(&x, &y);
	swap2(x, y);
	std::cout << x << std::endl;
	std::cout << y << std::endl;

	return 0;


	//

	//int x = 4;/*
	//int array[10];*/
	//int* arr = new int[x];
	//arr[0] = 3;
	//int* p = &x;
	//cout << "" << x << "" << endl;
	//cout << p << endl;

	//delete[] arr;

}