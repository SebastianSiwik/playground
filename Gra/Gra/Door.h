#pragma once
#include "Rect.h"
#include "Globals.h"
#include <string>

class Door :
	public Rect
{
public:
	Door(){}
	Door(Rect r, std::string destination): Rect(r.getLeft() * globals::SPRITE_SCALE, r.getTop() * globals::SPRITE_SCALE,
		r.getWidth()*globals::SPRITE_SCALE, r.getHeight()*globals::SPRITE_SCALE), destination(destination) {}

	const inline Rect getRectangle() const { return getRect(); }
	const inline std::string getDestination() const { return destination; }

private:
	std::string destination;
};
