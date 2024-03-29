#ifndef MONOIMAGE_H
#define MONOIMAGE_H
#include <QImage>




class MonoImage
{
    QImage theImage;
public:
    MonoImage(int** pixels, int rows, int cols);
    QImage getImage();
    static MonoImage* threshold(MonoImage* img, int val);
    static MonoImage* LeveledGrey(MonoImage* img, int val);
    static MonoImage* GetResolutionChangedImage(MonoImage* img, int val);
    int rows, cols;
    int** intensities;



};

#endif // MONOIMAGE_H
