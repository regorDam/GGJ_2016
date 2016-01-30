// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Standard (Specular setup),iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|normal-4757-RGB,custl-9959-OUT,olwid-9496-OUT,olcol-1700-RGB;n:type:ShaderForge.SFN_Tex2d,id:4084,x:32381,y:33487,ptovrint:True,ptlb:Diffuse Map,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4b0f164d3f41e0f44bc37e4ce9929efc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Fresnel,id:3343,x:32733,y:32733,varname:node_3343,prsc:2|EXP-3098-OUT;n:type:ShaderForge.SFN_Slider,id:2379,x:32366,y:32905,ptovrint:False,ptlb:Fresnel Scale,ptin:_FresnelScale,varname:_FresnelScale,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.410258,max:5;n:type:ShaderForge.SFN_Exp,id:3098,x:32553,y:32733,varname:node_3098,prsc:2,et:1|IN-2379-OUT;n:type:ShaderForge.SFN_Color,id:7221,x:32733,y:32950,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:_FresnelColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:4865,x:32381,y:33278,ptovrint:False,ptlb:User Color,ptin:_UserColor,varname:_UserColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.05226859,c2:0.6323529,c3:0.004649659,c4:1;n:type:ShaderForge.SFN_Tex2d,id:5838,x:32381,y:33055,ptovrint:False,ptlb:Color Map,ptin:_ColorMap,varname:_ColorMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f62f4554a483a464a9dde4f853fc0b49,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ChannelBlend,id:9959,x:32995,y:32945,varname:node_9959,prsc:2,chbt:1|M-3343-OUT,R-7221-RGB,BTM-9062-OUT;n:type:ShaderForge.SFN_Tex2d,id:4757,x:32995,y:32693,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_ChannelBlend,id:9062,x:32781,y:33242,varname:node_9062,prsc:2,chbt:1|M-5838-RGB,R-4865-RGB,G-4865-RGB,B-4865-RGB,BTM-4084-RGB;n:type:ShaderForge.SFN_Slider,id:9496,x:32678,y:33437,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:_OutlineWidth,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.1;n:type:ShaderForge.SFN_Color,id:1700,x:32867,y:33538,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:_OutlineColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;proporder:4084-2379-7221-4865-5838-4757-9496-1700;pass:END;sub:END;*/

Shader "GGJ16/User Color" {
    Properties {
        _MainTex ("Diffuse Map", 2D) = "white" {}
        _FresnelScale ("Fresnel Scale", Range(0, 5)) = 1.410258
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _UserColor ("User Color", Color) = (0.05226859,0.6323529,0.004649659,1)
        _ColorMap ("Color Map", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _OutlineWidth;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*_OutlineWidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _FresnelScale;
            uniform float4 _FresnelColor;
            uniform float4 _UserColor;
            uniform sampler2D _ColorMap; uniform float4 _ColorMap_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
                float node_3343 = pow(1.0-max(0,dot(normalDirection, viewDirection)),exp2(_FresnelScale));
                float4 _ColorMap_var = tex2D(_ColorMap,TRANSFORM_TEX(i.uv0, _ColorMap));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 finalColor = (lerp( (lerp( lerp( lerp( _MainTex_var.rgb, _UserColor.rgb, _ColorMap_var.rgb.r ), _UserColor.rgb, _ColorMap_var.rgb.g ), _UserColor.rgb, _ColorMap_var.rgb.b )), _FresnelColor.rgb, node_3343.r ));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Standard (Specular setup)"
    CustomEditor "ShaderForgeMaterialInspector"
}
