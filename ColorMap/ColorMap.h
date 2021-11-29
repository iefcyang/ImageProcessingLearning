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

private slots:

    void on_verticalSlider_sliderReleased();
    void on_listWidget_itemClicked(QListWidgetItem* item);
    void on_btnAdd_clicked();
    void on_btnDelete_clicked();


    
private:
    Ui::ColorMapClass ui;
};
