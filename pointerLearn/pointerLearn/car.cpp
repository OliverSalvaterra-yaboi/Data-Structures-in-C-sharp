#include "car.h"

car::car(int horsepower, int engine, int seats) : horsepower(horsepower), engine(engine), seats(seats) {}

int car::getHorse()
{
	return horsepower;
}
int car::getEngine()
{
	return engine;
}
int car::getSeats()
{
	return seats;
}

int car::accelerate(int accel)
{
	speed += accel;
	return speed;
}