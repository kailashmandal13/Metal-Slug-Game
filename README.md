# Metal Slug 6 - Unity3D Project

**Course**: COP701 (Assignment 2)  
**Assignment**: Metal Slug 6 Game  
**Platform**: Standalone Application (Unity)  
**Team**: `<Aditya Narayan>` | `<Kailash Mandal>` 

---

## Overview

**Metal Slug 6** is a classic run-and-gun platform game developed as part of the COP701 course at IIT Delhi. In this project, we recreate the action, challenging gameplay, and feel of Metal Slug using **Unity3D**.

The game features smooth graphics, progressive 3 levels, and dynamic gameplay. Players fight through various themed levels filled with enemies, traps, and boss battles while collecting power-ups and upgrading their weapons.

---

## Game Features

### 1. **Player Mechanics**
- **Movement**: Players can move left and right, jump, crouch, and shoot.
- **Health System**: Players have a health bar that depletes when hit by enemies.
- **Weapon System**: Players start with a basic rifle and can pick up additional weapons (spread shots, laser beams, rapid-fire).

### 2. **Enemies**
- A variety of enemy types including alien creatures, soldiers, and mechanical foes.
  
### 3. **Levels**
- **Three Levels**: Each level has a unique theme (Jungle, Base, Alien Ship) and becomes progressively harder.
- **Obstacles**: Levels include platforms, traps, and moving hazards.
- **Boss Battles**: Each level ends with a boss fight, featuring powerful enemies with unique abilities.

### 4. **Visuals & Graphics**
- **Smooth Animations**: Fluid character animations for running, jumping, shooting, and attacking.
- **Visual Effects**: Special effects for explosions, gunfire, and power-ups.
- **Dynamic Lighting**: Enhanced level aesthetics with dynamic lighting and shadows.

### 5. **Sound & Music**
- Custom sound effects for shooting, explosions, enemy attacks, and power-ups.
- Background music for each level to enhance the gaming experience.

---

## Bonus Features
- **Power-ups**: Collectible power-ups include spread shots, laser beams, and health boosts.
- **Multiplayer**: Option for multiple players to complete levels together (if implemented).
- **Lives**: Players have limited lives, with extra lives available as power-ups.

---

## Project Structure

The project is modular, with each component of the game divided into separate scripts for easy maintainability and scalability.

### 1. **Scripts**
- **PlayerController.cs**: Manages player movement, shooting, and interactions with the environment.
- **EnemyController.cs**: Handles enemy AI behavior, attack patterns, and health system.
- **WeaponSystem.cs**: Controls weapon upgrades and shooting mechanics.
- **HealthSystem.cs**: Tracks player and enemy health, updating the UI.
- **UIManager.cs**: Manages the game’s UI, including the health bar, score display, and weapon status.
- **LevelManager.cs**: Manages level transitions, loading/unloading scenes, and level difficulty.

### 2. **Assets**
- **Sprites**: All character, enemy, and environment sprites are stored under `/Assets/Sprites`.
- **Animations**: Smooth animations for player movements, enemy actions, and special effects under `/Assets/Animations`.
- **Sounds**: Sound effects and background music are found under `/Assets/Sounds`.

## References

- [Metal Slug Gameplay](https://www.youtube.com/watch?v=V_tXiOcIS_c&t=1123s)
- [Unity3D Documentation](https://docs.unity3d.com/Manual/)

---

## Installation & Setup

### Prerequisites
- Unity3D (version 2021.x or above recommended)
- Git installed for version control

### Steps to Run the Game
1. **Clone the Repository**:
   ```bash
   git clone <https://github.com/kailashmandal13/Metal-Slug-Game>
