#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_ColorMap.h"

class ColorMap : public QMainWindow
{
    Q_OBJECT

public:
    ColorMap(QWidget *parent = Q_NULLPTR);
    void paintEvent(QPaintEvent*);
    void mousePressEvent(QMouseEvent* event);
private:
    Ui::ColorMapClass ui;
};
