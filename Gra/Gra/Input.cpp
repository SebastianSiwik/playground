#include "Input.h"



Input::Input()
{
}


Input::~Input()
{
}
/*
called at each new frame
*/
void Input::beginNewFrame() {
	pressedKeys.clear();
	releasedKeys.clear();
}

void Input::keyDownEvent(const SDL_Event& e) {
	pressedKeys[e.key.keysym.scancode] = true;
	heldKeys[e.key.keysym.scancode] = true;
}

void Input::keyUpEvent(const SDL_Event& e) {
	releasedKeys[e.key.keysym.scancode] = true;
	heldKeys[e.key.keysym.scancode] = false;
}

bool Input::wasKeyPressed(SDL_Scancode key) {
	return pressedKeys[key];
}

bool Input::wasKeyReleased(SDL_Scancode key) {
	return releasedKeys[key];
}

bool Input::isKeyHeld(SDL_Scancode key) {
	return heldKeys[key];
}