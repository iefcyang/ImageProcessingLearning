#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_HWK03QT.h"
#include "ColorImage.h"

class HWK03QT : public QMainWindow
{
    Q_OBJECT

public:
    HWK03QT(QWidget *parent = Q_NULLPTR);
    void GetMaskFromTableView();

    static ColorImage* FFT(ColorImage* target, ColorImage** image)
    {
        ColorImage* realPart = new ColorImage();
        ColorImage* imagePart = new ColorImage();
        *image = imagePart;
        return realPart;
    }

private slots:
    void on_btn1_clicked();
    void on_btn2_clicked();
    void on_pushButton_clicked();
    void on_btnCreate_clicked();
    void on_btnGetMask_clicked();
    void on_cbxFilters_currentIndexChanged(int index);
private:
    int** mask;
    Ui::HWK03QTClass ui;
};
