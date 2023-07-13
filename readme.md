Bullion - GoldSrc engine reimplementation in Unity
==================================================

Use cases:

* Unity-based reimplementation of the GoldSrc engine, capable of loading original Half Life DLLs (and those of other mods).
* Engine itself is extendable, so other games can be built on top of it that use GoldSrc approaches and also modern Unity features.
* GoldSrc asset importing and management.

## Minimal PoC

Two rooms, separated by a door. The player can walk up to the door and touch it to open it.

This demonstrates:

* Loading of static BSP geometry
* Loading of BSP entities (brush and point)
* Player movement
* Entity logic
* Entity networking

### Implementation Requirements

* Unity 2022.3.4f1 LTS
* Unity Netcode for GameObjects 1.5.1
* Unity package, which contains:
	* PoC/engine code
	* Static library for player movement code
	* Dynamic library for game-based entity code (player and door logic)
