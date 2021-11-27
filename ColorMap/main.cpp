#include "ColorMap.h"
#include <QtWidgets/QApplication>
// properties-- > General-- > C++ Language Standard
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    ColorMap w;
    w.show();
    return a.exec();
}
