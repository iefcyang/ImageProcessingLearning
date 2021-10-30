#pragma once
#include  "ColorImage.h"	

ColorImage* operator+(Filter* ftr, ColorImage img)
{
	return nullptr;
}

class Filter
{
public:
	ColorImage* operator*(ColorImage* operand);
};

