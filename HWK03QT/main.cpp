#include "HWK03QT.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    ColorImage* target;
    ColorImage* real, * img;
    real = HWK03QT::FFT(target, &img);


    QApplication a(argc, argv);
    //Second snd;
    HWK03QT w;
    w.show();
    return a.exec();
}
