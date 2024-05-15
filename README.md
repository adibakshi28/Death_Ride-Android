# Death Ride

Death Ride is a thrilling obstacle avoidance game set in outer space, developed using the Unity engine. Players control a fast-moving spaceship, navigating through increasingly challenging obstacles as the game progresses and speeds up. This repository includes all necessary files and resources to build, run, and modify the game.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Gameplay](#gameplay)
- [Scripts Overview](#scripts-overview)
  - [GameController.cs](#gamecontrollercs)
  - [LevelController.cs](#levelcontrollercs)
  - [PlayerController.cs](#playercontrollercs)
  - [ObstacleController.cs](#obstaclecontrollercs)
  - [UIController.cs](#uicontrollercs)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction

Death Ride is an exciting 3D obstacle avoidance game where players must deftly maneuver a spaceship through a perilous outer space landscape. Built with Unity, it offers a smooth and immersive experience for Android users.

<div style="display: flex; justify-content: space-between;">
  <img src="Game%20Screenshot/DR0.png" alt="Game Screenshot 1" style="width: 32%;">
  <img src="Game%20Screenshot/DR1.png" alt="Game Screenshot 2" style="width: 32%;">
  <img src="Game%20Screenshot/DR2.png" alt="Game Screenshot 3" style="width: 32%;">
</div>

## Features

- **Intuitive Controls:** Smooth touch controls for seamless gameplay.
- **Increasing Difficulty:** Obstacles become more challenging as the game progresses.
- **High-Quality Graphics:** Stunning 3D graphics and animations.
- **Immersive Sound Effects:** High-quality sound effects to enhance the gaming experience.
- **Real-time Feedback:** Instant feedback on player performance.
- **Cross-Platform:** Built with Unity for easy portability.

## Installation

To set up and run the project locally, follow these steps:

### Prerequisites

- Unity Hub installed.
- Unity Editor version 2020.3.0f1 or later.
- Android SDK configured.

### Steps

1. Clone the repository:

    ```sh
    git clone https://github.com/adibakshi28/Death_Ride-Android.git
    ```

2. Open the project in Unity:
    - Open Unity Hub.
    - Click on "Add" and select the cloned project directory.
    - Open the project.

3. Configure Build Settings for Android:
    - Navigate to `File > Build Settings`.
    - Select Android and click on `Switch Platform`.
    - Adjust player settings, including package name and version.

4. Build the Project:
    - Connect your Android device or set up an emulator.
    - Click on `Build and Run` to generate the APK and install it on the device.

## Usage

After building the project, install the APK on your Android device. Launch the game and follow the on-screen instructions to start playing. Use touch controls to navigate through levels and avoid obstacles.

## Project Structure

- **Assets:** Contains all game assets, including:
    - **Scenes:** Different levels and menus.
    - **Scripts:** C# scripts for game logic.
    - **Prefabs:** Pre-configured game objects.
    - **Animations:** Animation controllers and clips.
    - **Audio:** Sound effects and music files.
    - **UI:** User interface elements.
- **Packages:** Unity packages used in the project.
- **ProjectSettings:** Project settings including input, tags, layers, and build settings.
- **.gitignore:** Specifies files and directories to be ignored by Git.
- **LICENSE:** The license under which the project is distributed.
- **README.md:** This readme file.

## Gameplay

Players navigate through a series of levels, each presenting unique obstacles and challenges. The game includes:

- **Levels:** Each level offers different challenges to solve.
- **Objectives:** Avoid obstacles to achieve high scores and progress.
- **Scoring:** Points are awarded based on performance and efficiency.
- **Feedback:** Real-time feedback to help players improve.

<div style="display: flex; justify-content: space-between;">
  <img src="Game%20Screenshot/DR3.png" alt="Game Screenshot 4" style="width: 32%;">
  <img src="Game%20Screenshot/DR4.png" alt="Game Screenshot 5" style="width: 32%;">
  <img src="Game%20Screenshot/DR5.png" alt="Game Screenshot 6" style="width: 32%;">
</div>

## Scripts Overview

The `Assets/Scripts` directory contains essential C# scripts that drive the game's functionality. Here's a detailed overview:

### GameController.cs

Manages the overall game state, including game flow, starting and ending sessions, tracking player progress, and updating the UI with scores and other information.

### LevelController.cs

Handles the setup and control of individual game levels. It initializes level-specific elements, tracks progress within levels, and manages transitions between levels.

### PlayerController.cs

Defines the behavior of the player character, including movement and interactions with the environment.

### ObstacleController.cs

Manages the logic for the obstacles in the game, including setup, interactions, and maintaining obstacle states.

### UIController.cs

Manages the user interface, handling interactions with menus, buttons, and other UI elements.

## Contributing

Contributions are welcome and greatly appreciated. To contribute:

1. Fork the repository:
    - Click the "Fork" button at the top right of the repository page.

2. Create a feature branch:

    ```sh
    git checkout -b feature/AmazingFeature
    ```

3. Commit your changes:

    ```sh
    git commit -m 'Add some AmazingFeature'
    ```

4. Push to the branch:

    ```sh
    git push origin feature/AmazingFeature
    ```

5. Open a pull request:
    - Navigate to your forked repository.
    - Click on the "Pull Request" button and submit your changes for review.

## License

This project is licensed under the MIT License. See the LICENSE file for more information.

## Contact

For any inquiries or support, feel free to contact:

[Adibakshi28 - GitHub Profile](https://github.com/adibakshi28)

Project Link: [Death Ride-Android](https://github.com/adibakshi28/Death_Ride-Android)
