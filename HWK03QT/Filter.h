#pragma once
#include  "ColorImage.h"	



class Filter
{
public:
	ColorImage* operator*(ColorImage* operand);
};

ColorImage* operator+(Filter* ftr, ColorImage img);

