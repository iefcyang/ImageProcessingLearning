#ifndef HW4_H
#define HW4_H

#include <QMainWindow>
#include <colorimage.h>


QT_BEGIN_NAMESPACE
namespace Ui { class HW4; }
QT_END_NAMESPACE

class HW4 : public QMainWindow
{
    Q_OBJECT
    ColorImage* mainimg;

public:
    HW4(QWidget *parent = nullptr);
    ~HW4();

private slots:
    void on_btnOpen_clicked();

private:
    Ui::HW4 *ui;
};
#endif // HW4_H
