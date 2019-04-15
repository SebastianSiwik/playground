#pragma once
#include "Globals.h"
#include <cmath>
#include "Rect.h"

class Slope {

public:
	Slope() {}
	Slope(Vector2 p1, Vector2 p2) : p1(p1), p2(p2) {
		if (p2.x - p1.x != 0) {
			slope = (fabs(p2.y) - fabs(p1.y)) / (fabs(p2.x) - fabs(p1.x));
		}
	}

	const inline float getSlope() const {
		return slope;
	}

	const bool collidesWith(const Rect &other) const {
		return
											// for slope like this "/"
			(other.getRight() >= p2.x &&
			other.getLeft() <= p1.x &&
			other.getTop() <= p2.y &&
			other.getBottom() >= p1.y) ||
			(other.getRight() >= p1.x &&
			other.getLeft() <= p2.x &&
			other.getTop() <= p1.y &&
			other.getBottom() >= p2.y)
			
			||
											//for slope like this "\"
			(other.getLeft() <= p1.x &&
			other.getRight() >= p2.x &&
			other.getTop() <= p1.y &&
			other.getBottom() >= p2.y) ||
			(other.getLeft() <= p2.x &&
			other.getRight() >= p1.x &&
			other.getTop() <= p2.y &&
			other.getBottom() >= p1.y);

	}

	const inline Vector2 getP1() const { return p1; }
	const inline Vector2 getP2() const { return p2; }

private:
	Vector2 p1, p2;
	float slope;

};