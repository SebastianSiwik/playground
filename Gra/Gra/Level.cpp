#include "Level.h"
#include "Graphics.h"
#include "tinyxml2.h"
#include "Utils.h"
#include "Enemy.h"

#include <sstream>
#include <algorithm>
#include <cmath>

using namespace tinyxml2;

Level::Level(){}

Level::Level(std::string mapName, Graphics& graphics) : mapName(mapName), size(Vector2(0,0))
{
	loadMap(mapName, graphics);
}

Level::~Level(){}

void Level::loadMap(std::string mapName, Graphics& graphics) {
	//parse the .tmx file
	XMLDocument doc;
	std::stringstream ss;
	ss << "zawartosc/maps/" << mapName << ".tmx";
	doc.LoadFile(ss.str().c_str());

	XMLElement* mapNode = doc.FirstChildElement("map");
	
	int width, height;
	mapNode->QueryIntAttribute("width", &width);
	mapNode->QueryIntAttribute("height", &height);
	size = Vector2(width, height);

	int tileWidth, tileHeight;
	mapNode->QueryIntAttribute("tilewidth", &tileWidth);
	mapNode->QueryIntAttribute("tileheight", &tileHeight);
	tileSize = Vector2(tileWidth, tileHeight);
	//loading the tilesets
	XMLElement* pTileset = mapNode->FirstChildElement("tileset");
	if (pTileset != NULL) {
		while (pTileset) {
			int firstgid;
			std::string source;
			pTileset->QueryIntAttribute("firstgid", &firstgid);
			try {
				if (!pTileset->Attribute("source")) {
					throw "No source attribute in tileset element";
				}
				source = pTileset->Attribute("source");
				source.replace(0, 2, "zawartosc");
				source.pop_back();
				source.pop_back();
				source.pop_back();
				source.append("png");
			}
			catch (const char* exception) {
				source = pTileset->FirstChildElement("image")->Attribute("source");
				source.replace(0, 2, "zawartosc");
			}

			SDL_Texture* tex = SDL_CreateTextureFromSurface(graphics.getRenderer(), graphics.loadImage(source));
			tilesets.push_back(Tileset(tex, firstgid));

			//Animation stuff
			XMLElement* pTileA = pTileset->FirstChildElement("tile");
			if (pTileA != NULL) {
				while (pTileA) {
					AnimatedTileInfo ati;
					ati.StartTileId = pTileA->IntAttribute("id") + firstgid;
					ati.TilesetsFirstGid = firstgid;
					XMLElement* pAnimation = pTileA->FirstChildElement("animation");
					if (pAnimation != NULL) {
						while (pAnimation) {
							XMLElement* pFrame = pAnimation->FirstChildElement("frame");
							if (pFrame != NULL) {
								while (pFrame) {
									ati.TileIds.push_back(pFrame->IntAttribute("tileid") + firstgid);
									ati.Duration = pFrame->IntAttribute("duration");


									pFrame = pFrame->NextSiblingElement("frame");
								}
							}

							pAnimation = pAnimation->NextSiblingElement("animation");
						}
					}
					animatedTileInfos.push_back(ati);
					pTileA = pTileA->NextSiblingElement("tile");
				}
			}


			pTileset = pTileset->NextSiblingElement("tileset");
		}
	}
	//loading the layers
	XMLElement* pLayer = mapNode->FirstChildElement("layer");
	if (pLayer != NULL) {
		while (pLayer) {
			//loading the data element
			XMLElement* pData = pLayer->FirstChildElement("data");
			if (pData != NULL) {
				while (pData) {
					//loading the tile element
					XMLElement* pTile = pData->FirstChildElement("tile");
					if (pTile != NULL) {
						int tileCounter = 0;
						while (pTile) {

							if (pTile->IntAttribute("gid") == 0) {
								tileCounter++;
								if (pTile->NextSiblingElement("tile")) {
									pTile = pTile->NextSiblingElement("tile");
									continue;
								}
								else break;
							}
							int gid = pTile->IntAttribute("gid");
							Tileset tls;
							int closest = 0;
							for (int i = 0; i < tilesets.size(); i++) {
								if (tilesets[i].firstGid <= gid) {
									if (tilesets.at(i).firstGid > closest) {
										closest = tilesets.at(i).firstGid;
										tls = tilesets.at(i);
									}
								}
							}
							if (tls.firstGid == -1) {
								//no tileset was found for this gid
								tileCounter++;
								if (pTile->NextSiblingElement("tile")) {
									pTile = pTile->NextSiblingElement("tile");
									continue;
								}
								else break;
							}

							//get the position of the tile in the level
							int tilex = 0, tiley = 0;

							tilex = (tileCounter % width) * tileWidth;
							tiley += tileHeight * (tileCounter / width);
							Vector2 finalTilePosition = Vector2(tilex, tiley);

							Vector2 finalTilesetPosition = getTilesetPosition(tls, gid, tileWidth, tileHeight);

							//build the tile and add it to the tile list
							bool isAnimatedTile = false;
							AnimatedTileInfo ati;
							for (int i = 0; i < animatedTileInfos.size(); i++) {
								if (animatedTileInfos.at(i).StartTileId == gid) {
									ati = animatedTileInfos.at(i);
									isAnimatedTile = true;
									break;
								}
							}
							if (isAnimatedTile) {
								std::vector<Vector2> tilesetPositions;
								for (int i = 0; i < ati.TileIds.size(); i++) {
									tilesetPositions.push_back(getTilesetPosition(tls, ati.TileIds.at(i), tileWidth, tileHeight));
								}
										AnimatedTile tile(tilesetPositions, ati.Duration, tls.texture, Vector2(tileWidth, tileHeight), finalTilePosition);
										animatedTileList.push_back(tile);
							}
							else {
								Tile tile(tls.texture, Vector2(tileWidth, tileHeight), finalTilesetPosition, finalTilePosition);
								tileList.push_back(tile);
							}
							tileCounter++;

							pTile = pTile->NextSiblingElement("tile");
						} 
					}
	
					pData = pData->NextSiblingElement("data");
				}
			}

			pLayer = pLayer->NextSiblingElement("layer");
		}
	}

	//parsing collisions
	XMLElement* pObjectGroup = mapNode->FirstChildElement("objectgroup");
	if (pObjectGroup != NULL) {
		while (pObjectGroup) {
			const char* name = pObjectGroup->Attribute("name");
			std::stringstream ss;
			ss << name;
			if (ss.str() == "collisions") {
				XMLElement* pObject = pObjectGroup->FirstChildElement("object");
				if (pObject != NULL) {
					while (pObject) {
						float x, y, width, height;
						x = pObject->FloatAttribute("x");
						y = pObject->FloatAttribute("y");
						width = pObject->FloatAttribute("width");
						height = pObject->FloatAttribute("height");

						collisionRects.push_back(Rect(
							std::ceil(x)*globals::SPRITE_SCALE,
							std::ceil(y)*globals::SPRITE_SCALE,
						std::ceil(width)*globals::SPRITE_SCALE,
							std::ceil(height)*globals::SPRITE_SCALE
						));

						pObject = pObject->NextSiblingElement("object");
					}
				}
			}
			//other object groups go here if name == "...";
			else if (ss.str() == "slopes") {
				XMLElement* pObject = pObjectGroup->FirstChildElement("object");
				if (pObject != NULL) {
					while (pObject) {
						std::vector<Vector2> points;
						Vector2 p1;
						p1 = Vector2(std::ceil(pObject->FloatAttribute("x")), std::ceil(pObject->FloatAttribute("y")));

						XMLElement* pPolyline = pObject->FirstChildElement("polyline");
						if (pPolyline != NULL) {
							std::vector<std::string> pairs;
							const char* pointString = pPolyline->Attribute("points");

							std::stringstream ss;
							ss << pointString;
							Utils::split(ss.str(), pairs, ' ');
							//we have all the pairs now, which need to be split into Vector2s and stored in the "points" vector
							for (int i = 0; i < pairs.size(); i++) {
								std::vector<std::string> ps;
								Utils::split(pairs.at(i), ps, ',');
								points.push_back(Vector2(std::stoi(ps.at(0)), std::stoi(ps.at(1))));
							} 
						}

						for (int i = 0; i < points.size(); i += 2) {
							slopes.push_back(Slope(Vector2((p1.x + points.at(i<2?i:i-1).x) * globals::SPRITE_SCALE, (p1.y + points.at(i<2?i:i-1).y) *globals::SPRITE_SCALE),
													Vector2((p1.x + points.at(i<2?i+1:i).x) * globals::SPRITE_SCALE, (p1.y + points.at(i<2?i+1:i).y) * globals::SPRITE_SCALE)));
						}

						pObject = pObject->NextSiblingElement("object");
					}
				}
			}

			else if (ss.str() == "spawnpoints") {
				XMLElement* pObject = pObjectGroup->FirstChildElement("object");
				if (pObject != NULL) {
					while (pObject) {
						float x = pObject->FloatAttribute("x");
						float y = pObject->FloatAttribute("y");
						const char* name = pObject->Attribute("name");
						std::stringstream ss;
						ss << name;
						if (ss.str() == "player") {
							spawnPoint = Vector2(std::ceil(x)*globals::SPRITE_SCALE, std::ceil(y)*globals::SPRITE_SCALE);
						}

						pObject = pObject->NextSiblingElement("object");
					}
				}
			}
			else if (ss.str() == "doors") {
				XMLElement* pObject = pObjectGroup->FirstChildElement("object");
				if (pObject != NULL) {
					while (pObject) {
						float x = pObject->FloatAttribute("x");
						float y = pObject->FloatAttribute("y");
						float w = pObject->FloatAttribute("width");
						float h = pObject->FloatAttribute("height");
						Rect rect = Rect(x, y, w, h);

						XMLElement* pProperties = pObject->FirstChildElement("properties");
						if (pProperties != NULL) {
							while (pProperties) {
								XMLElement* pProperty = pProperties->FirstChildElement("property");
								if (pProperty != NULL) {
									while (pProperty) {
										const char* name = pProperty->Attribute("name");
										std::stringstream ss;
										ss << name;
										if (ss.str() == "destination") {
											const char* value = pProperty->Attribute("value");
											std::stringstream ss2;
											ss2 << value;
											Door door = Door(rect, ss2.str());
											doorList.push_back(door);
										}

										pProperty = pProperty->NextSiblingElement("property");
									}
								}
								

								pProperties = pProperties->NextSiblingElement("properties");
							}
						}

						pObject = pObject->NextSiblingElement("object");
					}
				}
			}
			else if (ss.str() == "enemies") {
				float x, y;
				XMLElement* pObject = pObjectGroup->FirstChildElement("object");
				if (pObject != NULL) {
					while (pObject) {
						x = pObject->FloatAttribute("x");
						y = pObject->FloatAttribute("y");
						const char* name = pObject->Attribute("name");
						std::stringstream ss;
						ss << name;
						if (ss.str() == "bat") {
							enemies.push_back(std::make_shared<Bat>(graphics, Vector2(std::floor(x)*globals::SPRITE_SCALE, std::floor(y)*globals::SPRITE_SCALE)));
						}

						pObject = pObject->NextSiblingElement("object");
					}
				}
			}


			pObjectGroup = pObjectGroup->NextSiblingElement("objectgroup");

		}
	}

}

void Level::update(int elapsedTime, Player &player) {
	for (int i = 0; i < animatedTileList.size(); i++) {
		animatedTileList.at(i).update(elapsedTime);
	}
	for (int i = 0; i < enemies.size(); i++) {
		enemies.at(i)->update(elapsedTime, player);
	}
}

void Level::draw(Graphics& graphics) {
	//Draw the background
	for (int i = 0; i < tileList.size(); i++) {
		tileList.at(i).draw(graphics);
	}
	for (int i = 0; i < animatedTileList.size(); i++) {
		animatedTileList.at(i).draw(graphics);
	}
	for (int i = 0; i < enemies.size(); i++) {
		enemies.at(i)->draw(graphics);
	}
}

std::vector<Rect> Level::checkTileCollisions(const Rect &other) {
	std::vector<Rect> others;
	for (int i = 0; i < collisionRects.size(); i++) {
		if (collisionRects.at(i).collidesWith(other)) {
			others.push_back(collisionRects.at(i));
		}
	}
	return others;
}

std::vector<Slope> Level::checkSlopeCollisions(const Rect &other) {
	std::vector<Slope> others;
	for (int i = 0; i < slopes.size(); i++) {
		if (slopes.at(i).collidesWith(other)) {
			others.push_back(slopes.at(i));
		}
	}
	return others;
}

std::vector<Door> Level::checkDoorCollisions(const Rect &other) {
	std::vector<Door> others;
	for (int i = 0; i < doorList.size(); i++) {
		if (doorList.at(i).collidesWith(other)) {
			others.push_back(doorList.at(i));
		}
	}
	return others;
}

std::vector<std::shared_ptr<Enemy>> Level::checkEnemyCollision(const Rect &other) {
	std::vector<std::shared_ptr<Enemy>> others;
	for (int i = 0; i < enemies.size(); i++) {
		if (enemies.at(i)->getBoundingBox().collidesWith(other)) {
			others.push_back(enemies.at(i));
		}
	}
	return others;
}

const Vector2 Level::getPlayerSpawnPoint() const {
	return spawnPoint;
}

Vector2 Level::getTilesetPosition(Tileset tls, int gid, int tileWidth, int tileHeight) {
	//calculate the position of the tile in the tileset
	int tilesetWidth, tilesetHeight;
	SDL_QueryTexture(tls.texture, NULL, NULL, &tilesetWidth, &tilesetHeight);
	int tilesetx = (gid-1) % (tilesetWidth / tileWidth);
	tilesetx *= tileWidth;
	int tilesety = 0;
	int amount = (gid - tls.firstGid) / (tilesetWidth / tileWidth);
	tilesety = amount * tileHeight;
	Vector2 finalTilesetPosition = Vector2(tilesetx, tilesety);
	return finalTilesetPosition;
}