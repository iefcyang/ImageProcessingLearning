#include "HWK03QT.h"
#include <QStandardItem>

#include "Filter.h"
#include <iostream>

using namespace std;




HWK03QT::HWK03QT(QWidget *parent)
    : QMainWindow(parent)
{
    ui.setupUi(this);

    Filter* f = new Filter();
    ColorImage* img = new ColorImage();
    ColorImage* out = *f * img;
    out = *f + img;

   // time_point t;
}



void HWK03QT::on_pushButton_clicked()
{
   // std::chrono::duration diff = new duration();

    clock_t startTime = clock(); // get and set system ticks
    cursor().setShape(Qt::WaitCursor);

    //QString str = ui.textEdit->toPlainText();
    //string ss = str.toStdString();
    // 
    //QStringList items = str.split(",",Qt::SkipEmptyParts);
    //string s1 = items[0].toStdString();

    //int h = items[0].toInt();
    //int w = items[1].toInt();

    double seconds = (clock() - startTime) / CLOCKS_PER_SEC; // get seconds
    cursor().setShape(Qt::ArrowCursor);
    printf( "\a" ); // Beep

}


void HWK03QT::on_btnCreate_clicked()
{
    int h = ui.spbHeight->value();
    int w = ui.spbWidth->value();
    
    QStandardItemModel* model = new QStandardItemModel(h, w);
    ui.tbwMask->setModel(model);
    for (int r = 0; r < h; r++)
        for (int c = 0; c < w; c++)
        {
            ui.tbwMask->setColumnWidth(c, 40);
            model->setItem(r, c, new QStandardItem( QString::number(6)));
        }
    ui.btnGetMask->setEnabled(true);
}
void HWK03QT::on_btn1_clicked()
{
    int h = 600, w=600;

    clock_t start = clock();
    double*** p1 = new double** [3];
    for (int d = 0; d < 3; d++)
    {
        p1[d] = new double* [h];
        for (int v = 0; v < h; v++)
            p1[d][v] = new double[w];
    }
    for (int d = 0; d < 3; d++)
    {
        for (int r = 0; r < h; r++)
            for (int c = 0; c < w; c++)
                p1[d][r][c] = std::rand() * 100;
    }
    double time1 = (clock() - start) / CLOCKS_PER_SEC;
    double* all = new double[3 * h * w];

/*    for (int d = 0; d < 3; d++)
    {
        for (int r = 0; r < h; r++)
        {
            int off = r +d;
            for (int c = 0; c < w; c++)
                p1[d][r][c] = std::rand() * 100;
        }
    }*/
    
}
void HWK03QT::on_btn2_clicked()
{

}
void HWK03QT::on_btnGetMask_clicked()
{
    GetMaskFromTableView();
}

void HWK03QT::on_cbxFilters_currentIndexChanged(int index)
{

    mask = new int* [3];
    for (int r = 0; r < 3; r++)
    {
        mask[r] = new int[3];
    }
    for (int c = 0; c < 3; c++)
        ui.tbwMask->setColumnWidth(c, 40);
    QStandardItemModel* model = new QStandardItemModel(3, 3);
    ui.tbwMask->setModel(model);

    switch (index)
    {
    case 0://box
        mask[0][0] = 1; mask[0][1] = 1; mask[0][2] = 1;
        mask[1][0] = 1; mask[1][1] = 1; mask[1][2] = 1;
        mask[2][0] = 1; mask[2][1] = 1; mask[2][2] = 1;
        break;
    }
    for (int r = 0; r < 3; r++)
        for (int c = 0; c < 3; c++)
            model->setItem(r, c, new QStandardItem(QString::number(mask[r][c])));
}

void HWK03QT::GetMaskFromTableView()
{
    int rows, cols;
    rows = ui.tbwMask->model()->rowCount();
    cols = ui.tbwMask->model()->columnCount();

    if (mask == 0)
    {
        mask = new int* [rows];
        for (int r = 0; r < rows; r++)
        {
            mask[r] = new int[cols];
        }
    }
    QStandardItemModel* theModel = (QStandardItemModel*)(ui.tbwMask->model());
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < rows; c++)
            mask[r][c] = int(theModel->item(r, c));
    }
}