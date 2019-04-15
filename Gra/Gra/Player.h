#pragma once
#include "AnimatedSprite.h"
#include "Slope.h"
#include "Door.h"
#include "Enemy.h"
#include <memory>

class Graphics;
class Level;

class Player :
	public AnimatedSprite
{
public:
	Player();
	Player(Graphics& graphics, Vector2 spawnPoint);
	void draw(Graphics& graphics);
	void update(float elapsedTime);
	
	void moveLeft();
	void moveRight();
	void stopMoving();
	void lookUp();
	void stopLookingUp();
	void lookDown();
	void stopLookingDown();
	void jump();

	virtual void animationDone(std::string currentAnimation);
	virtual void setupAnimations();
	~Player();

	void handleTileCollisions(std::vector<Rect> &others);
	void handleSlopeCollisions(std::vector<Slope> &others);
	void handleDoorCollision(std::vector<Door> &others, Level &level, Graphics &graphics);
	void handleEnemyCollisions(std::vector<std::shared_ptr<Enemy>> &others);

	const float getX() const;
	const float getY() const;

	const inline int getMaxHealth() const { return maxHealth; }
	const inline int getCurrentHealth() const { return currentHealth; }

	void gainHealth(int amount);

	void bounce();

private:
	float dx, dy;
	Direction facing;
	bool grounded;
	bool lookingUp, lookingDown;
	int maxHealth, currentHealth;
};

