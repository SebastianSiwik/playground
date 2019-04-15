#include "Game.h"
#include "Input.h"
#include <SDL.h>
#include<algorithm>
#include <fstream>

namespace {
	const int FPS = 50;
	const int MAX_FRAME_TIME = 1000 / FPS;
}

Game::Game() : ready(false)
{
	SDL_Init(SDL_INIT_EVERYTHING);
	this->gameLoop();
}


Game::~Game()
{
	const float EXIT_TIME_MS = SDL_GetTicks();
	std::fstream file;
	file.open("zawartosc/czas.txt", std::ios::app);
	if (file.good()) {
		file << EXIT_TIME_MS / 1000 << std::endl;
	}
	file.close();
}
/*
Game loop
*/
void Game::gameLoop() {
	Graphics g;
	SDL_Event e;
	Input input;

	menu = Menu(g);
	level = Level("map1", g);
	player = Player(g, level.getPlayerSpawnPoint());
	hud = HUD(g, player);

	int LAST_UPDATE_TIME = SDL_GetTicks();

	//game loop starts HERE
	while (true) {
		input.beginNewFrame();

		if (SDL_PollEvent(&e)) {
			if (e.type == SDL_KEYDOWN) {
				if (e.key.repeat == 0) {
					input.keyDownEvent(e);
				}
			}
			else if (e.type == SDL_KEYUP) {
				input.keyUpEvent(e);
			}
			else if (e.type == SDL_QUIT) {
				return;
			}
		}
		if (input.wasKeyPressed(SDL_SCANCODE_W) || input.wasKeyPressed(SDL_SCANCODE_UP)) {
			if (menu.isVisible() && !menu.isSettingLevel()) {
				if(menu.getArrow().getY() == 266)
				menu.moveArrow(500, 394);
				else {
					menu.moveArrow(500, menu.getArrow().getY() - 64);
				}
			}
			else if (menu.isVisible() && menu.isSettingLevel()) {
				if (menu.getArrow().getY() == 300) {
					menu.moveArrow(120, 364);
				}
				else {
					menu.moveArrow(120, 300);
				}
			}
		}
		else if (input.wasKeyPressed(SDL_SCANCODE_S) || input.wasKeyPressed(SDL_SCANCODE_DOWN)) {
			if (menu.isVisible() && !menu.isSettingLevel()) {
				if (menu.getArrow().getY() == 394)
					menu.moveArrow(500, 266);
				else {
					menu.moveArrow(500, menu.getArrow().getY() + 64);
				}
			}
			else if (menu.isVisible() && menu.isSettingLevel()) {
				if (menu.getArrow().getY() == 364) {
					menu.moveArrow(120, 300);
				}
				else {
					menu.moveArrow(120, 364);
				}
			}
		}
		if (input.wasKeyPressed(SDL_SCANCODE_SPACE)) {
			if (menu.isVisible()) {
				int c = menu.getArrow().getY();
				switch(c) {
				case 394:
					return;
					break;
				case 266:
					ready = true;
					break;
				case 330:
					menu.levelMenu(true);
					menu.moveArrow(120, 300);
					break;
				case 300:
					ready = true;
					menu.levelMenu(false);
					break;
				case 364:
					level = Level("map2", g);
					ready = true;
					menu.levelMenu(false);
					break;
				}
			}
		}


		if (input.wasKeyPressed(SDL_SCANCODE_ESCAPE)) {
			if (menu.isSettingLevel()) {
				menu.moveArrow(500, 330);
				menu.levelMenu(false);
			}
			else {
				return;
			}
		}
		else if (input.isKeyHeld(SDL_SCANCODE_LEFT) || input.isKeyHeld(SDL_SCANCODE_A)) {
			player.moveLeft();
		}
		else if (input.isKeyHeld(SDL_SCANCODE_RIGHT) || input.isKeyHeld(SDL_SCANCODE_D)) {
			player.moveRight();
		}

		if (input.isKeyHeld(SDL_SCANCODE_UP) || input.isKeyHeld(SDL_SCANCODE_W)) {
			player.lookUp();
		}
		else if (input.isKeyHeld(SDL_SCANCODE_DOWN) || input.isKeyHeld(SDL_SCANCODE_S)) {
			player.lookDown();
		}

		if (input.wasKeyReleased(SDL_SCANCODE_UP) || input.wasKeyReleased(SDL_SCANCODE_W)) {
			player.stopLookingUp();
		}
		if (input.wasKeyReleased(SDL_SCANCODE_DOWN) || input.wasKeyReleased(SDL_SCANCODE_S)) {
			player.stopLookingDown();
		}
		
		if (input.isKeyHeld(SDL_SCANCODE_SPACE)) {
			player.jump();
		}

		if (!input.isKeyHeld(SDL_SCANCODE_LEFT) && !input.isKeyHeld(SDL_SCANCODE_RIGHT) && !input.isKeyHeld(SDL_SCANCODE_A) && !input.isKeyHeld(SDL_SCANCODE_D)) {
			player.stopMoving();
		}

		const int CURRENT_TIME_MS = SDL_GetTicks();
		int ELAPSED_TIME_MS = CURRENT_TIME_MS - LAST_UPDATE_TIME;
		graphics = g;
		update(std::min(ELAPSED_TIME_MS, MAX_FRAME_TIME));
		LAST_UPDATE_TIME = CURRENT_TIME_MS;

		draw(g);
	}
}
/*
draw everything to the screen
*/
void Game::draw(Graphics &graphics) {
	graphics.clear();
	if (!ready) {
		menu.draw(graphics);
	}
	else {
		level.draw(graphics);
		player.draw(graphics);

		hud.draw(graphics);
	}
	graphics.flip();
}
/*
updates what's going on in the screen
*/
void Game::update(float elapsedTime) {
	player.update(elapsedTime);
	level.update(elapsedTime, player);
	hud.update(elapsedTime, player);
	//check slopes
	std::vector<Slope> otherSlopes = level.checkSlopeCollisions(player.getBoundingBox());
	if (otherSlopes.size() > 0) {
		player.handleSlopeCollisions(otherSlopes);
	}
	//check collisions
	std::vector<Rect> others = level.checkTileCollisions(player.getBoundingBox());
	if (others.size() > 0) {
		//player collides with at least 1 tile
		player.handleTileCollisions(others);
	}
	
	//check doors
	std::vector<Door> otherDoors = level.checkDoorCollisions(player.getBoundingBox());
	if (otherDoors.size() > 0) {
		player.handleDoorCollision(otherDoors, level, graphics);
	}
	//check enemies
	std::vector<std::shared_ptr<Enemy>> otherEnemies = level.checkEnemyCollision(player.getBoundingBox());
	if (otherEnemies.size() > 0) {
		player.handleEnemyCollisions(otherEnemies);
	}
}