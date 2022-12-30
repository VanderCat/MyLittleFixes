# My Little Fixes
A collection of small tweaks made for **My Little Pony: A Maretime Bay Adventure**
## Changes
### Bugfix
1. Fix Pause screen for mods (refer to config)
2. Disable mouse
### Gameplay
1. Disable Shimmerwing (Guide system)

Each change can be tweaked in config
## Installation
1. Install BepInEx 5.x
2. Place mod DLL in plugins folder
3. Launch the game
4. Edit the config
## Compiling it yourself
<sup>Since i hate Visual Studio i do not know how to compile it there</sup>
### Using CLI
1. Clone repo:
    ```bash
    git clone http://github.com/VanderCat/MyLittleFixes
    cd MyLittleFixes
    ```
2. Build:
    ```bash
    dotnet build -c Release
    ```
### Using Rider
1. Clone repo:
    ```bash
    git clone http://github.com/VanderCat/MyLittleFixes
    cd MyLittleFixes
    ```
    OR  
    You can clone it using **"Get from Version Control"** Button
2. Change configuration to `Release`
3. Press *that green hammer* button
### Visual Studio Code
i guess same as CLI
### Note
You may also want to edit `MyLittleFixes/MyLittleFixes.csproj` Assembly reference paths 
to be compatible with your setup. If you have Unity 2020.3.26f1 installed only change location
of game specific Assemblies and `UnityEngine.UI` to your game location (bcs it's in 
separate Unity package now)