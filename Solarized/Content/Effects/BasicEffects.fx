
sampler TextureSampler : register(s0);

float4 BaseColor;
float FadeStart = 0.0; 
float FadeEnd = 1.0;
float2 GaussianBlurTex;
float GaussianBlurRad = 2.0;

struct FadeOutEffectOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TexCoord : TEXCOORD0;
};
struct GaussianBlurEfectOutput
{
    float2 TexCoord : TEXCOORD0;
};

float4 FadeOutEffect(FadeOutEffectOutput vertex) : COLOR
{
    float4 texColor = tex2D(TextureSampler, vertex.TexCoord) * BaseColor;
    
    float t = saturate((FadeEnd - vertex.TexCoord.x) / (FadeEnd - FadeStart));
    texColor.a *= t;
    return texColor;
}
float4 GaussianBlurEfect(GaussianBlurEfectOutput vertex) : COLOR
{
    float4 color = float4(0, 0, 0, 0);
    float weights[5] = { 0.204164, 0.304005, 0.193783, 0.072155, 0.016000 };
    int offsets[5] = { 0, 1, 2, 3, 4 };

    for (int i = 0; i < 5; i++)
    {
        float2 offset = float2(offsets[i], 0) * GaussianBlurTex * GaussianBlurRad;
        color += tex2D(TextureSampler, vertex.TexCoord + offset) * weights[i];
        if (i > 0)
            color += tex2D(TextureSampler, vertex.TexCoord - offset) * weights[i];
    }

    return color;
}

technique Gradient
{
    pass FadeOutEffect
    {
        PixelShader = compile ps_4_0_level_9_1 FadeOutEffect();
    }
    pass GaussianBlurEfect
    {
        PixelShader = compile ps_4_0_level_9_1 GaussianBlurEfect();
    }
}
