#include "Rect.h"

Rect::Rect() {};
Rect::Rect(int x, int y, int width, int height) : x(x), y(y), width(width), height(height) {}

const int Rect::getCenterX() const { return x + width / 2; }
const int Rect::getCenterY() const { return y + height / 2; }
const int Rect::getLeft() const { return x; }
const int Rect::getRight() const { return x + width; }
const int Rect::getTop() const { return y; }
const int Rect::getBottom() const { return y + height; }
const int Rect::getWidth() const { return width; }
const int Rect::getHeight() const { return height; }
const int Rect::getSide(const sides::Side side) const {
	return
		side == sides::LEFT ? getLeft() :
		side == sides::RIGHT ? getRight() :
		side == sides::TOP ? getTop() :
		side == sides::BOTTOM ? getBottom() :
		sides::NONE;
}

//checks if another rectangle is colliding
const bool Rect::collidesWith(const Rect &other) const {
	return
		getRight() >= other.getLeft() &&
		getLeft() <= other.getRight() &&
		getTop() <= other.getBottom() &&
		getBottom() >= other.getTop();
}

const bool Rect::isValidRectangle() const {
	return x >= 0 && y >= 0 && width >= 0 && height >= 0;
}