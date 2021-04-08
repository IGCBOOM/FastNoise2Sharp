#pragma once
#include "API.h"

#include <FastNoise/FastNoise.h>

#include <unordered_map>

namespace FastNoiseSharp
{
	
	enum class CellularTypes
	{
		Distance = 0,
		LookUp,
		Value
	};

	enum class OperatorSourceLHSTypes
	{
		Add = 0,
		Max,
		MaxSmooth,
		Min,
		MinSmooth,
		Multiply
	};

	enum class OperatorHybridLHSTypes
	{
		Divide = 0,
		Subtract
	};

	enum class DomainWarpTypes
	{
		Gradient = 0
	};

	enum class FractalTypes
	{
		DomainWarpIndependent = 0,
		DomainWarpProgressive,
		FBm,
		PingPong,
		Ridged
	};
	
	class CFastNoiseAPI
	{

		std::unordered_map<int32_t, FastNoise::SmartNode<FastNoise::Generator>> m_generatorsInCLR{};
		
	public:

		static CFastNoiseAPI* GetFastNoiseAPI();

		void AddGenerator(int32_t id, FastNoise::SmartNode<FastNoise::Generator> gen);
		void RemoveGenerator(int32_t id);

		FastNoise::SmartNode<FastNoise::Generator> GetGenerator(int32_t id);
		
	};

	extern "C"
	{

		//Free Function
		FASTNOISESHARP_API void API_FreeNoise(float* noise)
		{
			free(noise);
		}

		//Generator Base Functions
		FASTNOISESHARP_API void API_GenUniformGrid2D(int32_t gen, float* noiseOut, int32_t xStart, int32_t yStart, int32_t xSize, int32_t ySize, float frequency, int32_t seed)
		{
			CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenUniformGrid2D(noiseOut, xStart, yStart, xSize, ySize, frequency, seed);
		}

		FASTNOISESHARP_API void API_GenUniformGrid3D(int32_t gen, float* noiseOut, int32_t xStart, int32_t yStart, int32_t zStart, int32_t xSize, int32_t ySize, int32_t zSize, float frequency, int32_t seed)
		{
			CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenUniformGrid3D(noiseOut, xStart, yStart, zStart, xSize, ySize, zSize, frequency, seed);
		}

		FASTNOISESHARP_API void API_GenUniformGrid4D(int32_t gen, float* noiseOut, int32_t xStart, int32_t yStart, int32_t zStart, int32_t wStart, int32_t xSize, int32_t ySize, int32_t zSize, int32_t wSize, float frequency, int32_t seed)
		{
			CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenUniformGrid4D(noiseOut, xStart, yStart, zStart, wStart, xSize, ySize, zSize, wSize, frequency, seed);
		}

		FASTNOISESHARP_API float API_GenSingle2D(int32_t gen, float x, float y, int32_t seed)
		{
			return CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenSingle2D(x, y, seed);
		}

		FASTNOISESHARP_API float API_GenSingle3D(int32_t gen, float x, float y, float z, int32_t seed)
		{
			return CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenSingle3D(x, y, z, seed);
		}

		FASTNOISESHARP_API float API_GenSingle4D(int32_t gen, float x, float y, float z, float w, int32_t seed)
		{
			return CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenSingle4D(x, y, z, w, seed);
		}

		FASTNOISESHARP_API void API_GenTileable2D(int32_t gen, float* noiseOut, int32_t xSize, int32_t ySize, float frequency, int32_t seed)
		{
			CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen)->GenTileable2D(noiseOut, xSize, ySize, frequency, seed);
		}

		//Type Creation Functions
		FASTNOISESHARP_API int32_t API_CreateFromEncodedNodeTree(const char* node_tree)
		{
			
			auto fn = FastNoise::NewFromEncodedNodeTree(node_tree);

			auto id = rand();
			
			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;
			
		}
		
		FASTNOISESHARP_API int32_t API_CreateValue()
		{

			auto fn = FastNoise::New<FastNoise::Value>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}


		FASTNOISESHARP_API void API_CellularSetDistanceFunction(int32_t gen, int type, int dist_func)
		{
			
			auto cell_type = static_cast<CellularTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (cell_type)
			{
			case CellularTypes::Distance:
				dynamic_cast<FastNoise::CellularDistance*>(generator.get())->SetDistanceFunction(static_cast<FastNoise::DistanceFunction>(dist_func));
				break;
			case CellularTypes::LookUp:
				dynamic_cast<FastNoise::CellularLookup*>(generator.get())->SetDistanceFunction(static_cast<FastNoise::DistanceFunction>(dist_func));
				break;
			case CellularTypes::Value:
				dynamic_cast<FastNoise::CellularValue*>(generator.get())->SetDistanceFunction(static_cast<FastNoise::DistanceFunction>(dist_func));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_CellularSetJitterModifier(int32_t gen, int type, float value)
		{

			auto cell_type = static_cast<CellularTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (cell_type)
			{
			case CellularTypes::Distance:
				dynamic_cast<FastNoise::CellularDistance*>(generator.get())->SetJitterModifier(value);
				break;
			case CellularTypes::LookUp:
				dynamic_cast<FastNoise::CellularLookup*>(generator.get())->SetJitterModifier(value);
				break;
			case CellularTypes::Value:
				dynamic_cast<FastNoise::CellularValue*>(generator.get())->SetJitterModifier(value);
				break;
			}
			
		}

		FASTNOISESHARP_API void API_CellularSetJitterModifierGen(int32_t gen, int type, int32_t input_gen)
		{

			auto cell_type = static_cast<CellularTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (cell_type)
			{
			case CellularTypes::Distance:
				dynamic_cast<FastNoise::CellularDistance*>(generator.get())->SetJitterModifier(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(input_gen));
				break;
			case CellularTypes::LookUp:
				dynamic_cast<FastNoise::CellularLookup*>(generator.get())->SetJitterModifier(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(input_gen));
				break;
			case CellularTypes::Value:
				dynamic_cast<FastNoise::CellularValue*>(generator.get())->SetJitterModifier(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(input_gen));
				break;
			}

		}

		FASTNOISESHARP_API int32_t API_CreateCellularDistance()
		{

			auto fn = FastNoise::New<FastNoise::CellularDistance>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;
			
		}

		FASTNOISESHARP_API void API_CellularDistanceSetDistanceIndex0(int32_t gen, int value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::CellularDistance*>(generator.get())->SetDistanceIndex0(value);
		}

		FASTNOISESHARP_API void API_CellularDistanceSetDistanceIndex1(int32_t gen, int value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::CellularDistance*>(generator.get())->SetDistanceIndex1(value);
		}

		FASTNOISESHARP_API void API_CellularDistanceSetReturnType(int32_t gen, int return_type)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::CellularDistance*>(generator.get())->SetReturnType(static_cast<FastNoise::CellularDistance::ReturnType>(return_type));
		}

		FASTNOISESHARP_API int32_t API_CreateCellularLookup()
		{

			auto fn = FastNoise::New<FastNoise::CellularLookup>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_CellularLookupSetLookup(int32_t gen, int32_t lookup_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::CellularLookup*>(generator.get())->SetLookup(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lookup_gen));
		}

		FASTNOISESHARP_API void API_CellularLookupSetLookupFrequency(int32_t gen, float freq)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::CellularLookup*>(generator.get())->SetLookupFrequency(freq);
		}

		FASTNOISESHARP_API int32_t API_CreateCellularValue()
		{

			auto fn = FastNoise::New<FastNoise::CellularValue>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);
			
			return id;

		}

		FASTNOISESHARP_API void API_CellularValueSetValueIndex(int32_t gen, int value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::CellularValue*>(generator.get())->SetValueIndex(value);
		}

		FASTNOISESHARP_API int32_t API_CreateOpenSimplex2()
		{

			auto fn = FastNoise::New<FastNoise::OpenSimplex2>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);
			
			return id;

		}

		FASTNOISESHARP_API int32_t API_CreatePerlin()
		{

			auto fn = FastNoise::New<FastNoise::Perlin>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateSimplex()
		{

			auto fn = FastNoise::New<FastNoise::Simplex>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateCheckerboard()
		{

			auto fn = FastNoise::New<FastNoise::Checkerboard>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_CheckerboardSetSize(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Checkerboard*>(generator.get())->SetSize(value);
		}

		FASTNOISESHARP_API int32_t API_CreateConstant()
		{

			auto fn = FastNoise::New<FastNoise::Constant>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_ConstantSetValue(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Constant*>(generator.get())->SetValue(value);
		}

		FASTNOISESHARP_API int32_t API_CreateDistanceToPoint()
		{

			auto fn = FastNoise::New<FastNoise::DistanceToPoint>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_DistanceToPointSetDistanceFunction(int32_t gen, int value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DistanceToPoint*>(generator.get())->SetDistanceFunction(static_cast<FastNoise::DistanceFunction>(value));
		}

		FASTNOISESHARP_API void API_DistanceToPointSetScale(int32_t gen, int dim, float value)
		{

			auto dimension = static_cast<FastNoise::Dim>(dim);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (dimension)
			{
			case FastNoise::Dim::X:
				dynamic_cast<FastNoise::DistanceToPoint*>(generator.get())->SetScale<FastNoise::Dim::X>(value);
				break;
			case FastNoise::Dim::Y: 
				dynamic_cast<FastNoise::DistanceToPoint*>(generator.get())->SetScale<FastNoise::Dim::Y>(value);
				break;
			case FastNoise::Dim::Z: 
				dynamic_cast<FastNoise::DistanceToPoint*>(generator.get())->SetScale<FastNoise::Dim::Z>(value);
				break;
			case FastNoise::Dim::W: 
				dynamic_cast<FastNoise::DistanceToPoint*>(generator.get())->SetScale<FastNoise::Dim::W>(value);
				break;
			}
			
		}

		FASTNOISESHARP_API void API_DistanceToPointSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DistanceToPoint*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API int32_t API_CreatePositionOutput()
		{

			auto fn = FastNoise::New<FastNoise::PositionOutput>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_PositionOutputSet(int32_t gen, int dim, float multiplier, float offset = 0.0f)
		{

			auto dimension = static_cast<FastNoise::Dim>(dim);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (dimension)
			{
			case FastNoise::Dim::X:
				dynamic_cast<FastNoise::PositionOutput*>(generator.get())->Set<FastNoise::Dim::X>(multiplier, offset);
				break;
			case FastNoise::Dim::Y:
				dynamic_cast<FastNoise::PositionOutput*>(generator.get())->Set<FastNoise::Dim::Y>(multiplier, offset);
				break;
			case FastNoise::Dim::Z:
				dynamic_cast<FastNoise::PositionOutput*>(generator.get())->Set<FastNoise::Dim::Z>(multiplier, offset);
				break;
			case FastNoise::Dim::W:
				dynamic_cast<FastNoise::PositionOutput*>(generator.get())->Set<FastNoise::Dim::W>(multiplier, offset);
				break;
			}

		}

		FASTNOISESHARP_API int32_t API_CreateSineWave()
		{

			auto fn = FastNoise::New<FastNoise::SineWave>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);
			
			return id;
			
		}

		FASTNOISESHARP_API void API_SineWaveSetScale(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::SineWave*>(generator.get())->SetScale(value);
		}

		FASTNOISESHARP_API int32_t API_CreateWhite()
		{

			auto fn = FastNoise::New<FastNoise::White>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		
		//OperatorSourceLHS base class.
		FASTNOISESHARP_API void API_OperatorSourceLHSSetLHS(int32_t gen, int type, int32_t lhs_gen)
		{

			auto gen_type = static_cast<OperatorSourceLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorSourceLHSTypes::Add:
				dynamic_cast<FastNoise::Add*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			case OperatorSourceLHSTypes::Max:
				dynamic_cast<FastNoise::Max*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			case OperatorSourceLHSTypes::MaxSmooth:
				dynamic_cast<FastNoise::MaxSmooth*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			case OperatorSourceLHSTypes::Min:
				dynamic_cast<FastNoise::Min*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			case OperatorSourceLHSTypes::MinSmooth:
				dynamic_cast<FastNoise::MinSmooth*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			case OperatorSourceLHSTypes::Multiply:
				dynamic_cast<FastNoise::Multiply*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_OperatorSourceLHSSetRHSGen(int32_t gen, int type, int32_t rhs_gen)
		{

			auto gen_type = static_cast<OperatorSourceLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorSourceLHSTypes::Add:
				dynamic_cast<FastNoise::Add*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			case OperatorSourceLHSTypes::Max:
				dynamic_cast<FastNoise::Max*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			case OperatorSourceLHSTypes::MaxSmooth:
				dynamic_cast<FastNoise::MaxSmooth*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			case OperatorSourceLHSTypes::Min:
				dynamic_cast<FastNoise::Min*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			case OperatorSourceLHSTypes::MinSmooth:
				dynamic_cast<FastNoise::MinSmooth*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			case OperatorSourceLHSTypes::Multiply:
				dynamic_cast<FastNoise::Multiply*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_OperatorSourceLHSSetRHSFloat(int32_t gen, int type, float value)
		{

			auto gen_type = static_cast<OperatorSourceLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorSourceLHSTypes::Add:
				dynamic_cast<FastNoise::Add*>(generator.get())->SetRHS(value);
				break;
			case OperatorSourceLHSTypes::Max:
				dynamic_cast<FastNoise::Max*>(generator.get())->SetRHS(value);
				break;
			case OperatorSourceLHSTypes::MaxSmooth:
				dynamic_cast<FastNoise::MaxSmooth*>(generator.get())->SetRHS(value);
				break;
			case OperatorSourceLHSTypes::Min:
				dynamic_cast<FastNoise::Min*>(generator.get())->SetRHS(value);
				break;
			case OperatorSourceLHSTypes::MinSmooth:
				dynamic_cast<FastNoise::MinSmooth*>(generator.get())->SetRHS(value);
				break;
			case OperatorSourceLHSTypes::Multiply:
				dynamic_cast<FastNoise::Multiply*>(generator.get())->SetRHS(value);
				break;
			}
			
		}

		FASTNOISESHARP_API int32_t API_CreateAdd()
		{

			auto fn = FastNoise::New<FastNoise::Add>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateMax()
		{

			auto fn = FastNoise::New<FastNoise::Max>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateMaxSmooth()
		{

			auto fn = FastNoise::New<FastNoise::MaxSmooth>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_MaxSmoothSetSmoothnessGen(int32_t gen, int32_t smooth_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::MaxSmooth*>(generator.get())->SetSmoothness(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(smooth_gen));
		}

		FASTNOISESHARP_API void API_MaxSmoothSetSmoothnessFloat(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::MaxSmooth*>(generator.get())->SetSmoothness(value);
		}

		FASTNOISESHARP_API int32_t API_CreateMin()
		{

			auto fn = FastNoise::New<FastNoise::Min>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateMinSmooth()
		{

			auto fn = FastNoise::New<FastNoise::MinSmooth>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_MinSmoothSetSmoothnessGen(int32_t gen, int32_t smooth_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::MinSmooth*>(generator.get())->SetSmoothness(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(smooth_gen));
		}

		FASTNOISESHARP_API void API_MinSmoothSetSmoothnessFloat(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::MinSmooth*>(generator.get())->SetSmoothness(value);
		}

		FASTNOISESHARP_API int32_t API_CreateMultiply()
		{

			auto fn = FastNoise::New<FastNoise::Multiply>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		//OperatorHybridLHS base class.
		FASTNOISESHARP_API void API_OperatorHybridLHSSetLHSGen(int32_t gen, int type, int32_t lhs_gen)
		{

			auto gen_type = static_cast<OperatorHybridLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorHybridLHSTypes::Divide:
				dynamic_cast<FastNoise::Divide*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			case OperatorHybridLHSTypes::Subtract:
				dynamic_cast<FastNoise::Subtract*>(generator.get())->SetLHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(lhs_gen));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_OperatorHybridLHSSetLHSFloat(int32_t gen, int type, float value)
		{

			auto gen_type = static_cast<OperatorHybridLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorHybridLHSTypes::Divide:
				dynamic_cast<FastNoise::Divide*>(generator.get())->SetLHS(value);
				break;
			case OperatorHybridLHSTypes::Subtract:
				dynamic_cast<FastNoise::Subtract*>(generator.get())->SetLHS(value);
				break;
			}
			
		}

		FASTNOISESHARP_API void API_OperatorHybridLHSSetRHSGen(int32_t gen, int type, int32_t rhs_gen)
		{

			auto gen_type = static_cast<OperatorHybridLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorHybridLHSTypes::Divide:
				dynamic_cast<FastNoise::Divide*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			case OperatorHybridLHSTypes::Subtract:
				dynamic_cast<FastNoise::Subtract*>(generator.get())->SetRHS(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(rhs_gen));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_OperatorHybridLHSSetRHSFloat(int32_t gen, int type, float value)
		{

			auto gen_type = static_cast<OperatorHybridLHSTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (gen_type)
			{
			case OperatorHybridLHSTypes::Divide:
				dynamic_cast<FastNoise::Divide*>(generator.get())->SetRHS(value);
				break;
			case OperatorHybridLHSTypes::Subtract:
				dynamic_cast<FastNoise::Subtract*>(generator.get())->SetRHS(value);
				break;
			}
			
		}
		
		FASTNOISESHARP_API int32_t API_CreateDivide()
		{

			auto fn = FastNoise::New<FastNoise::Divide>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);
			
			return id;
			
		}

		FASTNOISESHARP_API int32_t API_CreateSubtract()
		{

			auto fn = FastNoise::New<FastNoise::Subtract>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateFade()
		{

			auto fn = FastNoise::New<FastNoise::Fade>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_FadeSetA(int32_t gen, int32_t a_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Fade*>(generator.get())->SetA(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(a_gen));
		}

		FASTNOISESHARP_API void API_FadeSetB(int32_t gen, int32_t b_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Fade*>(generator.get())->SetB(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(b_gen));
		}

		FASTNOISESHARP_API void API_FadeSetFadeGen(int32_t gen, int32_t fade_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Fade*>(generator.get())->SetFade(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(fade_gen));
		}

		FASTNOISESHARP_API void API_FadeSetFadeFloat(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Fade*>(generator.get())->SetFade(value);
		}

		FASTNOISESHARP_API int32_t API_CreatePowFloat()
		{

			auto fn = FastNoise::New<FastNoise::PowFloat>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_PowFloatSetValueGen(int32_t gen, int32_t value_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::PowFloat*>(generator.get())->SetValue(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(value_gen));
		}
		
		FASTNOISESHARP_API void API_PowFloatSetValueFloat(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::PowFloat*>(generator.get())->SetValue(value);
		}

		FASTNOISESHARP_API void API_PowFloatSetPowGen(int32_t gen, int32_t value_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::PowFloat*>(generator.get())->SetPow(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(value_gen));
		}

		FASTNOISESHARP_API void API_PowFloatSetPowFloat(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::PowFloat*>(generator.get())->SetPow(value);
		}

		FASTNOISESHARP_API int32_t API_CreatePowInt()
		{

			auto fn = FastNoise::New<FastNoise::PowInt>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_PowIntSetValue(int32_t gen, int32_t value_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::PowInt*>(generator.get())->SetValue(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(value_gen));
		}

		FASTNOISESHARP_API void API_PowIntSetPow(int32_t gen, int value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::PowInt*>(generator.get())->SetPow(value);
		}

		//Domain Warp class functions.
		FASTNOISESHARP_API void API_DomainWarpSetSource(int32_t gen, int type, int32_t source_gen)
		{
			
			auto warp_type = static_cast<DomainWarpTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case DomainWarpTypes::Gradient:
				dynamic_cast<FastNoise::DomainWarpGradient*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_DomainWarpSetWarpAmplitudeGen(int32_t gen, int type, int32_t wamp_gen)
		{

			auto warp_type = static_cast<DomainWarpTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case DomainWarpTypes::Gradient:
				dynamic_cast<FastNoise::DomainWarpGradient*>(generator.get())->SetWarpAmplitude(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(wamp_gen));
				break;
			}
			
		}

		FASTNOISESHARP_API void API_DomainWarpSetWarpAmplitudeFloat(int32_t gen, int type, float value)
		{

			auto warp_type = static_cast<DomainWarpTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case DomainWarpTypes::Gradient:
				dynamic_cast<FastNoise::DomainWarpGradient*>(generator.get())->SetWarpAmplitude(value);
				break;
			}
			
		}

		FASTNOISESHARP_API void API_DomainWarpSetWarpFrequency(int32_t gen, int type, float value)
		{

			auto warp_type = static_cast<DomainWarpTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case DomainWarpTypes::Gradient:
				dynamic_cast<FastNoise::DomainWarpGradient*>(generator.get())->SetWarpFrequency(value);
				break;
			}
			
		}

		FASTNOISESHARP_API int32_t API_CreateDomainWarpGradient()
		{

			auto fn = FastNoise::New<FastNoise::DomainWarpGradient>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		//Fractal functions
		FASTNOISESHARP_API void API_FractalSetSource(int32_t gen, int type, int32_t source_gen)
		{

			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				{
					auto d_warp_base = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen);
					auto d_warp = FastNoise::SmartNode<FastNoise::DomainWarp>(d_warp_base, dynamic_cast<FastNoise::DomainWarp*>(d_warp_base.get()));
					dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetSource(d_warp);
				}
				break;
			case FractalTypes::DomainWarpProgressive:
				{
					auto d_warp_base = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen);
					auto d_warp = FastNoise::SmartNode<FastNoise::DomainWarp>(d_warp_base, dynamic_cast<FastNoise::DomainWarp*>(d_warp_base.get()));
					dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetSource(d_warp);
				}
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
				break;
			}

		}
		
		FASTNOISESHARP_API void API_FractalSetGainGen(int32_t gen, int type, int32_t gain_gen)
		{

			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetGain(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gain_gen));
				break;
			case FractalTypes::DomainWarpProgressive:
				dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetGain(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gain_gen));
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetGain(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gain_gen));
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetGain(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gain_gen));
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetGain(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gain_gen));
				break;
			}

		}
		
		FASTNOISESHARP_API void API_FractalSetGainFloat(int32_t gen, int type, float value)
		{
			
			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetGain(value);
				break;
			case FractalTypes::DomainWarpProgressive:
				dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetGain(value);
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetGain(value);
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetGain(value);
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetGain(value);
				break;
			}

		}

		FASTNOISESHARP_API void API_FractalSetWeightedStrengthGen(int32_t gen, int type, int32_t strength_gen)
		{

			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetWeightedStrength(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(strength_gen));
				break;
			case FractalTypes::DomainWarpProgressive:
				dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetWeightedStrength(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(strength_gen));
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetWeightedStrength(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(strength_gen));
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetWeightedStrength(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(strength_gen));
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetWeightedStrength(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(strength_gen));
				break;
			}

		}

		FASTNOISESHARP_API void API_FractalSetWeightedStrengthFloat(int32_t gen, int type, float value)
		{

			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetWeightedStrength(value);
				break;
			case FractalTypes::DomainWarpProgressive:
				dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetWeightedStrength(value);
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetWeightedStrength(value);
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetWeightedStrength(value);
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetWeightedStrength(value);
				break;
			}

		}

		FASTNOISESHARP_API void API_FractalSetOctaveCount(int32_t gen, int type, int value)
		{

			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetOctaveCount(value);
				break;
			case FractalTypes::DomainWarpProgressive:
				dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetOctaveCount(value);
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetOctaveCount(value);
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetOctaveCount(value);
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetOctaveCount(value);
				break;
			}

		}

		FASTNOISESHARP_API void API_FractalSetLacunarity(int32_t gen, int type, float value)
		{

			auto warp_type = static_cast<FractalTypes>(type);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (warp_type)
			{
			case FractalTypes::DomainWarpIndependent:
				dynamic_cast<FastNoise::DomainWarpFractalIndependant*>(generator.get())->SetLacunarity(value);
				break;
			case FractalTypes::DomainWarpProgressive:
				dynamic_cast<FastNoise::DomainWarpFractalProgressive*>(generator.get())->SetLacunarity(value);
				break;
			case FractalTypes::FBm:
				dynamic_cast<FastNoise::FractalFBm*>(generator.get())->SetLacunarity(value);
				break;
			case FractalTypes::PingPong:
				dynamic_cast<FastNoise::FractalPingPong*>(generator.get())->SetLacunarity(value);
				break;
			case FractalTypes::Ridged:
				dynamic_cast<FastNoise::FractalRidged*>(generator.get())->SetLacunarity(value);
				break;
			}

		}

		FASTNOISESHARP_API int32_t API_CreateDomainWarpFractalIndependent()
		{

			auto fn = FastNoise::New<FastNoise::DomainWarpFractalIndependant>();
			
			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateDomainWarpFractalProgressive()
		{

			auto fn = FastNoise::New<FastNoise::DomainWarpFractalProgressive>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateFractalFBm()
		{

			auto fn = FastNoise::New<FastNoise::FractalFBm>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateFractalPingPong()
		{

			auto fn = FastNoise::New<FastNoise::FractalPingPong>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);
			
			return id;
			
		}

		FASTNOISESHARP_API int32_t API_CreateFractalRidged()
		{

			auto fn = FastNoise::New<FastNoise::FractalRidged>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API int32_t API_CreateAddDimension()
		{

			auto fn = FastNoise::New<FastNoise::AddDimension>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_AddDimensionSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::AddDimension*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_AddDimensionSetNewDimensionPositionGen(int32_t gen, int32_t dpos_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::AddDimension*>(generator.get())->SetNewDimensionPosition(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(dpos_gen));
		}

		FASTNOISESHARP_API void API_AddDimensionSetNewDimensionPositionFloat(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::AddDimension*>(generator.get())->SetNewDimensionPosition(value);
		}

		FASTNOISESHARP_API int32_t API_CreateConvertRGBA8()
		{

			auto fn = FastNoise::New<FastNoise::ConvertRGBA8>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_ConvertRGBA8SetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::ConvertRGBA8*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_ConvertRGBA8SetMinMax(int32_t gen, float min, float max)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::ConvertRGBA8*>(generator.get())->SetMinMax(min, max);
		}

		FASTNOISESHARP_API int32_t API_CreateDomainAxisScale()
		{

			auto fn = FastNoise::New<FastNoise::DomainAxisScale>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_DomainAxisScaleSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainAxisScale*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_DomainAxisScaleSetScale(int32_t gen, int dim, float value)
		{

			auto dimension = static_cast<FastNoise::Dim>(dim);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (dimension)
			{
			case FastNoise::Dim::X:
				dynamic_cast<FastNoise::DomainAxisScale*>(generator.get())->SetScale<FastNoise::Dim::X>(value);
				break;
			case FastNoise::Dim::Y:
				dynamic_cast<FastNoise::DomainAxisScale*>(generator.get())->SetScale<FastNoise::Dim::Y>(value);
				break;
			case FastNoise::Dim::Z:
				dynamic_cast<FastNoise::DomainAxisScale*>(generator.get())->SetScale<FastNoise::Dim::Z>(value);
				break;
			case FastNoise::Dim::W:
				dynamic_cast<FastNoise::DomainAxisScale*>(generator.get())->SetScale<FastNoise::Dim::W>(value);
				break;
			}

		}

		FASTNOISESHARP_API int32_t API_CreateDomainOffset()
		{

			auto fn = FastNoise::New<FastNoise::DomainOffset>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_DomainOffsetSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_DomainOffsetSetOffsetGen(int32_t gen, int dim, int32_t offset_gen)
		{

			auto dimension = static_cast<FastNoise::Dim>(dim);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (dimension)
			{
			case FastNoise::Dim::X:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::X>(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(offset_gen));
				break;
			case FastNoise::Dim::Y:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::Y>(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(offset_gen));
				break;
			case FastNoise::Dim::Z:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::Z>(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(offset_gen));
				break;
			case FastNoise::Dim::W:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::W>(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(offset_gen));
				break;
			}

		}

		FASTNOISESHARP_API void API_DomainOffsetSetOffsetFloat(int32_t gen, int dim, float value)
		{

			auto dimension = static_cast<FastNoise::Dim>(dim);

			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);

			switch (dimension)
			{
			case FastNoise::Dim::X:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::X>(value);
				break;
			case FastNoise::Dim::Y:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::Y>(value);
				break;
			case FastNoise::Dim::Z:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::Z>(value);
				break;
			case FastNoise::Dim::W:
				dynamic_cast<FastNoise::DomainOffset*>(generator.get())->SetOffset<FastNoise::Dim::W>(value);
				break;
			}

		}

		FASTNOISESHARP_API int32_t API_CreateRemap()
		{

			auto fn = FastNoise::New<FastNoise::Remap>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_RemapSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Remap*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_RemapSetRemap(int32_t gen, float from_min, float from_max, float to_min, float to_max)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Remap*>(generator.get())->SetRemap(from_min, from_max, to_min, to_max);
		}

		FASTNOISESHARP_API int32_t API_CreateGeneratorCache()
		{

			auto fn = FastNoise::New<FastNoise::GeneratorCache>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_GeneratorCacheSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Remap*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API int32_t API_CreateDomainScale()
		{

			auto fn = FastNoise::New<FastNoise::DomainScale>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_DomainScaleSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainScale*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_DomainScaleSetScale(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainScale*>(generator.get())->SetScale(value);
		}

		FASTNOISESHARP_API int32_t API_CreateDomainRotate()
		{

			auto fn = FastNoise::New<FastNoise::DomainRotate>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_DomainRotateSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainRotate*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_DomainRotateSetYaw(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainRotate*>(generator.get())->SetYaw(value);
		}

		FASTNOISESHARP_API void API_DomainRotateSetPitch(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainRotate*>(generator.get())->SetPitch(value);
		}

		FASTNOISESHARP_API void API_DomainRotateSetRoll(int32_t gen, float value)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::DomainRotate*>(generator.get())->SetRoll(value);
		}

		FASTNOISESHARP_API int32_t API_CreateRemoveDimension()
		{

			auto fn = FastNoise::New<FastNoise::RemoveDimension>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_RemoveDimensionSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::RemoveDimension*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_RemoveDimensionSetRemoveDimension(int32_t gen, int dim)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::RemoveDimension*>(generator.get())->SetRemoveDimension(static_cast<FastNoise::Dim>(dim));
		}

		FASTNOISESHARP_API int32_t API_CreateSeedOffset()
		{

			auto fn = FastNoise::New<FastNoise::SeedOffset>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_SeedOffsetSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::SeedOffset*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_SeedOffsetSetOffset(int32_t gen, int offset)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::SeedOffset*>(generator.get())->SetOffset(offset);
		}

		FASTNOISESHARP_API int32_t API_CreateTerrace()
		{

			auto fn = FastNoise::New<FastNoise::Terrace>();

			auto id = rand();

			CFastNoiseAPI::GetFastNoiseAPI()->AddGenerator(id, fn);

			return id;

		}

		FASTNOISESHARP_API void API_TerraceSetSource(int32_t gen, int32_t source_gen)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Terrace*>(generator.get())->SetSource(CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(source_gen));
		}

		FASTNOISESHARP_API void API_TerraceSetMultiplier(int32_t gen, float multiplier)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Terrace*>(generator.get())->SetMultiplier(multiplier);
		}

		FASTNOISESHARP_API void API_TerraceSetSmoothness(int32_t gen, float smoothness)
		{
			auto generator = CFastNoiseAPI::GetFastNoiseAPI()->GetGenerator(gen);
			dynamic_cast<FastNoise::Terrace*>(generator.get())->SetSmoothness(smoothness);
		}
		
		//Remove Gen
		FASTNOISESHARP_API void API_RemoveGenerator(int32_t id)
		{
			CFastNoiseAPI::GetFastNoiseAPI()->RemoveGenerator(id);
		}
		
	}

}
