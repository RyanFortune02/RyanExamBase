# QuestBalloonTemplate

This template adds balloons to the [Unity 2020 Quest 2 Starting Template](https://github.com/AlexWills37/UnityQuest2020Template).

There is now a balloon prefab! Initially, the balloon will not do anything. It is not affected by gravity and will not move much when something collides with it.

In the scene, you can pick up the balloon with the triggers on the Quest 2 controllers. When you let go of the balloon, it will float into the sky.

https://github.com/AlexWills37/QuestBalloonTemplate/assets/77563588/bfbda9c0-cb7a-46a2-9b9b-efec0c27a768

In the inspector, you can customize the following properties:

- **Max Float Speed**: the maximum speed the balloon will float up into the sky (m/s).
- **Float Acceleration**: how quickly the balloon will reach the **Max Float Speed** when let go (m/s^2).
- **Rotation Speed**: how quickly the balloon will rotate to become upright when let go (degrees/s).

You can find the script that controls the balloon [here in the assets folder](./UnityQuest2020BalloonTemplate/Assets/Scripts/Template/BalloonBehavior.cs).

## Technology Used

- Unity 2020.3.48
- Oculus Integration Package v50.0
- Quest 2 headset

## Credits

[The balloon model](https://www.cgtrader.com/free-3d-models/interior/other/free-3d-balloon) is from *WilliamJ7* on cgtrader.com.
