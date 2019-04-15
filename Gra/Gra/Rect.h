#pragma once

#include "globals.h";

class Rect
{
public:
	Rect();
	Rect(int x, int y, int width, int height);

	const int getCenterX() const;
	const int getCenterY() const;
	const int getLeft() const;
	const int getRight() const;
	const int getTop() const;
	const int getBottom() const;
	const int getWidth() const;
	const int getHeight() const;
	const int getSide(const sides::Side side) const;

	//checks if another rectangle is colliding
	const bool collidesWith(const Rect &other) const;

	const bool isValidRectangle() const;

	const inline Rect getRect() const { return *this; }

private:
	int x, y, width, height;
};

