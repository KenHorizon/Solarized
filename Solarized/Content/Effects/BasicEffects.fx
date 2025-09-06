
sampler TextureSampler : register(s0);

float4 BaseColor;
float FadeStart = 0.0; 
float FadeEnd = 1.0;

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TexCoord : TEXCOORD0;
};

float4 FadeOutEffect(VertexShaderOutput vertex) : COLOR
{
    float4 texColor = tex2D(TextureSampler, vertex.TexCoord) * BaseColor;
    
    float t = saturate((FadeEnd - vertex.TexCoord.x) / (FadeEnd - FadeStart));
    texColor.a *= t;
    return texColor;
}

technique Gradient
{
    pass FadeOutEffect
    {
        PixelShader = compile ps_4_0_level_9_1 FadeOutEffect();
    }
}
