#include "Menu.h"
#include "Tile.h"
#include "Globals.h"
#include "Graphics.h"
#include <SDL_image.h>



Menu::Menu(){}

Menu::Menu(Graphics &graphics): backgroundTex(SDL_CreateTextureFromSurface(graphics.getRenderer(), graphics.loadImage("zawartosc/background/bkFog.png"))),
	background(Tile(backgroundTex, Vector2(globals::SCREEN_WIDTH/2, globals::SCREEN_HEIGHT/2), Vector2(0, 0), Vector2(0, 0))), isUp(true), settingLevel(false) {

	mainMenu = Sprite(graphics, "zawartosc/spritesheets/menu.png", 0, 0, 83, 96, 250, 250);
	level = Sprite(graphics, "zawartosc/spritesheets/menu.png", 0, 96, 51, 58, 10, 285);
	arrow = Sprite(graphics, "zawartosc/spritesheets/menu.png", 73, 146, 16, 13, 500, 266);
}

void Menu::moveArrow(int newX, int newY) {
	arrow.move(newX, newY);
}

void Menu::levelMenu(bool x) {
	settingLevel = x;
}

void Menu::draw(Graphics &graphics) {
	background.draw(graphics);
	mainMenu.draw(graphics, mainMenu.getX(), mainMenu.getY());
	arrow.draw(graphics, arrow.getX(), arrow.getY());
	
	if (settingLevel) {
		level.draw(graphics, level.getX(), level.getY());
	}
}