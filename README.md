# Elemental-Quest

Group Members :

1. Muhammad Danish Irfan bin Nasimussobah
2. Muhammad Izzudin bin Bakar
3. Luqmanul Hakim bin Ahmad Azizi
4. Hariz Hakimi bin Jasri
5. Mohammad Nazri Aizad bin Mohammad Nazroel


Project description :

Elemental Quest features a turn-based combat system where players can attack using elemental based skills, switch element or use potions from their inventory. There are 3 elements which are Fire, Water, and Grass. The logic is simple, Fire can burn Grass, Water can extinguish Fire, while Grass can absorb Water. This is what makes the battle balance. Also, potions provide healing and temporary damage boost. Thus, an inventory system is implemented to manage potions. Besides, a shop system is developed to allows players to purchase additional potions using gold earned from winning battles. After each victory, players receive rewards such as gold or items that can be used to prepare for next battle. 

The goal of this game is to defeat the enemy by reducing their health points (HP) to zero. Before each battle, the player selects an element while the enemy’s element remains hidden until the fight begins. During combat, the player may have the disadvantage if the element selected is weaker against enemy’s element, therefore the player is allowed to switch elements to gain advantage. However, this action consumes one turn. Both the player and the enemy have levels that affect their health and damage output. Hence, making the gameplay increasingly difficult.

System Features :

1. Character class (base combat system)
- This class represents a basic character in game. It manages important battle attributes such as name, health points, shield, and damage. This class also contains method Attack() that contains attacking logic including shield blocking and health reduction. This class acts as a parent class for both players and enemies.

2. Player class (player management)
- Player class extends Character and add player's features such as gold and inventory systems. It allows player to earn gold from the battle as well as stores the items such as potions. This class represents main character that can be controlled by the player in the game.

3. Enemy class (enemy customization)
- Enemy class extends Charaster's class and allowing enemy to have health points and damage that can be changed. It enables different enemy types such as Goblin, Orc, and Dragon with increasing difficulty across levels.

4. Menu class (game navigation system)
- This class controls the main game flow and user interface. It shows the main menu, handles level selection, starts battle, and manages player movement during the battle such as attacking, using potion, or run.

5. Shop class (item purchasing system)
- Shop class provides a potion shop features where player can buy potions using gold. It shows available items, checks gold availability, and adds purchased potions to the player's inventory

6. Potion class (consumable items)
- This class defines potions with different effects such as healing health or activating shields. Every potions contain name, type, effect value, and price,  as well as can be used during battle to help player.

7. Inventory class (item storage & usage)
- Inventory clas stores all the potions owned by the player. It enables player to see the available items and use potions during the battle, as well as removing used items from the inventory.

8. Game class (program entry point)
- This class contains Main() method and serves as the starting point of the game. It displays the game intorduction, and launches the main menu system.

OOP concepts used :
- Encapsulation
- Inheritance
- Polymorphism
- Abstraction



