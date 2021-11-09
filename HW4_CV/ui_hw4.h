/********************************************************************************
** Form generated from reading UI file 'hw4.ui'
**
** Created by: Qt User Interface Compiler version 6.2.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_HW4_H
#define UI_HW4_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_HW4
{
public:
    QWidget *centralwidget;
    QLabel *lbl;
    QPushButton *btnOpen;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *HW4)
    {
        if (HW4->objectName().isEmpty())
            HW4->setObjectName(QString::fromUtf8("HW4"));
        HW4->resize(800, 600);
        centralwidget = new QWidget(HW4);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        lbl = new QLabel(centralwidget);
        lbl->setObjectName(QString::fromUtf8("lbl"));
        lbl->setGeometry(QRect(140, 20, 512, 512));
        lbl->setStyleSheet(QString::fromUtf8("background-color: rgb(111, 111, 111);"));
        btnOpen = new QPushButton(centralwidget);
        btnOpen->setObjectName(QString::fromUtf8("btnOpen"));
        btnOpen->setGeometry(QRect(20, 140, 80, 21));
        HW4->setCentralWidget(centralwidget);
        menubar = new QMenuBar(HW4);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 800, 25));
        HW4->setMenuBar(menubar);
        statusbar = new QStatusBar(HW4);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        HW4->setStatusBar(statusbar);

        retranslateUi(HW4);

        QMetaObject::connectSlotsByName(HW4);
    } // setupUi

    void retranslateUi(QMainWindow *HW4)
    {
        HW4->setWindowTitle(QCoreApplication::translate("HW4", "HW4", nullptr));
        lbl->setText(QString());
        btnOpen->setText(QCoreApplication::translate("HW4", "PushButton", nullptr));
    } // retranslateUi

};

namespace Ui {
    class HW4: public Ui_HW4 {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_HW4_H
