#pragma once
#include  "ColorImage.h"	



class Filter
{
public:
	ColorImage* operator*(ColorImage* operand);
};

// Global
ColorImage* operator+(Filter ftr, ColorImage* img);

