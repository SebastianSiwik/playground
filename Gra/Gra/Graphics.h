#pragma once

struct SDL_Window;
struct SDL_Renderer;

#include <string>
#include <map>
#include <SDL.h>

class Graphics
{
public:
	Graphics();
	~Graphics();

	/*
	loads an surface if it doesn't already exist
	*/
	SDL_Surface* loadImage(const std::string &filePath);

	/*
	draws a surface to the screen

	src - a spritesheet
	srcRect - the part of a spritesheet we want to draw
	destRect - the location we want to draw it to
	*/
	void blitSurface(SDL_Texture* src, SDL_Rect* srcRect, SDL_Rect* destRect);

	/*
	render everything to the screen
	*/
	void flip();

	/*
	clears the screen
	*/
	void clear();

	SDL_Renderer* getRenderer() const;
private:
	SDL_Window* window;
	SDL_Renderer* renderer;

	std::map<std::string, SDL_Surface*> spriteSheets;
};

