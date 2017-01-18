--[[
Scenes are a way of splitting the game into different "screens". For example,
the menu is one scene, and each level is it's own scene.
]]--

local Scene = class('Scene')
Scene.static.currentScene = nil

function Scene:initialize()
  self.font = love.graphics.newFont(40)
end

function Scene:draw()
  love.graphics.setFont(self.font)
  love.graphics.printf("Default Scene", 0,
    (love.graphics.getHeight() - self.font:getHeight()) / 2,
    love.graphics.getWidth(), "center")
end

function Scene:update(dt) end
function Scene:keypressed(key, scancode, isrepeat) end
function Scene:touchpressed(id, x, y, dx, dy, pressure) end

return Scene
