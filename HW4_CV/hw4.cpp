#include "hw4.h"
#include "ui_hw4.h"
#include <QFileDialog>

HW4::HW4(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::HW4)
{
    ui->setupUi(this);
}

HW4::~HW4()
{
    delete ui;
}


void HW4::on_btnOpen_clicked()
{
    QString fileName = QFileDialog::getOpenFileName(this,
        tr("Open file"), ".",
        tr("img Files (*.png *.jpg *.jpeg *.bmp"));

    if(fileName != "")
    {
        QImage qimg = QImage(fileName);
        mainimg = new ColorImage(&qimg);
        MonoImage* grey = ColorImage::GetGreyAverage(mainimg);
        // Display on label.
        ui->lbl->setPixmap(QPixmap::fromImage(grey->getImage()).scaled(ui->lbl->size(), Qt::KeepAspectRatio, Qt::SmoothTransformation));
        // Resize the label to fit the image.
        ui->lbl->resize(ui->lbl->pixmap().size());
    }
    else
    {


    }

}

