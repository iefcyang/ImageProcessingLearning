#ifndef COLORIMAGE_H
#define COLORIMAGE_H
#include <QImage>
#include <monoimage.h>


class ColorImage
{
public:
    ColorImage(QImage* imgptr);
    ColorImage(int*** pixels, int rows, int cols);
    static MonoImage* GetGreyAverage(ColorImage* cimg);
    static MonoImage* GetGrey2(ColorImage* cimg);
    static ColorImage* GetBrightnessChangedImage(ColorImage* cimg, int DeltaBrightness);
    static ColorImage* GetContrastChangedImage(ColorImage* cimg, int DeltaContrast);
    static ColorImage* Subtract2MonoImage(MonoImage* img1, MonoImage* img2);
    static ColorImage* HistoEqualize(ColorImage* cimg);
    int cols, rows;
    int*** pixels;
    QImage* theBitmap;

};

#endif // IMAGE_H
