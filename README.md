# PingPong

This project was created initially from the following rough specifications. Several changes were needed to model additional features such as players getting 2 serves each before swapping and the tiebreak and foul rules. I also create a couple of test scenes to help catch bugs and to exercise difficult to trigger situations.

## Object types:
* Player paddle
* Ball
* Score zone
* Score
* Umpire

## Behaviours:
* PlayerControl
* Score
* Serve
* Umpire
* ScoringZone

### PlayerControl behaviour
On update it reads the input axes to move the assigned rigidbody's position up and down. The movement speed should be configurable. The input axis to read must be configurable to read "Player1" or "Player2" from the Input manager. The transform position must be constrained to the top and bottom of the view.

### Score behaviour
This stores the current points for the object. It writes the current points into the assigned UI Text component. It accepts the message ScorePoint to increase the current points by one, and (if the current points are not yet a winning score i.e. less than 10) sends a message Continue to the assigned Umpire object.

### Serve behaviour
It accepts the message Service, spawns the assigned object and aims it at the assigned opposing player transform.

### Umpire behaviour
On start it sends the message Service to a randomly chosen player from it's assigned array of player objects. It accepts the message Continue to swap the currently serving player and send another Service message.

###ScoringZone behaviour
When a ball object enters the attached box trigger, it is destroyed and sends a ScorePoint message to the assigned player's score object.

## Testing

To help with testing I've created a couple of test scenes:
* CollisionTest
* FoulTest

### CollisionTest

This test scene sets up the ball to bounce against a boundary wall. The correct rigidbody collision detection system needs to be selected on the ball to prevent it from punching straight through the wall. Try changing the ball collision system to Discrete instead on Continuous Dynamic to see what happens.

### FoulTest

This test sets up a situation where the scores have gone into a tiebreaker and a player causes a foul by hitting the ball twice before the other player touches it. The rules state that in this situation, the foulling player loses a point. This situation is difficult (but not impossible) to trigger in computer Pong. You can do it by moving the paddle up into the ball at just as it crosses. This causes it to bounce up and down vertically above or below the paddle essentially for ever. However with this check in place it will cause a foul and the fouling player will lose a point. The importance of a test scene here is to ensure that this code is tested as it is so difficult to achieve in play.
