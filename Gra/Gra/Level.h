#pragma once
#include "Globals.h"
#include <string>
#include "Tile.h"
#include <vector>
#include "Rect.h"
#include "Slope.h"
#include "AnimatedTile.h"
#include "Door.h"
#include <memory>

struct Tileset;
class Graphics;
class Enemy;
class Player;
struct SDL_Texture;

class Level
{
public:
	Level();
	Level(std::string mapName, Graphics& graphics);
	~Level();

	void update(int elapsedTime, Player &player);
	void draw(Graphics& graphics);

	std::vector<Rect> checkTileCollisions(const Rect &other);
	std::vector<Slope> checkSlopeCollisions(const Rect &other);
	std::vector<Door> checkDoorCollisions(const Rect &other);
	std::vector<std::shared_ptr<Enemy>> checkEnemyCollision(const Rect &other);

	const Vector2 getPlayerSpawnPoint() const;

private:
	std::string mapName;
	Vector2 spawnPoint;

	Vector2 size;
	Vector2 tileSize;

	SDL_Texture* backgroundTexture;

	void loadMap(std::string mapName, Graphics& graphics);

	struct Tileset {
		SDL_Texture* texture;
		int firstGid;

		Tileset() {
			firstGid = -1;
		}

		Tileset(SDL_Texture* texture, int firstGid) : texture(texture), firstGid(firstGid) {}
	};

	Vector2 getTilesetPosition(Tileset tls, int gid, int tileWidth, int tileHeight);

	std::vector<Tile> tileList;
	std::vector<Tileset> tilesets;
	std::vector<Rect> collisionRects;
	std::vector<Slope> slopes;
	std::vector<AnimatedTile> animatedTileList;
	std::vector<AnimatedTileInfo> animatedTileInfos;
	std::vector<Door> doorList;
	std::vector<std::shared_ptr<Enemy>> enemies;
};

