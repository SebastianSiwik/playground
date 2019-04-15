#pragma once

#include "Player.h"
#include "Level.h"
#include "HUD.h"
#include "Graphics.h"
#include "Menu.h"

class Game
{
public:
	Game();
	~Game();
private:
	void gameLoop();
	void draw(Graphics &graphics);
	void update(float elapsedTime);

	Player player;
	Level level;
	HUD hud;
	Graphics graphics;
	Menu menu;
	bool ready;
};

