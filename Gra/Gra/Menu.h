#pragma once
#include "Tile.h"
#include "Sprite.h"

struct SDL_Texture;
class Graphics;

class Menu
{
public:
	Menu();
	Menu(Graphics &graphics);

	void draw(Graphics &graphics);

	const inline bool isVisible() const { return isUp; }
	const inline Sprite getArrow() const { return arrow; }
	const inline bool isSettingLevel() const { return settingLevel; }

	void moveArrow(int newX, int newY);
	void levelMenu(bool x);

private:
	SDL_Texture* backgroundTex;
	Tile background;
	Sprite mainMenu;
	Sprite level;
	Sprite arrow;

	bool isUp;
	bool settingLevel;
};

