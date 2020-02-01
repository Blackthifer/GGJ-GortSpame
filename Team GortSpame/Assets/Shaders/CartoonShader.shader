Shader "Custom/CartoonShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineSize ("Outline Size", Range(0, 0.1)) = 0.01
		_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
		_ColorDepth ("Color Compression Bits", int) = 3
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#define UNITY_SHADER_NO_UPGRADE 1

			struct vertexdata
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			float _OutlineSize;
			float4 _OutlineColor;
			float _ColorDepth;

			v2f vert (vertexdata v)
			{
				v2f o;
				float4 normalized = normalize(v.normal);
				float4 reference = mul(UNITY_MATRIX_MVP, v.vertex);
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex + v.normal * _OutlineSize);
				o.vertex.z = reference.z - 0.005;
				return o;
			}

			float4 frag (v2f i) : SV_Target
			{
				float compressionFactor = pow(2, _ColorDepth) - 1;
				float4 color = floor(_OutlineColor * compressionFactor) / compressionFactor;
				return color;
			}

			ENDCG
		}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct vertexdata
			{
				float4 vertex : POSITION;
				float2 UV : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 UV : TEXCOORD0;
			};

			sampler2D _MainTex;
			float _ColorDepth;

			v2f vert (vertexdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.UV = v.UV;
				return o;
			}

			float4 frag (v2f i) : SV_Target
			{
				float4 color = tex2D(_MainTex, i.UV);
				float compressionFactor = pow(2, _ColorDepth) - 1;
				color = floor(color * compressionFactor) / compressionFactor;
				return color;
			}

			ENDCG
		}
	}

}