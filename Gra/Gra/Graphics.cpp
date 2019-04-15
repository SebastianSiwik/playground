#include "Graphics.h"
#include "Globals.h"
#include <SDL.h>
#include <SDL_image.h>

Graphics::Graphics()
{
	SDL_CreateWindowAndRenderer(globals::SCREEN_WIDTH, globals::SCREEN_HEIGHT, 0, &window, &renderer);
	SDL_SetWindowTitle(window, "GRA");
}


Graphics::~Graphics()
{
	SDL_DestroyWindow(window);
	SDL_DestroyRenderer(renderer);
}

SDL_Surface* Graphics::loadImage(const std::string &filePath) {
	if (spriteSheets.count(filePath) == 0) {
		spriteSheets[filePath] = IMG_Load(filePath.c_str());
	}
	return spriteSheets[filePath];
}

void Graphics::blitSurface(SDL_Texture* src, SDL_Rect* srcRect, SDL_Rect* destRect) {
	SDL_RenderCopy(renderer, src, srcRect, destRect);
}

void Graphics::flip() {
	SDL_RenderPresent(renderer);
}

void Graphics::clear() {
	SDL_RenderClear(renderer);
}

SDL_Renderer* Graphics::getRenderer() const {
	return renderer;
}