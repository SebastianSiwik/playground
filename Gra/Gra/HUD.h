#pragma once

#include "Sprite.h"
#include "Player.h"

class Graphics;

class HUD
{
public:
	HUD();
	HUD(Graphics &graphics, Player &player);
	void update(int elapsedTime, Player &player);
	void draw(Graphics &graphics);

private:
	Player player;

	//health sprites
	Sprite healthBarSprite;
	Sprite healthNumber1;
	Sprite currentHealthBar;

	//level sprites
	Sprite lvWord;
	Sprite lvNumber;
	Sprite expBar;

	//weapon info
	Sprite slash;
	Sprite dashes;
};

