#include "HUD.h"
#include "Graphics.h"



HUD::HUD(){}


HUD::HUD(Graphics &graphics, Player &player) : player(player){
	healthBarSprite = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 0, 40, 64, 8, 35, 70);
	healthNumber1 = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 0, 56, 8, 8, 66, 70);
	currentHealthBar = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 0, 25, 39, 5, 83, 72);
	lvWord = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 81, 81, 11, 7, 38, 55);
	lvNumber = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 0, 56, 8, 8, 66, 52);
	expBar = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 0, 72, 40, 8, 83, 52);
	slash = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 72, 48, 8, 8, 100, 36);
	dashes = Sprite(graphics, "zawartosc/spritesheets/TextBox.png", 81, 51, 15, 11, 132, 26);
}

void HUD::update(int elapsedTime, Player &player) {
	this->player = player;
	healthNumber1.setSourceRectX(8 * this->player.getCurrentHealth());

	//100% = 39px
	float num = (float)this->player.getCurrentHealth() / this->player.getMaxHealth();
	currentHealthBar.setSourceRectW(std::floor(num * 39));
}

void HUD::draw(Graphics &graphics) {
	healthBarSprite.draw(graphics, healthBarSprite.getX(), healthBarSprite.getY());
	healthNumber1.draw(graphics, healthNumber1.getX(), healthNumber1.getY());
	currentHealthBar.draw(graphics, currentHealthBar.getX(), currentHealthBar.getY());
	lvWord.draw(graphics, lvWord.getX(), lvWord.getY());
	lvNumber.draw(graphics, lvNumber.getX(), lvNumber.getY());
	expBar.draw(graphics, expBar.getX(), expBar.getY());
	slash.draw(graphics, slash.getX(), slash.getY());
	dashes.draw(graphics, dashes.getX(), dashes.getY());
}