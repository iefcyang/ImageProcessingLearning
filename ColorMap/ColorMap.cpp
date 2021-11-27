#include "ColorMap.h"

#include <QPainter>
#include<QTime>
#include<QMouseEvent>

ColorMap::ColorMap(QWidget *parent)
    : QMainWindow(parent)
{
    ui.setupUi(this);

    //QPainter painter(this);
    //painter.setRenderHint(QPainter::Antialiasing, true);
    //painter.setPen(QPen(QColor("#3cf"), 4));
    //const int distance = 20;
    //int w = width();
    //int h = height();
    //painter.drawRoundedRect(QRect(distance, distance,
    //    width() - 2 * distance, height() - 2 * distance),
    //    10, 10);

    //painter.drawEllipse(20, 20, 300, 200 ); // (QRect(distance, distance,
 }

void ColorMap::paintEvent(QPaintEvent*) 
{
    //QTime time;
    //time.st.start();
    //for (int i = 0; i < ::loop; ++i) {
        //QPainter painter(this);
        //for (int x = 0; x < width(); ++x) {
        //    for (int y = 0; y < height(); ++y) {
        //        const QColor color(static_cast<QRgb> ( x + y));
        //        painter.setPen(color);
        //        painter.drawPoint(x, y);
        //    }
        //}
    //}
    //qDebug() << "drawPoint time:" << time.elapsed();
    //close();
}

void ColorMap::mousePressEvent(QMouseEvent* event)
{
    
    if ( this->underMouse()) {
        //if the click is not on the widget, i.e. if it's the click that hides it,
        // you caught it, do what you want to do here.
    }
    int x = event->x();
    int y = event->y();
    QWidget::mousePressEvent(event);
}