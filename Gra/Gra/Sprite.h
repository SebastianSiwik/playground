#pragma once
#include <string>
#include <SDL.h>
#include "Rect.h"
#include "Globals.h"

class Graphics;

class Sprite
{
public:
	Sprite();
	Sprite(Graphics &graphics, const std::string &filePath, int sourceX, int sourceY, int width, int height, float posX, float posY);
	virtual ~Sprite();
	virtual void update();
	void draw(Graphics &graphics, int x, int y);
	const Rect getBoundingBox() const;
	const sides::Side getCollisionSide(Rect &other) const;
	const inline float getX() const { return x; }
	const inline float getY() const { return y; }
	
	void setSourceRectX(int value);
	void setSourceRectY(int value);
	void setSourceRectW(int value);
	void setSourceRectH(int value);

	void move(int newX, int newY);
	
protected:
	SDL_Rect srcRect;
	SDL_Texture* spriteSheet;
	float x, y;
	Rect boundingBox;
};

