# Technical Documentation:

## Dokument 1: Asset Tabelle

| Kategorie   | Name                                         | Typ     | Quelle/URL                                                                                      | Support/Doc                                                               |
|-------------|----------------------------------------------|---------|-------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------|
| Importiert  | OpenXR Plugin                               | Package | [docs.unity3d.com/Packages/com.unity.xr.openxr@1.10/manual/index.html](https://docs.unity3d.com/Packages/com.unity.xr.openxr@1.10/manual/index.html) | [docs.unity3d.com/Manual/com.unity.xr.openxr.html](https://docs.unity3d.com/Manual/com.unity.xr.openxr.html) |
| Importiert  | LowPoly Dungeon Lite                        | Asset   | [assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeon-lite-fantasy-modular-kit-224313](https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeon-lite-fantasy-modular-kit-224313) | [rednebulastudios.com/games/contact](https://www.rednebulastudios.com/games/contact) |
| Importiert  | LowPoly Dungeon - Fantasy Modular Kit       | Asset   | [assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeon-fantasy-modular-kit-224090](https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeon-fantasy-modular-kit-224090) | [rednebulastudios.com/games/contact](https://www.rednebulastudios.com/games/contact) |
| Importiert  | Low-Poly Simple Nature Pack                 | Asset   | [assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153) | N/A                                                                       |
| Importiert  | AllSky Free - 10 Sky / Skybox Set           | Asset   | [assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014) | N/A                                                                       |
| Importiert  | Battle Wizard Poly Art                      | Asset   | [assetstore.unity.com/packages/3d/characters/humanoids/fantasy/battle-wizard-poly-art-128097](https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/battle-wizard-poly-art-128097) | [alexkim0415.wixsite.com/dungeonmason](https://alexkim0415.wixsite.com/dungeonmason) |
| Importiert  | Adobe Sound Library                         | Asset   | [adobe.com/products/audition/offers/AdobeAuditionDLCSFX.html](https://www.adobe.com/products/audition/offers/AdobeAuditionDLCSFX.html) | [adobe.com/de/products/audition/free-sound-effects.html](https://www.adobe.com/de/products/audition/free-sound-effects.html) |
| Selfmade    | Custom Textures                             | Asset   | N/A                                                                                             | N/A                                                                       |
| Importiert  | Polybrush                                   | Tool    | Built-in                                                                                        | [unity.com/de/features/polybrush](https://unity.com/de/features/polybrush) |
| Importiert  | Polybuilder                                 | Tool    | Built-in                                                                                        | [unity.com/features/probuilder](https://unity.com/features/probuilder)    |
| Importiert  | XRI                                          | Package | [docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@0.9/manual/index.html](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@0.9/manual/index.html) | [docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.5/manual/index.html](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.5/manual/index.html) |
| Selfmade    | Mathazar Voiceline               | Asset   | Elevenlabs.io                                                                                   | N/A                                                                       |
| Importiert  | Music                            | Asset   | Pixabay.com                                                                                     | N/A                                                                       |
| Importiert  | HeadCollisionDetector Script    | Asset   | [https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect](https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect) | N/A |
| Importiert  | HeadCollionHandler Script        | Asset   | [https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect](https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect) | N/A |
| Importiert  | FadeEffect Script                | Asset   | [https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect](https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect) | N/A |
| Importiert  | FadeText                         | Asset   | [https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect](https://github.com/SunnyValleyStudio/Unity-VR-Prevent-Head-Clipping-with-Player-Push-Back-and-Fade-effect) | N/A |


## Dokument 2: SW Dokumentation

## Dokument 3: Verzeichnisregister

### AVR_MathazarsDungeonLFS Projektstruktur

**Root-Verzeichnis**
Das Root-Verzeichnis enthält die Hauptordner und Konfigurationsdateien des Projekts.

- **Assets**: Beinhaltet alle Ressourcen wie Grafiken, Audio und Scripts, die im Spiel verwendet werden.
- **Packages**: Speichert die Unity Package Manager Dateien.
- **ProjectSettings**: Enthält Einstellungen und Konfigurationen für das Unity-Projekt.
- **.gitattributes**: Git-Konfigurationsdatei zur Definition von Attributen.
- **.gitignore**: Bestimmt, welche Dateien und Ordner von Git ignoriert werden.
- **.vsconfig**: Konfigurationsdatei für Visual Studio.
- **readme.md**: Eine Markdown-Datei, die eine Übersicht über das Projekt gibt.
- **upgradeLog.htm**: Protokolldatei für Projekt-Upgrades.

### Assets-Verzeichnis
Beherbergt die Spielressourcen, unterteilt in spezifische Kategorien.

- **Art**: Grafikressourcen unterteilt in:
  - **Animations**: Animationen für Charaktere und Objekte.
  - **Materials**: Materialien für die Gestaltung der Spieloberflächen.
  - **Sprites**: 2D-Grafiken für das Spiel.
  - **Textures**: Texturen für 3D-Modelle.
  - **UI**: Elemente für die Benutzeroberfläche.
- **Audio**: Audio-Dateien, unterteilt in:
  - **Music**: Musikstücke für Hintergrundmusik.
  - **SFX**: Soundeffekte für Spielaktionen.
- **Prefabs**: Vorgefertigte Objekte, die im Spiel verwendet werden.
- **Scenes**: Verschiedene Szenen oder Level des Spiels.
- **Scripts**: Quellcode-Dateien in C# für die Spiellogik.
- **Shaders**: Shader-Programme für grafische Effekte.
- **ThirdParty**: Externe Ressourcen und Tools, importiert aus dem Unity Store.
- **XR**: Konfigurationsdateien für VR/AR-Einstellungen (`settings.meta`).