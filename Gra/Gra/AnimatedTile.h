#pragma once
#include "Tile.h"
#include <vector>
class AnimatedTile :
	public Tile
{
public:
	AnimatedTile();
	AnimatedTile(std::vector<Vector2> tilesetPositions, int duration, SDL_Texture* tileset, Vector2 size, Vector2 position);
	~AnimatedTile();

	void update(int elapsedTime);
	void draw(Graphics &graphics);
protected:
	int amountOfTime = 0;
	bool notDone = false;
private:
	std::vector<Vector2> tilesetPositions;
	int tileToDraw;
	int duration;
};

struct AnimatedTileInfo {
public:
	int TilesetsFirstGid;
	int StartTileId;
	std::vector<int> TileIds;
	int Duration;
};

