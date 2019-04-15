#include "Enemy.h"
#include "Player.h"

//Enemy class
Enemy::Enemy(){}

Enemy::Enemy(Graphics &graphics, std::string filePath, int sourceX, int sourceY, int width, int height, Vector2 spawnPoint, int timeToUpdate) :
AnimatedSprite(graphics, filePath, sourceX, sourceY, width, height, spawnPoint.x, spawnPoint.y, timeToUpdate), direction(LEFT), maxHealth(0), currentHealth(0)
{}

void Enemy::update(int elapsedTime, Player &player) {
	AnimatedSprite::update(elapsedTime);
}

void Enemy::draw(Graphics &graphics) {
	AnimatedSprite::draw(graphics, x, y);
}

//Bat class
Bat::Bat(){}

Bat::Bat(Graphics &graphics, Vector2 spawnPoint): Enemy(graphics, "zawartosc/spritesheets/NpcCemet.png", 32, 32, 16, 16, spawnPoint, 140),
	startingX(spawnPoint.x), startingY(spawnPoint.y), shouldMoveUp(false)
{
	setupAnimations();
	playAnimation("FlyLeft");
}

void Bat::update(int elapsedTime, Player &player) {
	direction = player.getX() > x ? RIGHT : LEFT;
	playAnimation(direction == RIGHT ? "FlyRight" : "FlyLeft");
	
	//move up/down
	y += shouldMoveUp ? -.04f : .04f;
	if (y > (startingY + 30) || y < (startingY - 30)) {
		shouldMoveUp = !shouldMoveUp;
	}
	Enemy::update(elapsedTime, player);
}

void Bat::draw(Graphics &graphics) {
	Enemy::draw(graphics);
}

void Bat::animationDone(std::string currentAnimation){}

void Bat::setupAnimations() {
	addAnimation(3, 2, 32, "FlyLeft", 16, 16, Vector2(0, 0));
	addAnimation(3, 2, 48, "FlyRight", 16, 16, Vector2(0, 0));
}

void Bat::touchPlayer(Player* player) {
	player->gainHealth(-1);
	player->bounce();
}