local Player = class('Player', require("entity"))
Player.static.size = vector(10, 20)
Player.static.JUMP_SPEED = -40
Player.static.GRAVITY = 40

Player:include(Stateful)

function Player:initialize()
  -- The player only has a y-position which corresponds to the bottom-center of
  -- their rectangle. The player's x position is locked at zero.
  self.y = 0

  self:gotoState('Running')
end
function Player:draw()
  love.graphics.setColor(255, 255, 255, 255)
  love.graphics.rectangle('fill', -Player.size.x/2, self.y - Player.size.y, Player.size:unpack())
end

function Player:jump() end

local Running = Player:addState('Running')
function Running:enteredState() self.y = 0 end
function Running:jump() self:gotoState('InAir', Player.JUMP_SPEED) end

local InAir = Player:addState('InAir')
function InAir:enteredState(velocity)
  self.velocity = velocity or 0
end
function InAir:update(dt)
  Player.update(self, dt)

  self.velocity = self.velocity + Player.GRAVITY * dt
  self.y = self.y + self.velocity * dt

  if self.y > 0 then self:gotoState('Running') end
end

return Player
