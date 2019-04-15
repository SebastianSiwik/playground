#include "Sprite.h"
#include "Graphics.h"
#include "Globals.h"


Sprite::Sprite(){}

Sprite::Sprite(Graphics &graphics, const std::string &filePath, int sourceX, int sourceY, int width, int height, float posX, float posY) :
x(posX),
y(posY)
{

	srcRect.x = sourceX;
	srcRect.y = sourceY;
	srcRect.w = width;
	srcRect.h = height;

	spriteSheet = SDL_CreateTextureFromSurface(graphics.getRenderer(), graphics.loadImage(filePath));

	if (spriteSheet == NULL) {
		printf("\nUnable to load image\n");
	}

	boundingBox = Rect(x, y, width*globals::SPRITE_SCALE, height*globals::SPRITE_SCALE);
}


Sprite::~Sprite()
{
}

void Sprite::draw(Graphics &graphics, int x, int y) {
	SDL_Rect destinationRectangle = { x, y, srcRect.w * globals::SPRITE_SCALE, srcRect.h * globals::SPRITE_SCALE };
	graphics.blitSurface(spriteSheet, &srcRect, &destinationRectangle);
}

void Sprite::update(){
	boundingBox = Rect(x, y, srcRect.w*globals::SPRITE_SCALE, srcRect.h*globals::SPRITE_SCALE);
}

const Rect Sprite::getBoundingBox() const {
	return boundingBox;
}

const sides::Side Sprite::getCollisionSide(Rect &other) const {
	int amtRight, amtLeft, amtTop, amtBottom;
	amtRight = getBoundingBox().getRight() - other.getLeft();
	amtLeft = other.getRight() - getBoundingBox().getLeft();
	amtTop = other.getBottom() - getBoundingBox().getTop();
	amtBottom = getBoundingBox().getBottom() - other.getTop();

	int vals[4] = { abs(amtRight), abs(amtLeft), abs(amtTop), abs(amtBottom) };
	int lowest = vals[0];
	for (int i = 0; i < 4; i++) {
		if (vals[i] < lowest) {
			lowest = vals[i];
		}
	}

	return
		lowest == amtRight ? sides::RIGHT :
		lowest == amtLeft ? sides::LEFT :
		lowest == amtTop ? sides::TOP :
		lowest == amtBottom ? sides::BOTTOM :
		sides::NONE;
}

void Sprite::move(int newX, int newY) {
	x = newX;
	y = newY;
}


void Sprite::setSourceRectX(int value) {
	srcRect.x = value;
}

void Sprite::setSourceRectY(int value) {
	srcRect.y = value;
}

void Sprite::setSourceRectW(int value) {
	srcRect.w = value;
}

void Sprite::setSourceRectH(int value) {
	srcRect.h = value;
}