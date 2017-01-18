--[[
This file is the main entry point for the game. Hopefully it shouldn't be edited
that frequently, since it should just import a bunch of stuff and then
delegate to the current scene.
]]--

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

-- Load in our Scene class.
Scene = require "scene"
Scene.currentScene = Scene()

function love.draw()
  -- This function is called every frame by LOVE. All drawing of objects should
  -- happen within the context of this function.

  -- Draw the current scene.
  if Scene.currentScene ~= nil then Scene.currentScene:draw() end
end

function love.update(dt)
  -- This function is called every frame by LOVE. It should be used to update entities.
  lurker.update() -- Scan for live code updates.

  -- Update the current scene.
  if Scene.currentScene ~= nil then Scene.currentScene:update(dt) end
end

function love.keypressed(...)
  if Scene.currentScene ~= nil then Scene.currentScene:keypressed(...) end
end
function love.touchpressed(...)
  if Scene.currentScene ~= nil then Scene.currentScene:touchpressed(...) end
end
