namespace Engine;

public class Shader
{
    public static Shader DefaultShader => new Shader("Shaders/defaultShader.vert", "Shaders/defaultShader.frag");

    public readonly int Handle;

    private readonly Dictionary<string, int> _uniformLocations;

    public Shader(string vertPath, string fragPath)
    {
        //Create vertex shader
        string? vertexShaderSource = File.ReadAllText(vertPath);
        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSource);
        CompileShader(vertexShader);

        //Create fragment shader
        string fragmentShaderSource = File.ReadAllText(fragPath);
        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSource);
        CompileShader(fragmentShader);

        //Create program and attach shaders together
        Handle = GL.CreateProgram();

        GL.AttachShader(Handle, vertexShader);
        GL.AttachShader(Handle, fragmentShader);

        LinkProgram(Handle);

        GL.DetachShader(Handle, vertexShader);
        GL.DetachShader(Handle, fragmentShader);
        GL.DeleteShader(fragmentShader);
        GL.DeleteShader(vertexShader);

        GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out int numberOfUniforms);

        _uniformLocations = new Dictionary<string, int>();

        for (int i = 0; i < numberOfUniforms; i++)
        {
            string? key = GL.GetActiveUniform(Handle, i, out _, out _);
            int location = GL.GetUniformLocation(Handle, key);

            _uniformLocations.Add(key, location);
        }
    }

    private static void CompileShader(int shader)
    {
        GL.CompileShader(shader);
        GL.GetShader(shader, ShaderParameter.CompileStatus, out int code);

        if (code != (int)All.True)
        {
            string? infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
        }
    }

    private static void LinkProgram(int program)
    {
        GL.LinkProgram(program);
        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int code);

        if (code != (int)All.True)
        {
            throw new Exception($"Error occurred whilst linking Program({program})");
        }
    }

    public void Use() => GL.UseProgram(Handle);

    public int GetAttribLocation(string attribName) => GL.GetAttribLocation(Handle, attribName);

    public void SetInt(string name, int data)
    {
        Use();
        GL.Uniform1(_uniformLocations[name], data);
    }

    public void SetFloat(string name, float data)
    {
        Use();
        GL.Uniform1(_uniformLocations[name], data);
    }

    public void SetMatrix4(string name, Matrix4 data)
    {
        Use();
        GL.UniformMatrix4(_uniformLocations[name], true, ref data);
    }

    public void SetVec3(string name, Vec3 data)
    {
        Use();
        GL.Uniform3(_uniformLocations[name], data);
    }
}
