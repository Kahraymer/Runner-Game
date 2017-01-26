local Player = class('Player', require("entity"))
Player.static.size = vector(10, 20)

-- These are the primary constants that control the path of the jump.
Player.static.MAX_JUMP_HEIGHT = 30 -- The height if the jump when the button is pressed the whole time.
Player.static.TIME_TO_APEX = 0.5 -- The time to the maximum height of the jump.
Player.static.MIN_JUMP_HEIGHT = 5 -- This height of the jump if the button is immediately released after being pressed.

Player.static.TIME_BEFORE_MIN_SPEED = 0.05 -- The time before the velocity can be reduced when the jump is released.

-- The physics constants are derived from the jump ARC info above.
Player.static.GRAVITY = 2 * Player.MAX_JUMP_HEIGHT / (Player.TIME_TO_APEX ^ 2)
Player.static.JUMP_SPEED = -math.sqrt(2 * Player.GRAVITY * Player.MAX_JUMP_HEIGHT)
Player.static.JUMP_TERMINATION_SPEED = -math.sqrt(
  Player.JUMP_SPEED^2 - 2 * Player.GRAVITY * (Player.MAX_JUMP_HEIGHT - Player.MIN_JUMP_HEIGHT))

-- Give the player a little bit of buffer, so if they are chaining jumps, but
-- press a jump a little too early, they can still jump.
Player.JUMP_BUFFER = 10

Player:include(Stateful)

function Player:initialize()
  -- The player only has a y-position which corresponds to the bottom-center of
  -- their rectangle. The player's x position is locked at zero.
  self.y = 0
  self.isJumpPressed = false
  self:gotoState('Running')
end
function Player:draw()
  love.graphics.setColor(255, 255, 255, 255)
  love.graphics.rectangle('fill', -Player.size.x/2, self.y - Player.size.y, Player.size:unpack())
end

function Player:jumpPressed() self.isJumpPressed = true end
function Player:jumpReleased() self.isJumpPressed = false end

local Running = Player:addState('Running')
function Running:enteredState()
  self.y = 0
  if self.rebound then self:gotoState('InAir', Player.JUMP_SPEED) end
end
function Running:jumpPressed()
  Player.jumpPressed(self)
  self:gotoState('InAir', Player.JUMP_SPEED)
end

local InAir = Player:addState('InAir')
function InAir:enteredState(velocity)
  self.y = 0
  self.velocity = velocity or 0
  self.rebound = false
  self.airtime = 0
end

function InAir:jumpPressed()
  Player.jumpPressed(self)

  -- If we are on the downward trajectory and the player presses jump a little
  -- bit early, we should set a flag to automatically rebound when we hit the ground.
  if self.velocity > 0 and self.y > -Player.JUMP_BUFFER then
    self.rebound = true
  end
end

function InAir:update(dt)
  Player.update(self, dt)
  self.airtime = self.airtime + dt

  -- If the jump button has been released, terminate the velocity early.
  if self.isJumpPressed == false and self.airtime > Player.TIME_BEFORE_MIN_SPEED then
    self.velocity = math.max(self.velocity, Player.JUMP_TERMINATION_SPEED)
  end

  -- Do one Newtonian mechanics step.
  self.velocity = self.velocity + Player.GRAVITY * dt
  self.y = self.y + self.velocity * dt

  -- Return to running if we are on the ground.
  if self.y > 0 then self:gotoState('Running') end
end

return Player
