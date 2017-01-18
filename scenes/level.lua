local Level = class('Level', require("scene"))

-- This variable controls how much of the track is visible to the viewpoint.
Level.static.BOUNDS = {left = -10, right = 200}


function Level:initialize()
  self.player = require("entities.player")()
end

function Level:draw()
  -- Calculate how to scale the viewport.
  local scale = love.graphics.getWidth() / (Level.BOUNDS.right - Level.BOUNDS.left)

  love.graphics.push()
  love.graphics.translate(0, love.graphics.getHeight() * 0.7)
  love.graphics.scale(scale, scale)
  love.graphics.translate(-Level.BOUNDS.left, 0)


  -- Draw the ground.
  love.graphics.setColor(128, 64, 0, 255)
  love.graphics.rectangle('fill', -1000, 0, 10000, 500)

  love.graphics.setColor(0, 255, 0, 255)
  love.graphics.rectangle('fill', -1000, 0, 10000, 15)

  self.player:draw()
  love.graphics.pop()
end

function Level:update(dt)
  self.player:update(dt)
end

function Level:keypressed(key, scancode, isrepeat)
  if key == "space" then self.player:jump() end
end

function Level:touchpressed(id, x, y, dx, dy, pressure) self.player:jump() end

return Level
