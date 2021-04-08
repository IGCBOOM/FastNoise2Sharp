#pragma once

#ifdef FASTNOISESHARP_EXPORT
#define FASTNOISESHARP_API __declspec(dllexport)
#else
#define FASTNOISESHARP_API __declspec(dllimport)
#endif