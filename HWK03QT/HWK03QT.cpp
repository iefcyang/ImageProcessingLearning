#include "HWK03QT.h"
#include <QStandardItem>
using namespace std;


HWK03QT::HWK03QT(QWidget *parent)
    : QMainWindow(parent)
{
    ui.setupUi(this);
}


void HWK03QT::on_pushButton_clicked()
{
    QString str = ui.textEdit->toPlainText();
    string ss = str.toStdString();
     
    QStringList items = str.split(",",Qt::SkipEmptyParts);
    string s1 = items[0].toStdString();

    int h = items[0].toInt();
    int w = items[1].toInt();

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

void HWK03QT::on_btnGetMask_clicked()
{
    GetMaskFromTableView();
}

void HWK03QT::on_cbxFilters_currentlndexChanged(int index)
{

        mask = new int* [3];
        for (int r = 0; r < 3; r++)
        {
            mask[r] = new int[3];
        }
        for (int c = 0; c < 3; c++)
            ui.tbwMask->setColumnWidth(c, 40);
        QStandardItemModel* model = new QStandardItemModel(3,3);
        ui.tbwMask->setModel(model);

    switch (index)
    {
    case 0://aaa
        mask[0][0] = 1;

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