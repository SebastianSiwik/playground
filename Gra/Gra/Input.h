#pragma once
#include <map>
#include <SDL.h>

class Input
{
public:
	Input();
	~Input();

	void beginNewFrame();
	void keyUpEvent(const SDL_Event& e);
	void keyDownEvent(const SDL_Event& e);
	
	bool wasKeyPressed(SDL_Scancode key);
	bool wasKeyReleased(SDL_Scancode key);
	bool isKeyHeld(SDL_Scancode key);
private:
	std::map<SDL_Scancode, bool> heldKeys;
	std::map<SDL_Scancode, bool> pressedKeys;
	std::map<SDL_Scancode, bool> releasedKeys;
};

