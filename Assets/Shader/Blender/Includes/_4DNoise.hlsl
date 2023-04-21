#include <Packages/com.blendernodesgraph.core/Editor/Includes/Importers.hlsl>

void _4DNoise_float(float3 _POS, float3 _PVS, float3 _PWS, float3 _NOS, float3 _NVS, float3 _NWS, float3 _NTS, float3 _TWS, float3 _BTWS, float3 _UV, float3 _SP, float3 _VVS, float3 _VWS, Texture2D gradient_82440, out float4 ColorOut)
{
	
	float _SeparateXYZ_82448_x = separate_x(float4(_NOS, 0));
	float _SeparateXYZ_82448_y = separate_y(float4(_NOS, 0));
	float4 _Mapping_82450 = float4(mapping_point(float4(_NOS, 0), float3(5,488889E+15, 5,488889E+15, 5,488889E+15), float3(0, 0, 0), float3(20, 20, 20)), 0);
	float _MusgraveTexture_82452_fac = texture_musgrave_factor(_Mapping_82450, 0, 50, 3E+16, 20, 20, 0, 10, 2, 3);
	float _Math_82456 = math_add(_SeparateXYZ_82448_y, _MusgraveTexture_82452_fac, 5);
	float _SeparateXYZ_82448_z = separate_z(float4(_NOS, 0));
	float4 _CombineXYZ_82446 = float4(combine_xyz(_SeparateXYZ_82448_x, _Math_82456, _SeparateXYZ_82448_z), 0);
	float4 _Mapping_82442 = float4(mapping_point(_CombineXYZ_82446, float3(0, 4,94E+16, 0), float3(0, 0, 0), float3(10, 10, 10)), 0);
	float _VoronoiTexture_82436_dis; float4 _VoronoiTexture_82436_col; float3 _VoronoiTexture_82436_pos; float _VoronoiTexture_82436_w; float _VoronoiTexture_82436_rad; voronoi_tex_getValue(_Mapping_82442, 0, 120, 6E+15, 5, 10, 0, 2, 0, _VoronoiTexture_82436_dis, _VoronoiTexture_82436_col, _VoronoiTexture_82436_pos, _VoronoiTexture_82436_w, _VoronoiTexture_82436_rad);
	float _VoronoiTexture_82434_dis; float4 _VoronoiTexture_82434_col; float3 _VoronoiTexture_82434_pos; float _VoronoiTexture_82434_w; float _VoronoiTexture_82434_rad; voronoi_tex_getValue(_Mapping_82442, 0, 120, 6E+15, 5, 10, 0, 2, 2, _VoronoiTexture_82434_dis, _VoronoiTexture_82434_col, _VoronoiTexture_82434_pos, _VoronoiTexture_82434_w, _VoronoiTexture_82434_rad);
	float _Math_82438 = math_subtract(_VoronoiTexture_82436_dis, _VoronoiTexture_82434_dis, 5);
	float4 _ColorRamp_82440 = color_ramp(gradient_82440, _Math_82438);
	float4 _Invert_82464 = node_invert(10, _ColorRamp_82440);

	ColorOut = _Invert_82464;
}