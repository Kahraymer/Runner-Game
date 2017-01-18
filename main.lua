 -- An object oriented programming system for Lua.
class = require "external.middleclass"

 -- A vector utilities class.
vector = require "external.vector"

-- Misc. Lua utlities.
lume = require "external.lume"

-- Live code reload.
lurker = require "external.lurker"

-- Stateful classes. This is a pretty cool, but optional paradigm.
-- Check https://github.com/kikito/stateful.lua for info on how to use.
Stateful = require "external.stateful"

-- A collision detection library with a punny name.
HC = require 'external.hardoncollider'

function love.draw()
  -- This function is called every frame by LOVE. All drawing of objects should
  -- happen within the context of this function.
  love.graphics.print("Hello World", 20, 40 + 10*math.sin(love.timer.getTime()))
end

function love.update(dt)
  -- This function is called every frame by LOVE. It should be used to update entities.
  lurker.update() -- Scan for live code updates.
end
