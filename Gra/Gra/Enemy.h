#pragma once
#include "AnimatedSprite.h"

class Player;

class Enemy :
	public AnimatedSprite
{
public:
	Enemy();
	Enemy(Graphics &graphics, std::string filePath, int sourceX, int sourceY, int width, int height, Vector2 spawnPoint, int timeToUpdate);

	virtual void update(int elapsedTime, Player &player);
	virtual void draw(Graphics &graphics);
	virtual void touchPlayer(Player* player) = 0;

	const inline int getMaxHealth() const { return maxHealth; }
	const inline int getCurrentHealth() const { return currentHealth; }
protected:
	Direction direction;
	int maxHealth;
	int currentHealth;
};

class Bat :
	public Enemy
{
public:
	Bat();
	Bat(Graphics &graphics, Vector2 spawnPoint);
	void update(int elapsedTime, Player &player);
	void draw(Graphics &graphics);
	void touchPlayer(Player* player);

	void animationDone(std::string currentAnimation);
	void setupAnimations();

private:
	float startingX, startingY;
	bool shouldMoveUp;
};