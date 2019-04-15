#include "Player.h"
#include "Graphics.h"
#include "Level.h"

namespace player_constants{
	 const float WALK_SPEED = 0.2f;
	 const float JUMP_SPEED = 0.7f;

	 const float GRAVITY = 0.002f;
	 const float GRAVITY_CAP = 0.8f;
}

Player::Player()
{
}

Player::Player(Graphics& graphics, Vector2 spawnPoint) : AnimatedSprite(graphics, "zawartosc/spritesheets/MyChar.png", 0, 0, 16, 16, spawnPoint.x, spawnPoint.y, 100), 
	dx(0), dy(0), facing(RIGHT), grounded(false), lookingDown(false), lookingUp(false), maxHealth(3), currentHealth(3)
{
	graphics.loadImage("zawartosc/spritesheets/MyChar.png");
	setupAnimations();
	playAnimation("RunRight");
}

Player::~Player()
{
}

void Player::setupAnimations() {
	addAnimation(1, 0, 0, "IdleLeft", 16, 16, Vector2(0, 0));
	addAnimation(1, 0, 16, "IdleRight", 16, 16, Vector2(0, 0));
	addAnimation(3, 0, 0, "RunLeft", 16, 16, Vector2(0, 0));
	addAnimation(3, 0, 16, "RunRight", 16, 16, Vector2(0, 0));
	addAnimation(1, 3, 0, "IdleLeftUp", 16, 16, Vector2(0, 0));
	addAnimation(1, 3, 16, "IdleRightUp", 16, 16, Vector2(0, 0));
	addAnimation(3, 3, 0, "RunLeftUp", 16, 16, Vector2(0, 0));
	addAnimation(3, 3, 16, "RunRightUp", 16, 16, Vector2(0, 0));
	addAnimation(1, 6, 0, "LookDownLeft", 16, 16, Vector2(0, 0));
	addAnimation(1, 6, 16, "LookDownRight", 16, 16, Vector2(0, 0));
	addAnimation(1, 7, 0, "LookBackwardsLeft", 16, 16, Vector2(0, 0));
	addAnimation(1, 7, 16, "LookBackwardsRight", 16, 16, Vector2(0, 0));
}

void Player::animationDone(std::string currentAnimation) {
}

const float Player::getX() const {
	return x;
}

const float Player::getY() const {
	return y;
}


void Player::moveLeft() {
	if (lookingDown && grounded) {
		return;
	}
	dx = -player_constants::WALK_SPEED;
	if (lookingUp == false) {
		playAnimation("RunLeft");
	}
	facing = LEFT;
}

void Player::moveRight() {
	if (lookingDown && grounded) {
		return;
	}
	dx = player_constants::WALK_SPEED;
	if (lookingUp == false) {
		playAnimation("RunRight");
	}
	facing = RIGHT;
}

void Player::stopMoving() {
	dx = 0;
	if (lookingUp == false && lookingDown == false) {
		playAnimation(facing == LEFT ? "IdleLeft" : "IdleRight");
	}
}

void Player::lookUp() {
	lookingUp = true;
	if (dx == 0) {
		playAnimation(facing == RIGHT ? "IdleRightUp" : "IdleLeftUp");
	}
	else {
		playAnimation(facing == RIGHT ? "RunRightUp" : "RunLeftUp");
	}
}

void Player::stopLookingUp() {
	lookingUp = false;
}

void Player::lookDown() {
	lookingDown = true;
	if (grounded) {
		stopMoving();
		playAnimation(facing == RIGHT ? "LookBackwardsRight" : "LookBackwardsLeft");
	}
	else {
		playAnimation(facing == RIGHT ? "LookDownRight" : "LookDownLeft");
	}
}

void Player::stopLookingDown() {
	lookingDown = false;
}

void Player::jump() {
	if (grounded) {
		dy = 0;
		dy -= player_constants::JUMP_SPEED;
		grounded = false;
	}
}

//handles collisions with all tiles
void Player::handleTileCollisions(std::vector<Rect> &others) {
	//what collision happened
	for (int i = 0; i < others.size(); i++) {
		sides::Side collisionSide = Sprite::getCollisionSide(others.at(i));
		if (collisionSide != sides::NONE) {
			switch (collisionSide) {
			case sides::TOP:
				dy = 0;
				y = others.at(i).getBottom() + 1;
				if (grounded) {
					dx = 0;
					x -= facing == RIGHT ? 1.0f : -1.0f;
				}
				
				break;
			case sides::BOTTOM:
				y = others.at(i).getTop() - boundingBox.getHeight() - 1;
				dy = 0;
				grounded = true;
				break;
			case sides::LEFT:
				x = others.at(i).getRight() + 1;
				dx = 0;
				break;
			case sides::RIGHT:
				x = others.at(i).getLeft() - boundingBox.getWidth() - 1;
				dx = 0;
				break;
			}
		}
	}
}

//handles collisions with all slopes
void Player::handleSlopeCollisions(std::vector<Slope> &others) {
	for (int i = 0; i < others.size(); i++) {
		//calculate where on the slope the player's bottom center is touching
		// y = mx + b to figure out y position
		//first calculate "b" ( b = y - mx) using one of the points
		int b = others.at(i).getP1().y - others.at(i).getSlope() * fabs(others.at(i).getP1().x);

		//get Player's center x
		int centerX = boundingBox.getCenterX();

		//pass this x to y = mx + b to get y
		int newY = others.at(i).getSlope() * centerX + b - 8;			//-8 to fix a problem

		//reposition the player to the correct y
		if (grounded) {
			y = newY - getBoundingBox().getHeight();
			grounded = true;
		}
	}
}

void Player::handleDoorCollision(std::vector<Door> &others, Level &level, Graphics &graphics) {
	//is player grounded? is DOWN held?
	//if so, go through the door
	for (int i = 0; i < others.size(); i++) {
		if (grounded && lookingDown) {
			level = Level(others.at(i).getDestination(), graphics);
			x = level.getPlayerSpawnPoint().x;
			y = level.getPlayerSpawnPoint().y;
		}
	}
}

void Player::handleEnemyCollisions(std::vector<std::shared_ptr<Enemy>> &others) {
	for (int i = 0; i < others.size(); i++) {
		others.at(i)->touchPlayer(this);
	}
}

void Player::gainHealth(int amount) {
	currentHealth += amount;
}

void Player::bounce() {
	dx = 200;
	dy = -0.5f;
	grounded = false;
}

void Player::update(float elapsedTime) {
	//apply gravity
	if (dy <= player_constants::GRAVITY_CAP) {
		dy += player_constants::GRAVITY * elapsedTime;
	}
	//if (grounded == false) {
		if (dx < 0) {
			dx += player_constants::GRAVITY * elapsedTime;
		}
		else if (dx > 0) {
			dx -= player_constants::GRAVITY * elapsedTime;
		}
	//}

	//move by dx
	x += dx * elapsedTime;
	//move by dy
	y += dy * elapsedTime;

	AnimatedSprite::update(elapsedTime);
}

void Player::draw(Graphics& graphics) {
	AnimatedSprite::draw(graphics, x, y);
}