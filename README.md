# jogoEtec — ETEC de Araraquara

<p align="center">
  <strong>Educational Multiplayer Game</strong>
</p>

<p align="center">
  A 2D multiplayer game developed for <strong>ETEC de Araraquara</strong>, combining game development, education and decision-making mechanics.
</p>

---

## About the Project

**jogoEtec** is a multiplayer educational game developed with **Unity and C#**, set in an environment inspired by an ETEC campus.

The game was specifically developed for **ETEC de Araraquara**, using game mechanics to represent challenges commonly experienced by students throughout their academic journey.

The player must develop and balance three fundamental attributes:

* 🧠 **Knowledge**
* 💼 **Experience**
* ⚡ **Energy**

The central gameplay mechanic is based on maintaining a balance between these three forces.

Different decisions and activities affect the player's development, requiring the player to determine how to allocate time and resources throughout the game.

---

## 🎓 Developed for ETEC de Araraquara

The project was created specifically within the educational context of **ETEC de Araraquara**.

Rather than being developed purely as a game-development exercise, the project was designed to connect software development with an educational environment familiar to students.

The ETEC environment becomes part of the game's narrative and mechanics, creating a direct relationship between:

```text
Education
    ↓
Student Experience
    ↓
Game Mechanics
    ↓
Decision Making
    ↓
Interactive Learning
```

This makes the project an example of **educational technology combined with game development**.

---

## 🎮 Game Concept

The central concept is simple:

> A student needs to develop professionally without sacrificing knowledge, experience or personal energy.

The three attributes create a dynamic balance:

```text
                 KNOWLEDGE
                     ▲
                     │
                     │
                     │
 EXPERIENCE ◄────────┼────────► ENERGY
                     │
                     │
                     ▼
                  BALANCE
```

The player's decisions influence these attributes.

Excessive focus on one area can negatively affect the others, creating a strategic decision-making system.

---

## Core Gameplay

The game is structured around several interconnected systems.

### 🧠 Knowledge

Represents the student's academic development.

Activities related to studying, learning and academic progression can influence this attribute.

### 💼 Experience

Represents practical and professional development.

Activities and challenges can increase the player's experience and help prepare the character for professional situations.

### ⚡ Energy

Represents the player's available energy and ability to continue performing activities.

The player must manage energy carefully instead of focusing exclusively on academic or professional progression.

### ⚖️ Balance

The main strategic element of the game is maintaining a healthy balance between:

```text
Knowledge
    +
Experience
    +
Energy
```

This turns the game into a decision-making system rather than simply an action-based game.

---

## 🕹️ Multiplayer

The project was designed as a **multiplayer game**, allowing the educational environment to become an interactive experience involving multiple players.

Multiplayer gameplay introduces additional software engineering challenges, including:

* Player state management
* Synchronization
* Network communication
* Shared game state
* Multiplayer interactions
* Game-session management

These concepts are particularly relevant to real-time software engineering beyond traditional web applications.

---

## 🧩 Game Systems

The repository contains several game systems organized around specific gameplay responsibilities.

Current project directories include systems related to:

* Player
* Maps
* Minigames
* Inventory
* Store
* Dialogues
* Time
* Player attribute bars
* Sprites

The repository also contains supporting project documentation and development assets.

---

## 🏗️ Architecture

The project is organized around independent gameplay systems.

A simplified conceptual architecture is:

```text
                    ┌─────────────────┐
                    │   Game Manager  │
                    └────────┬────────┘
                             │
        ┌────────────────────┼────────────────────┐
        │                    │                    │
        ▼                    ▼                    ▼
   Player System        World / Maps        Game Systems
        │                    │                    │
        │                    │          ┌─────────┼─────────┐
        │                    │          │         │         │
        ▼                    ▼          ▼         ▼         ▼
  Attributes            Environment  Inventory  Store   Minigames
        │
        ├── Knowledge
        ├── Experience
        └── Energy
```

This organization makes it possible to develop and evolve individual gameplay systems without putting all game logic into a single component.

---

## 🧱 Technology Stack

| Technology    | Purpose                                         |
| ------------- | ----------------------------------------------- |
| Unity         | Game engine                                     |
| C#            | Gameplay and application logic                  |
| Unity 2D      | 2D game environment                             |
| Pixel Art     | Visual style                                    |
| Multiplayer   | Networked gameplay                              |
| Unity Systems | Scenes, objects, components and game management |

The repository explicitly identifies **Unity Engine and C#** as its primary development technologies and describes the game as a 2D pixel-art experience.

---

## 🗺️ Game World

The game world is designed around an ETEC-inspired environment.

The repository contains a dedicated `Mapas` area as part of the game's development structure.

This allows the physical and conceptual environment of an educational institution to become part of the gameplay.

Instead of using a generic game environment, the project incorporates elements connected to the students' academic reality.

---

## 🎯 Minigames

The project contains a dedicated **Minigames** system.

Minigames provide opportunities to introduce specific challenges and interactions without changing the overall gameplay structure.

They can be used to represent:

* Academic activities
* Challenges
* Skill development
* Interactive learning
* Time-based decisions
* Player progression

This modular approach makes it possible to add new challenges without redesigning the entire game.

---

## 🎒 Inventory System

The repository contains a dedicated inventory system.

An inventory provides the game with a mechanism for managing objects and resources acquired by the player.

Conceptually:

```text
Player
  │
  ▼
Inventory
  │
  ├── Items
  ├── Resources
  └── Game Objects
```

This is a common gameplay pattern that also demonstrates state management and object-oriented design.

---

## 🛒 Store System

The project includes a dedicated store system.

The store introduces an additional layer of game economy and resource management.

The conceptual interaction is:

```text
Player
   │
   ▼
Available Resources
   │
   ▼
     Store
   │
   ▼
Items / Benefits
   │
   ▼
Player Progression
```

This allows the game to incorporate economic decisions into the player's overall strategy.

---

## 💬 Dialogue System

A dedicated dialogue system is included in the project.

Dialogue systems are particularly useful for educational games because they allow information, instructions and narrative elements to be presented interactively.

The repository contains a dedicated `Sist. Diálogo` system.

A dialogue system can also be extended to support:

* NPC interactions
* Narrative progression
* Tutorials
* Quests
* Educational content
* Conditional conversations

---

## ⏰ Time System

The project contains a dedicated time-management system.

The `Sist. Horário` component indicates that time is treated as an independent gameplay concern.

This is particularly relevant to the game's educational concept because the player must make decisions about how to use limited time.

Conceptually:

```text
Available Time
      │
      ├── Study
      ├── Experience
      ├── Rest
      └── Other Activities
```

The player's decisions therefore affect both progression and resource management.

---

## 📊 Player Attributes

The game uses a dedicated system for player status bars.

The repository contains a `Sist. Barras` system, which supports the concept of monitoring the player's different attributes during gameplay.

The primary conceptual attributes are:

```text
Knowledge      ███████░░░
Experience     █████░░░░░░
Energy         ████████░░
```

The player must continuously monitor these values and make decisions based on their current state.

---

## 👤 Player System

The repository contains a dedicated `Player` system inside the game's development structure.

Separating player functionality from other game systems provides a foundation for:

* Player movement
* Player state
* Attribute management
* Interactions
* Inventory
* Progression
* Multiplayer representation

---

## 🎨 Pixel Art

The game uses a **2D pixel-art visual style**.

Pixel art provides a lightweight visual approach while maintaining a distinctive game identity.

The repository also contains a dedicated `Sprites` area for game assets and development resources.

---

## 🔄 Gameplay Model

The overall gameplay can be represented as:

```text
                 ┌──────────────┐
                 │    Player    │
                 └──────┬───────┘
                        │
                        ▼
                ┌───────────────┐
                │ Make Decision │
                └───────┬───────┘
                        │
          ┌─────────────┼─────────────┐
          │             │             │
          ▼             ▼             ▼
      Knowledge     Experience      Energy
          │             │             │
          └─────────────┼─────────────┘
                        │
                        ▼
                  Player State
                        │
                        ▼
                  New Decision
```

This creates a feedback loop where every decision influences the player's future possibilities.

---

## 🧠 Software Engineering Concepts

Although this is a game, the project demonstrates several concepts applicable to traditional software engineering.

### Object-Oriented Programming

C# and Unity provide an object-oriented development environment based on classes, components and game objects.

### Component-Based Architecture

Unity's component model encourages the separation of behavior into reusable components.

### State Management

The game must maintain the state of:

* Players
* Attributes
* Inventory
* Time
* Game progression
* World state
* Multiplayer interactions

### Event-Driven Interactions

Player actions and game events can trigger changes in other systems.

### Modular Systems

The project separates gameplay concerns into dedicated systems such as:

* Player
* Inventory
* Store
* Dialogue
* Time
* Minigames
* Maps
* Attributes

This modularity is valuable for maintaining and extending game projects.

---

## 🌐 Multiplayer Software Engineering

One of the technically interesting aspects of the project is its multiplayer nature.

Multiplayer applications introduce problems that are also common in distributed systems:

```text
Client A
    │
    │
    ▼
┌──────────────┐
│ Network /    │
│ Game Session │
└──────────────┘
    ▲
    │
    │
Client B
```

The architecture must consider:

* State synchronization
* Network latency
* Player actions
* Shared state
* Session lifecycle
* Consistency between clients

These concepts provide useful experience applicable to real-time applications, multiplayer systems and distributed software.

---

## 🎓 Educational Technology

A particularly important characteristic of this project is its educational purpose.

The project combines:

**Education + Game Development + Software Engineering**

The game transforms concepts related to student development into interactive mechanics.

Instead of presenting the concept through traditional educational material, the project allows students to experience the consequences of their decisions through gameplay.

This is an example of **gamification and educational technology** applied to a real educational environment.

---

## 🏫 Real-World Context

**Project:** jogoEtec
**Institution:** ETEC de Araraquara
**Type:** Educational Multiplayer Game
**Platform:** Unity
**Programming Language:** C#
**Visual Style:** 2D Pixel Art

The project was developed specifically for the **ETEC de Araraquara**, connecting software development with an educational environment.

This makes it a useful example of building software for a specific institutional context rather than developing a purely generic technical exercise.

---

## 📁 Repository Organization

The repository currently contains:

```text
jogoEtec/
│
├── Documentos/
│   ├── AutorizacaoSprites/
│   ├── BancoTcc/
│   └── Sprites/
│
├── MI - Missão Industrial/
│   ├── Mapas/
│   ├── Minigames/
│   ├── Player/
│   ├── Sist. Barras/
│   ├── Sist. Diálogo/
│   ├── Sist. Horário/
│   ├── Sist. Inventário/
│   ├── Sist. Loja/
│   └── Sprites/
│
├── .gitignore
├── LICENSE
└── README.md
```

The current repository structure confirms the presence of multiple dedicated game systems and supporting documentation/assets.

---

## 🚀 Possible Future Improvements

Potential improvements for a modern version of the project could include:

* [ ] Modernize the Unity project
* [ ] Improve multiplayer networking architecture
* [ ] Add dedicated game server infrastructure
* [ ] Implement player accounts
* [ ] Persist player progression
* [ ] Add achievements
* [ ] Add leaderboards
* [ ] Improve matchmaking
* [ ] Add analytics
* [ ] Add accessibility options
* [ ] Add localization / multiple languages
* [ ] Improve mobile support
* [ ] Add automated build pipeline
* [ ] Add CI/CD for Unity builds
* [ ] Add automated gameplay tests
* [ ] Improve documentation
* [ ] Create gameplay videos/GIFs for the repository

---

## 💼 Portfolio Value

This project adds a different dimension to a software engineering portfolio.

While many software portfolios focus exclusively on CRUD applications and REST APIs, **jogoEtec demonstrates experience with interactive software and real-time systems**.

It showcases:

```text
C#
       +
Unity
       +
Game Development
       +
Multiplayer
       +
State Management
       +
Modular Architecture
       +
Educational Technology
```

This makes the project relevant to roles involving:

* Software Engineering
* C# Development
* Unity Development
* Game Development
* Interactive Applications
* Real-Time Systems
* Multiplayer Systems
* Educational Technology
* Technical Leadership

---

## 🔬 Why This Project Is Interesting

From a software engineering perspective, the most interesting aspect is not simply that it is a game.

The project demonstrates the ability to transform an abstract educational concept into a software system.

The concept:

> Balance knowledge, experience and energy.

becomes:

```text
Game Rules
     ↓
Player Attributes
     ↓
Time Management
     ↓
Player Decisions
     ↓
Game State
     ↓
Progression
```

This is essentially a **domain-modeling problem**, implemented through interactive software.

---

## 👨‍🏫 Educational Development Context

The project also reflects the connection between software development and teaching at **ETEC de Araraquara**.

It demonstrates how a software project can be used simultaneously as:

* A programming project
* A game-development project
* An educational technology experiment
* A student engagement tool
* A practical software engineering case study

This combination is particularly representative of projects developed within an educational technology environment.

---

## 👥 Development Team & Contributors

**jogoEtec** was developed as a collaborative project for **ETEC de Araraquara**, bringing together software development, game design and educational objectives.

### Project Coordination

**Marcelo Torres**
Project coordination, software development, architecture and educational context.

### Contributors

Special thanks to the students and collaborators who contributed to the development of the project:

| Contributor             | Contribution                   |
| ----------------------- | ------------------------------ |
| **Danielly029 (https://github.com/Danielly029)** | Game development / programming |
| **GabiFM010 (https://github.com/GabiFM010)** | Game development / programming |
| **Rafael12258 (https://github.com/Rafael12258)** | Game design / gameplay         |

> This project was developed collaboratively, providing students with practical experience in software engineering, C#, Unity, game development, version control and team-based development.

### 🤝 Collaborative Development

The project represents a collaborative software-development experience within the **ETEC de Araraquara** educational environment.

Contributors participated in different aspects of the project, including:

* C# programming
* Unity development
* Gameplay systems
* Game design
* Level and map development
* UI and dialogue systems
* Game assets
* Testing and debugging
* Documentation
* Version control and collaboration

The collaborative nature of the project is an important part of its educational value, providing an environment where students could experience practices similar to those used by professional software-development teams.

### 🎓 Educational Context

The project was developed for **ETEC de Araraquara** with the goal of combining technical learning with practical software development.

Rather than being an individual coding exercise, **jogoEtec** was developed as a team project, allowing participants to work with different responsibilities within a larger software system.

This included working with:

```text
Requirements
     ↓
Game Design
     ↓
Programming
     ↓
Integration
     ↓
Testing
     ↓
Iteration
     ↓
Final Game
```

This collaborative workflow mirrors important practices found in professional software-engineering teams.

---

## 📄 License

This project is licensed under the **MIT License**.

See the `LICENSE` file for details.

---

## 👨‍💻 Author

**Marcelo Torres**

Software Engineer | Full-Stack Developer | Technical Lead | Educator

Areas of interest:

* Software Engineering
* Backend Development
* Full-Stack Development
* Mobile Applications
* Cloud Computing
* Real-Time Systems
* Game Development
* Educational Technology
* Software Architecture

---

## Final Note

**jogoEtec** was developed for **ETEC de Araraquara** as an educational multiplayer game that combines software engineering, game development and student-centered decision-making.

The project demonstrates that software can go beyond traditional business applications and be used to create **interactive educational experiences**, while still requiring many of the same engineering principles found in large-scale software systems.
