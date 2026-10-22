# <p align=center style="text-align: center;"> Higher Capacity Transformers </p>

<p align="center" style="text-align: center;">
	<img alt="Version" src="https://img.shields.io/badge/Version-1.0.1-orange">
	<img alt="Available for" src="https://img.shields.io/badge/Available_for-Power_Line_Update-blue">
	<img alt="License" src="https://img.shields.io/badge/License-GPL--3.0--or--later-red">
</p>

<p align="center" style="text-align: center;">
	<a alt="Buy Me a Coffee" href="https://buymeacoffee.com/aspctt"><img alt="Buy Me a Coffee" height="40" src="https://cdn.jsdelivr.net/npm/@intergrav/devins-badges@3/assets/compact/donate/buymeacoffee-singular_vector.svg"></a>
</p>

<p align="center" style="text-align: center;">
	<a href="https://steamcommunity.com/sharedfiles/filedetails/?id=3763993963"><img src="https://cdn.jsdelivr.net/npm/@intergrav/devins-badges@3/assets/compact-minimal/available/steam_vector.svg" alt="Available on the Steam Workshop"></a>
	<a href="https://github.com/aspctt/stationeers-higher-capacity-transformers"><img src="https://cdn.jsdelivr.net/npm/@intergrav/devins-badges@3/assets/compact-minimal/available/github_vector.svg" alt="Available on GitHub"></a>
</p>

## Description

Higher Capacity Transformers raises the maximum output of the Medium and Large Transformers in Stationeers so they match the cable maximums. The new limits are set on the transformers themselves as the game loads, and nothing else about them changes.

## What it changes

* **Medium Transformer**: 25,000 W → 100,000 W, on both the standard and reversed variants. Its output setting moves in steps of 500 W, or 50 W for small steps.
* **Large Transformer**: 50,000 W → 500,000 W. Its output setting moves in steps of 5,000 W, or 500 W for small steps.

The steps are scaled up with the limits, so the wider range does not take all day to dial in.

## Installation

Subscribe on the [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=3763993963), or place the `HigherCapacityTransformers` folder from the release zip inside your Stationeers mods folder (e.g. `Documents/My Games/Stationeers/mods/HigherCapacityTransformers`). StationeersLaunchPad loads it on the next launch.

**REMOVE ANY OLD VERSIONS BEFORE INSTALLING.**

## Dependencies

* [StationeersLaunchPad](https://github.com/StationeersLaunchPad/StationeersLaunchPad): loads the mod through BepInEx. Its page covers installing both.

## Licensing

This work is licensed as follows:

* [GNU General Public License, version 3 or (at your option) any later version](https://www.gnu.org/licenses/gpl-3.0.en.html) (GPLv3-or-later). See [LICENSE](./LICENSE).
	+ You are free to:
		- Use : run the program for any purpose.
		- Study & modify : access the source code and change it to suit your needs.
		- Share : redistribute copies, with or without changes.
	+ Under the following terms:
		- Copyleft : any distributed derivative work must also be licensed under the GPLv3, and its complete corresponding source code must be made available.
		- License and copyright notice : you must retain this license, the copyright notice, and a statement of any changes made.
		- No additional restrictions : you may not impose further legal terms or technological measures that restrict the freedoms this license grants.

Please note the copyrights and trademarks in [NOTICE](./NOTICE).

## Credits

### Core Team

* aspctt: design, programming, project lead

### Dependencies and tools

* StationeersLaunchPad contributors: mod loader for Stationeers: [github](https://github.com/StationeersLaunchPad/StationeersLaunchPad)
* BepInEx team: BepInEx plugin framework: [github](https://github.com/BepInEx/BepInEx)
* BepInEx team: HarmonyX runtime patching library, a fork of Andreas Pardeike's Harmony: [github](https://github.com/BepInEx/HarmonyX)

### Acknowledgements

* RocketWerkz: for Stationeers and its modding support.
