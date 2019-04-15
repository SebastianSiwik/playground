#pragma once
#include "Sprite.h"
#include "Globals.h"
#include <map>
#include <vector>

class Graphics;

class AnimatedSprite :
	public Sprite
{
public:
	AnimatedSprite();
	AnimatedSprite(Graphics &graphics, const std::string &filePath, int sourceX, int sourceY, int width, int height, float posX, float posY, float timeToUpdate);

	void playAnimation(std::string animation, bool once = false);
	void update(int elapsedTime);
	void draw(Graphics &graphics, int x, int y);
	virtual void setupAnimations() = 0;

protected:
	double timeToUpdate;
	bool currentAnimationOnce;
	std::string currentAnimation;

	void addAnimation(int frames, int x, int y, std::string name, int width, int height, Vector2 offset);
	void resetAnimations();
	void stopAnimation();
	void setVisible(bool visible);
	
	/*
	what happens when an animation ends
	*/
	virtual void animationDone(std::string currentAnimation) = 0;

private:
	std::map<std::string, std::vector<SDL_Rect>> animations;
	std::map<std::string, Vector2> offsets;

	int frameIndex;
	double timeElapsed;
	bool visible;
};

