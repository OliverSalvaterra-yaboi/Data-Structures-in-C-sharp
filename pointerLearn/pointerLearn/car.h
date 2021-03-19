#pragma once
#include <iostream> 

class car
{
private:
	int horsepower;
	int engine;
	int seats;
	int speed;
public:
	int getHorse();
	int getEngine();
	int getSeats();
	int accelerate(int accel);
	car(int horsepower, int engine, int seats);
};

