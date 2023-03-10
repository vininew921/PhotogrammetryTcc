﻿#version 330 core

layout(location = 0) in vec3 aPosition;

out vec4 vertexColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main(void)
{
	gl_Position = vec4(aPosition, 1.0) * model * view * projection;
	vertexColor = vec4(1.0, 0.0, 1.0, 1.0);
}