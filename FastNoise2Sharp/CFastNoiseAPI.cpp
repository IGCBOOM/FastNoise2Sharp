#include "CFastNoiseAPI.h"

#include <memory>

namespace FastNoiseSharp
{
	
	CFastNoiseAPI* CFastNoiseAPI::GetFastNoiseAPI()
	{

		static std::shared_ptr<CFastNoiseAPI> fast_noise_api;

		if (fast_noise_api == nullptr)
		{
			fast_noise_api = std::make_shared<CFastNoiseAPI>();
		}

		return fast_noise_api.get();
		
	}

	void CFastNoiseAPI::AddGenerator(int32_t id, FastNoise::SmartNode<FastNoise::Generator> gen)
	{
		m_generatorsInCLR.try_emplace(id, gen);
	}
	
	void CFastNoiseAPI::RemoveGenerator(int32_t id)
	{
		m_generatorsInCLR.erase(id);
	}

	FastNoise::SmartNode<FastNoise::Generator> CFastNoiseAPI::GetGenerator(int32_t id)
	{
		return m_generatorsInCLR[id];
	}
	
}
